#include "GSM.h"
#include <EEPROM.h>
#include <SoftwareSerial.h>

#define LEDPIN 13 //onboard arduino led
#define RELAYPIN1 2 //relay 1
#define RELAYPIN2 3 //relay 2
#define SENSORPIN 6 //water-level sensor
#define RESETPIN 12

#define ON 1
#define OFF 0
#define BLINK 2

#define ECHOREQUEST 0xAB
#define ECHOCODE 0xBC
#define READCODE 0x1
#define WRITECODE 0x2
#define SERIALCODE 0x3
#define RESETCODE 0x4
#define CONNECTIONATTEMPTS 3




GSM gsm;
void(* resetFunc) (void) = 0; //declare reset function @ address 0

void setup()
{
        Serial.begin(115200);
        pinMode(LEDPIN,OUTPUT);
        pinMode(RELAYPIN1, OUTPUT);
        pinMode(RELAYPIN2, OUTPUT);
        pinMode(SENSORPIN, INPUT);
        digitalWrite(LEDPIN,LOW);
        bool gotAnswer = false;
        for(int i=0;i < CONNECTIONATTEMPTS; i++)
        {
            Serial.write(ECHOREQUEST);
            delay(500);
            if(Serial.available() && Serial.read() == ECHOCODE)
            {
              gotAnswer = true;
              break;
            }
        }
        if(gotAnswer) serviceMode();
        if(!gsm.init(2400)) Serial.println(F("Can't init GSM"));
        else Serial.println(F("GSM init success"));
        if(!gsm.initSMS()) Serial.println(F("Can't init SMS engine"));
        else Serial.println(F("SMS engine init success"));
}
String MessageText;
String SenderNumber;

void loop()
{       
  
  
//      if(gsm.SMSRecieved(MessageText, SenderNumber))
//        {
//          #ifdef DEBUG
//          Serial.println(F("Got SMS"));
//          Serial.print(F("number: "));
//          Serial.println(SenderNumber);
//          Serial.print(F("text: "));
//          Serial.println(MessageText);
//          #endif
//          if(MessageText.equals(startCode))
//          {
//            gsm.LED(ON);
//            gsm.SendSMS(SenderNumber,"Starting pumps...");
//            digitalWrite(RELAYPIN1, HIGH);
//            digitalWrite(RELAYPIN2, HIGH);
//            #ifdef DEBUG
//            Serial.println(F("Starting pumps..."));
//            #endif
//            while(digitalRead(SENSORPIN)==LOW)
//            {
//                #ifdef DEBUG
//                Serial.println(digitalRead(SENSORPIN));
//                #endif
//                delay(1);
//            }
//            #ifdef DEBUG
//            Serial.println(F("Stopping pumps..."));
//            #endif
//            digitalWrite(RELAYPIN1, LOW);
//            digitalWrite(RELAYPIN2, LOW);
//            gsm.LED(OFF);
//            gsm.SendSMS(SenderNumber,"Pumps stopped");            
//          }
//        
//        }
}

void serviceMode()
{
  digitalWrite(LEDPIN,HIGH);
  while(1)
  {
    if(Serial.available())
    {
      switch(Serial.read())
      {
        case READCODE:
           awaitSerial(1);
           Serial.write(EEPROM.read(Serial.read()));
        break;
        case WRITECODE:
           awaitSerial(2);
           EEPROM.write(Serial.read(), Serial.read());
        break;
        case SERIALCODE:
           Serial.print("AA000000000");
        break;
        case RESETCODE:
           resetFunc(); 
        break;
     }
    }
  }
}

void awaitSerial(int byteCount)
{
  while(Serial.available() < byteCount)
  {
  }
}
