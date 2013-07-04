/*
Name:		GSM-shiled library
Version:	1.0.0
Created:	05.07.2013
Updated:	05.07.2013
Programmer:	Mitsengendler A.
Production:	RumCode
*/


#ifndef Arduino_h
#include "Arduino.h"
#endif
#ifndef SoftwareSerial_h
#include <SoftwareSerial.h>
#endif
#ifndef GSM_h
#include "GSM.h"
#endif
//SofwareSerial pin configuration
#define RX_PIN 2
#define TX_PIN 3
#define ctrlz 26 //Ascii character for ctr+z. End of a SMS.
#define cr    13 //Ascii character for carriage return. 
#define lf    10 //Ascii character for line feed. 
#define ctrlz 26 //Ascii character for ctr+z. End of a SMS.

#define DEBUG
//default ctor
GSM::GSM():gsmSerial(RX_PIN, TX_PIN)
{
	
}

//send command through SoftwareSerial
bool GSM::sendCommand(const String& command)
{
        if(!gsmSerial.available())
	{
		gsmSerial.print(command);
                gsmSerial.flush();
                gsmSerial.write(cr);
                return true;
	}
	return false;
}


//send command through SoftwareSerial and wait for defined response
bool GSM::sendCommandWaitResponse(const String& command,const String& response, int tryCount)
{
	String sResponse = "";
	char currCh;
        int timeout = 500;
        for(int i=0; i<tryCount; i++)
        {
          gsmSerial.flush();
        if(sendCommand(command))
	{
           
           unsigned long timestamp=millis();
           while(!gsmSerial.available())//wait for software serial activity
           {          
             unsigned long timeNow = millis();
             if(timeNow-timestamp > timeout) return false; //or die
           }
           delay(100);//waiting for other chars
           while(gsmSerial.available() > 0) //last symbol is always '\n'
	   {
                if(sResponse == response) 
                {
                  #ifdef DEBUG
                  Serial.print(command);
                  Serial.print(" - ");
                  Serial.println(sResponse);
                  #endif
                  return true; //find first occurrence and return true
                }
               	currCh = gsmSerial.read();
                if(currCh != cr && currCh != lf)
		  {
			sResponse += String(currCh);
		  }  
		else
		  {
                        sResponse = "";
		  }	
           }
          }
        }
	return false;

}

//GSMshield init, serial test
bool GSM::init(long baudRate)
{
	gsmSerial.begin(baudRate);
        delay(1500);
        if(sendCommandWaitResponse("AT","OK",10)) return true;
        return false;
}

//Prepare to recieve and send SMS messages
//messages will be recieved to SoftSerial
bool GSM::initSMS()
{
  if(!sendCommandWaitResponse("AT+CMGF=1","OK",10))return false; //set mode to text
  if(!sendCommandWaitResponse("AT+IFC=1,1","OK",10))return false;
  if(!sendCommandWaitResponse("AT+CPBS=\"SM\"","OK",10))return false;
  if(!sendCommandWaitResponse("AT+CNMI=1,2,2,1,0","OK",10))return false;
  return true;
}

//Sends sms
bool GSM::SendSMS(const String& number,const String& text)
{
  String numberCommand = "AT + CMGS = \"" + number + "\"";
  if(!sendCommand(numberCommand)) return false;
  delay(100);
  gsmSerial.print(text);
  delay(100);
  gsmSerial.write(ctrlz);
  gsmSerial.flush();
  return true;
}

//returns true on SMS arrival and puts number and text to refs
bool GSM::SMSRecieved(String& messageText,String& senderNumber) //TODO: check text arrival
{
  if(gsmSerial.available()) delay(1000);
  else return false;
  char currSymb=0;
  bool isStringMessage=false;
  String currStr="";
  while(gsmSerial.available())
  {
    currSymb = gsmSerial.read();    
    if (currSymb == cr) 
	{
          if(isStringMessage)
            {
              messageText=currStr;             
              return true;      
            }
          else if (currStr.startsWith("+CMT"))
              {
                  //if begins with "+CMT",
                  //next string is message text
                  isStringMessage = true;
                  senderNumber = currStr.substring(7,19); //get sender number               
              }
          currStr = "";
        }
	else if (currSymb != lf) 
	{
          currStr += String(currSymb);
        }
  }
  if(isStringMessage) //in case last 'lf' is missing
            {
              messageText=currStr;             
              return true;      
            }
  return false;
}

//void GSM::BlinkLED(Status stat)
//{
//}



