/*
Name:		GSM-shiled library
Version:	1.1.0
Created:	05.07.2013
Updated:	22.07.2013
Programmer:	Mitsengendler A.
Production:	RumCode
*/

#ifndef SoftwareSerial_h
#include <SoftwareSerial.h>
#endif
#ifndef GSM_h
#define GSM_h
#endif

class GSM
{
public:
	GSM();
	bool init(long);
        bool initSMS();
	bool SendSMS(const String&, const String&);
	bool SMSRecieved(String&, String&);
	void LED(int);
private:
	bool sendCommand(const String&);
        bool sendCommandWaitResponse(const String&, const String&, int=3);
protected:
	SoftwareSerial gsmSerial;
};

