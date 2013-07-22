#include "GSM.h"
#include <SoftwareSerial.h>

#define LEDpin 13
#define RELAY1 7
#define RELAY2 8
#define ON 1
#define OFF 0
#define BLINK 2


GSM gsm;

void setup()
{
	Serial.begin(115200);
	pinMode(LEDpin,OUTPUT);
        if(!gsm.init(2400)) Serial.println(F("Can't init GSM"));
        else Serial.println(F("GSM init success"));
        if(!gsm.initSMS()) Serial.println(F("Can't init SMS engine"));
        else Serial.println(F("SMS engine init success"));
}
String text;
String number;
volatile bool gotSMS=false;
String test = "0056006F0074002C0020006F007000690061007400270020006E00610070006900730061006C";
void loop()
{       
  Serial.println(test);
  delay(5000);
       if(gsm.SMSRecieved(text, number))
        {
          Serial.println("Got SMS");
          Serial.print("number: ");
          Serial.println(number);
          Serial.print("text: ");
          Serial.println(text);
          gsm.LED(BLINK);
          delay(5000);
          gsm.LED(OFF);
         // gsm.SendSMS(number,"got you");
        }
}
