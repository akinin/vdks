#include "GSM.h"
#include <SoftwareSerial.h>

#define LEDPIN 13 //onboard arduino led
#define RELAYPIN1 2 //relay 1
#define RELAYPIN2 3 //relay 2
#define SENSORPIN 6 //water-level sensor
#define ON 1
#define OFF 0
#define BLINK 2


GSM gsm;
String startCode = "00530061006D0070006C006500720020006F006E"; // "Sampler on" string in unicode

void setup()
{
	Serial.begin(115200);
	pinMode(LEDPIN,OUTPUT);
        pinMode(RELAYPIN1, OUTPUT);
        pinMode(RELAYPIN2, OUTPUT);
        pinMode(SENSORPIN, INPUT);
        if(!gsm.init(2400)) Serial.println(F("Can't init GSM"));
        else Serial.println(F("GSM init success"));
        if(!gsm.initSMS()) Serial.println(F("Can't init SMS engine"));
        else Serial.println(F("SMS engine init success"));
}
String MessageText;
String SenderNumber;

void loop()
{       
 
      if(gsm.SMSRecieved(MessageText, SenderNumber))
        {
          #ifdef DEBUG
          Serial.println(F("Got SMS"));
          Serial.print(F("number: "));
          Serial.println(SenderNumber);
          Serial.print(F("text: "));
          Serial.println(MessageText);
          #endif
          if(MessageText.equals(startCode))
          {
            gsm.LED(ON);
            gsm.SendSMS(SenderNumber,"Starting pumps...");
            digitalWrite(RELAYPIN1, HIGH);
            digitalWrite(RELAYPIN2, HIGH);
            #ifdef DEBUG
            Serial.println(F("Starting pumps..."));
            #endif
            while(digitalRead(SENSORPIN)==LOW)
            {
                #ifdef DEBUG
                Serial.println(digitalRead(SENSORPIN));
                #endif
                delay(1);
            }
            #ifdef DEBUG
            Serial.println(F("Stopping pumps..."));
            #endif
            digitalWrite(RELAYPIN1, LOW);
            digitalWrite(RELAYPIN2, LOW);
            gsm.LED(OFF);
            gsm.SendSMS(SenderNumber,"Pumps stopped");            
          }
        
        }
}