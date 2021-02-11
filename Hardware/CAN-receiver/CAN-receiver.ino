/*
Prerequisites:
STM32duino core: https://github.com/stm32duino/Arduino_Core_STM32
exoCAN library: https://github.com/exothink/eXoCAN
*/

#include <arduino.h>
#include <eXoCAN.h>

#define bluePillLED PC13

int id, fltIdx;
uint8_t rxbytes[8];
eXoCAN can;

void setup() {
  Serial1.begin(115200);
  can.begin(STD_ID_LEN, BR250K, PORTA_11_12_XCVR);
  can.filterMask16Init(0, 0, 0x7ff, 0, 0);                
  pinMode(bluePillLED, OUTPUT);
  Serial1.println("Start program");
}

uint32_t last = 0;
char output_str[28];
char output_format[]="%.3X %.2X %.2X %.2X %.2X %.2X %.2X %.2X %.2X";

void loop() {
  // poll for rx
  if (can.receive(id, fltIdx, rxbytes) > -1) { 
    digitalToggle(bluePillLED);
    sprintf(output_str, output_format ,id, rxbytes[0],rxbytes[1],rxbytes[2],rxbytes[3],rxbytes[4],rxbytes[5],rxbytes[6],rxbytes[7]);
    Serial1.println(output_str);
    /*Serial1.print(id, HEX);
    Serial1.print(" ");

    for(int i=0;i<8;i++) {      
      Serial1.print(rxbytes[i], HEX);
      Serial1.print(" ");
    }    
    Serial.println();*/
  }
}
