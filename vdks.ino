#include <TimerOne.h>
#include <Common.h>
#include <EEPROM.h>
#define Idle 0
#define Writing 2
#define Reading 1
//Global variables region
int commandState = Idle; // Reading/Writing eeprom state
int selectedAddress = -1; // Slected adress in eeprom to read/write -1 for "selection is empty"
//Global endregion
 
void setup() 
{
  pinMode(13, OUTPUT);   //LED pin
 
  // initialize serial:
  Serial.begin(9600);
 
  Timer1.initialize(1000000); // set a timer of length 100000 microseconds (or 0.1 sec - or 10Hz => the led will blink 5 times, 5 cycles of on-and-off, per second)
  Timer1.attachInterrupt( timerIsr ); // attach the service routine here
  
}
void loop()
{
 
 
  
}
 
void timerIsr()//Timer routine
{
    // Toggle LED
    digitalWrite( 13, digitalRead( 13 ) ^ 1 );
    if(digitalRead( 13 )) Timer1.setPeriod(100000); //Toggle ON/OFF period
    else Timer1.setPeriod(1000000);
}
void serialEvent() 
{
 
  while (Serial.available()) {
    byte inData = Serial.read();
  switch(commandState)
  {
    case Idle:
    switch(inData)
    {
      case 0xAB:
      Serial.write(0xBC);
      break;
      case 0x1:
      commandState = Reading;
      break;
      case 0x2:
      commandState = Writing;
      break;
    }
    break;
    case Reading:
    Serial.write(EEPROM.read(inData));
    commandState = Idle;
    break;
    case Writing:
    if(selectedAddress > -1)
    {
      EEPROM.write(selectedAddress,inData);
      Serial.write(0x0);
      selectedAddress = -1;
      commandState = Idle;
    }
    else
    {
      selectedAddress = inData;
    }
    
    break;
    
    
  }
  }
  
    
  }

