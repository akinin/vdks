#include "GSM.h"
#include <SoftwareSerial.h>

#define LED 13
#define RELAY1 7
#define RELAY2 8
#define ON 1
#define OFF 0

GSM gsm;
void setup()
{
	Serial.begin(9600);
	pinMode(LED,OUTPUT);
        if(!gsm.init(1200)) Serial.println("Can't init GSM");
        else Serial.println("GSM init success");
        if(!gsm.initSMS()) Serial.println("Can't init SMS engine");
        else Serial.println("SMS engine init success");
}
String text;
String number;
volatile bool gotSMS=false;
void loop()
{       
   
       if(gsm.SMSRecieved(text, number))
        {
          Serial.println("Got SMS");
          Serial.print("number: ");
          Serial.println(number);
          Serial.print("text: ");
          Serial.println(text);
          gsm.SendSMS(number,"got you");
        }
}
