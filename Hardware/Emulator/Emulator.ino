/*
Prerequisites:
arduino-mcp2515 library: https://github.com/autowp/arduino-mcp2515
*/

#include <SPI.h>
#include <mcp2515.h>

struct can_frame door_msg={
.can_id  = 0x77E,
.can_dlc = 8,
.data={0x05, 0x62, 0x22, 0x0D, 0x55, 0x65, 0xAA, 0xAA}
};
bool door_state[]={0,0,0,0}; // closed - 1, opened - 0  
uint8_t door_i;

MCP2515 mcp2515(10);


void setup() {
  Serial.begin(115200);
  
  mcp2515.reset();
  mcp2515.setBitrate(CAN_500KBPS);
  mcp2515.setNormalMode();

  randomSeed(analogRead(0));
  
  Serial.println("Start program");
}

void loop() {
  //invert state of random door
  door_i=random(4);
  door_state[door_i]=!door_state[door_i];
  update_door_msg();
  
  mcp2515.sendMessage(&door_msg);    
  delay(5000);
}
  
void update_door_msg(){
  door_msg.data[4]=0;
  for(uint8_t i=0;i<4;i++){
    door_msg.data[4]=door_msg.data[4]|door_state[i]<<(i*2);
  }
}
