#include "GSM.h"
#include <EEPROM.h>
#include <SoftwareSerial.h>

#define LEDPIN 13 //onboard arduino led
#define RELAYPIN1 2 //relay 1
#define RELAYPIN2 3 //relay 2
#define SENSORPIN 6 //water-level sensor

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
#define TIMETOFILL 120000 //2 mins t o fill container




GSM gsm;
void(* resetFunc) (void) = 0; //declare reset function @ address 0
int filterNumbersCount;
int alertNumbersCount;
char **filterNumbers;
char **alertNumbers;
String MessageText;
String SenderNumber;

void setup()
{
  Serial.begin(9600);
  ServiceLoader();
  Serial.println(F("Greetings!"));
  /*********
   * pins setup
   **********/
  pinMode(LEDPIN,OUTPUT);
  pinMode(RELAYPIN1, OUTPUT);
  pinMode(RELAYPIN2, OUTPUT);
  pinMode(SENSORPIN, INPUT);
  digitalWrite(LEDPIN,LOW);
  digitalWrite(RELAYPIN1,LOW);
  digitalWrite(RELAYPIN2,LOW);
  /*********
   * Load Numbers from EEPROM
   *********/
  LoadNumbers();
  /*********
   * GSM-shield init
   **********/
  if(!gsm.init(2400)) Serial.println(F("Can't init GSM"));
  else Serial.println(F("GSM init success"));
  if(!gsm.initSMS()) Serial.println(F("Can't init SMS engine"));
  else Serial.println(F("SMS engine init success"));

}


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
           if(CheckFilter(SenderNumber))
           {
             gsm.LED(ON);
             AlertToAll("Starting pumps...");
             int timeStarted = millis();
             digitalWrite(RELAYPIN1, HIGH);
             digitalWrite(RELAYPIN2, HIGH);
             #ifdef DEBUG
             Serial.println(F("Starting pumps..."));
             #endif
             while(digitalRead(SENSORPIN)==LOW)
             {
                 if( millis() - timeStarted > TIMETOFILL) break;
                 #ifdef DEBUG
                 Serial.println(digitalRead(SENSORPIN));
                 #endif
                 delay(1);
             }
             if(digitalRead(SENSORPIN)==HIGH)
             {
             #ifdef DEBUG
             Serial.println(F("Stopping pumps..."));
             #endif
             digitalWrite(RELAYPIN1, LOW);
             digitalWrite(RELAYPIN2, LOW);
             gsm.LED(OFF);
              AlertToAll("Pumps stopped");            
            }
            else
            {
               #ifdef DEBUG
             Serial.println(F("TimeOut! Stopping pumps..."));
             #endif
             digitalWrite(RELAYPIN1, LOW);
             digitalWrite(RELAYPIN2, LOW);
             gsm.LED(OFF);
              AlertToAll("Something wrong... Pumps stopped"); 
            }
           }
         
         }
}

void serviceMode()//PC-client communication
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

void ServiceLoader() //determine if Serial Connection with PC-client is present
{
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
}

void awaitSerial(int byteCount)
{
  while(Serial.available() < byteCount)
  {
  }
}

void LoadNumbers()
{
  int memOffset = 0;
  filterNumbersCount = EEPROM.read(memOffset++);
  alertNumbersCount = EEPROM.read(memOffset++);

  filterNumbers = new char*[filterNumbersCount];
  alertNumbers = new char*[alertNumbersCount]; 

  for(int i = 0; i<filterNumbersCount; i++)
  {
    filterNumbers[i] = new char[11];
    for(int j=0; j<10; j++)
    {

      filterNumbers[i][j] = EEPROM.read(memOffset++) + (byte)0x30; // convert byte to char

    }
    filterNumbers[i][10] = 0;
  }


  for(int i = 0; i<alertNumbersCount; i++)
  {
    alertNumbers[i] = new char[11];
    for(int j=0; j<10; j++)
    {
      alertNumbers[i][j] = EEPROM.read(memOffset++) + (byte)0x30; // convert byte to char      
    }
    alertNumbers[i][10] = 0;
  }
#ifdef DEBUG
  Serial.print("Filter numbers loaded: ");
  Serial.println(filterNumbersCount);
  for(int i = 0; i<filterNumbersCount; i++)
  {
    Serial.println(filterNumbers[i]);
  }
  Serial.print("Alert numbers loaded: ");
  Serial.println(alertNumbersCount);

  for(int i = 0; i<alertNumbersCount; i++)
  {
    Serial.println(alertNumbers[i]);
  }
#endif

}

bool CheckFilter(const String& number) //Checks if number is in filter list
{
  String _number = number.substring(2);
  for(int i = 0; i < filterNumbersCount; i++)
  {
    if(!_number.compareTo(filterNumbers[i])) return true;
  }
  return false;
}

void AlertToAll(const String& message)
{
  for(int i=0; i< alertNumbersCount;i++)
  {
  gsm.SendSMS(alertNumbers[i],message);
  delay(200);
  }
}


