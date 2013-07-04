/*
Name:		GSM-shiled library
Version:	1.0.0
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

enum Status {OFF, ON, BLINK, BLINK_SLOW};

class GSM
{
public:
	GSM();
	bool init(long);
        bool initSMS();
	bool SendSMS(const String&, const String&);
	bool SMSRecieved(String&, String&);
	void SetLED(Status);
private:
	bool isLEDOn;
	bool sendCommand(const String&);
        bool sendCommandWaitResponse(const String&, const String&, int=3);
protected:
	SoftwareSerial gsmSerial;
};

