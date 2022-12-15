//Arduino Code.


#include <SoftwareSerial.h>
#include <Wire.h>                              // To communicate with I2C.
#include <LiquidCrystal_I2C.h>                 // To control I2C(LCD) displays with functions.

LiquidCrystal_I2C lcd(0x27, 16, 2);            // Set the LCD address to 0x27 for a 16 chars and 2 line display.




void setup() {
  // put your setup code here, to run once:

}

void loop() {
  // put your main code here, to run repeatedly:

}
