//Arduino Code.


#include <SoftwareSerial.h>
#include <Wire.h>                              // To communicate with I2C.
#include <LiquidCrystal_I2C.h>                 // To control I2C(LCD) displays with functions.

LiquidCrystal_I2C lcd(0x27, 16, 2);            // Set the LCD address to 0x27 for a 16 chars and 2 line display.




void setup() {
  Serial.begin(9600);

  lcd.init();                              // Initialize the LCD.
  lcd.backlight();                         // For the backlight of the LCD.
  lcd.setCursor(0, 0);                                // To print to the LCD.  setCursor(column,row).
  lcd.print("Welcome ");
  lcd.setCursor(7, 1);                                // To print to the LCD.  setCursor(column,row).
  lcd.print("User!");
  delay(3000);                                        // Delay the program by 3 seconds. i.e. Welcome User! is displayed for 3 seconds.
  lcd.clear();                                        // To clear the LCD.

}

void loop() {
  // put your main code here, to run repeatedly:

}
