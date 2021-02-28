#include <mcp2515.h>
#include "Emulator_parameters.h"
// uncomment line below to switch output mode to serial
//#define SERIAL_MODE

#define PIN_CS_MCP 10

MCP2515 mcp2515(PIN_CS_MCP);

can_frame* parameters[] = {&door_msg, &handbrake_msg, &outdoor_temperature_msg, &fuel_level_msg, &coolant_temp_msg, &rpm_msg, &oil_temp_msg,  &indoor_temp_msg, &steering_switch_msg, &current_consumption_msg, &odometer_msg};
uint8_t n_parameters = 11;

#ifdef SERIAL_MODE
  char output_str[28];
  char output_format[] = "%.3X %.2X %.2X %.2X %.2X %.2X %.2X %.2X %.2X";
#endif

void setup() {  
  Serial.begin(115200);

  mcp2515.reset();
  mcp2515.setBitrate(CAN_500KBPS);
  mcp2515.setNormalMode();

  randomSeed(analogRead(0));
  //change_parameters_randomly();
  Serial.println("Start program");  
}

void loop() {
  // send CAN messages
  for (uint8_t i = 0; i < n_parameters; i++) {
    #ifndef SERIAL_MODE
      mcp2515.sendMessage(parameters[i]);
      delay(2);                              // delay for stable transfer of packages
    #else
      can_frame* can_ptr = parameters[i];
      sprintf(output_str, output_format, (uint16_t)can_ptr->can_id, can_ptr->data[0], can_ptr->data[1], can_ptr->data[2], can_ptr->data[3], can_ptr->data[4], can_ptr->data[5], can_ptr->data[6], can_ptr->data[7]);
      Serial.println(output_str);
    #endif
  }
  delay(5000);
}