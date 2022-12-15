//Arduino Code.


#include <SoftwareSerial.h>
#include <Wire.h>                              // To communicate with I2C.
#include <LiquidCrystal_I2C.h>                 // To control I2C(LCD) displays with functions.

LiquidCrystal_I2C lcd(0x27, 16, 2);            // Set the LCD address to 0x27 for a 16 chars and 2 line display.

//Sensors
int tempAquarium = A0;

int tempHotWater = A1;

int trigLevelAquarium = 2;
int echoLevelAquarium = 3;

int trigLevelFood = 5;
int echoLevelFood = 6;


//Global variabels
int temp  = 0;
int distance = 0;

void setup() {

  //Declaring Pins.
  pinMode(tempAquarium, INPUT);
  
  pinMode(tempHotWater, INPUT);

  pinMode(trigLevelAquarium, OUTPUT);
  pinMode(echoLevelAquarium, INPUT);

  pinMode(trigLevelFood, OUTPUT);
  pinMode(echoLevelFood, INPUT);

  
  //Seeial Monitor.
  Serial.begin(9600);

  //LCD.
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


float getTemp(int pin){
  temp = analogRead(pin);  
  float volts = (temp / 965.0) * 5;  
  float celcius = (volts - 0.5) * 100; 

  return celcius;
}
