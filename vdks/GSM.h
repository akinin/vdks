/*
Name:		GSM-shiled library
Version:	0.9
Created:	05.07.2013
Updated:	05.07.2013
Programmer:	Mitsengendler A.
Production:	RumCode
*/
#ifndef SoftwareSerial_h
#include <SoftwareSerial.h>
#endif
#ifndef GSM_h
#define GSM_h
#endif

enum Status {OFF, ON};

class GSM
{
public:
	GSM();
	bool init(long baudRate);
        bool initSMS();
	void SendSMS(const char* number,const char* text);
	bool SMSRecieved(String& messageText,String& senderNumber);
	void BlinkLED(Status stat);
private:
	bool isLEDOn;
	bool sendCommand(const char* command);
        bool sendCommandWaitResponse(const char* command,const char* response, int tryCount=3);
protected:
	SoftwareSerial gsmSerial;
};

