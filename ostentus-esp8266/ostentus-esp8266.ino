#include <LEDMatrixDriver.hpp>
#include <ESP8266WiFi.h>
#include <ESP8266HTTPClient.h>
#include <WiFiClient.h>
#include <SPI.h>
#include <WiFiUdp.h>

#include "secrets.h"

const unsigned int PORT = 5011;
const int PACKET_BUFFER_SIZE = 64;

const uint8_t LEDMATRIX_CS_PIN = 15;
const int LEDMATRIX_SEGMENTS = 8;
const int LEDMATRIX_WIDTH = LEDMATRIX_SEGMENTS * 8;

char packetBuffer[PACKET_BUFFER_SIZE];

WiFiUDP Udp;

LEDMatrixDriver lmd(LEDMATRIX_SEGMENTS, LEDMATRIX_CS_PIN);

void setup() {
  Serial.begin(115200);
  WiFi.mode(WIFI_STA);
  WiFi.begin(SSID, PASSWORD);
  Serial.println("Connecting");
  while(WiFi.status() != WL_CONNECTED) {
    delay(250);
    Serial.print(".");
  }
  Serial.println();
  Serial.print("Connected! IP address: ");
  Serial.println(WiFi.localIP());
  Serial.print("UDP server on port: ");
  Serial.println(PORT);
  Udp.begin(PORT);

  lmd.setEnabled(true);
  lmd.setIntensity(0); // 0..=15
}

void printReceivedPacket(int packetSize) {
  Serial.println("Received packet:");

  Serial.print("\tSize: ");
  Serial.println(packetSize);

  Serial.print("\tRemote IP: ");
  Serial.println(Udp.remoteIP().toString().c_str());

  Serial.print("\tRemote Port: ");
  Serial.println(Udp.remotePort());

  Serial.print("\tLocal IP: ");
  Serial.println(Udp.destinationIP().toString().c_str());

  Serial.print("\tLocal Port: ");
  Serial.println(Udp.localPort());

  Serial.print("\tFree Heap: ");
  Serial.println(ESP.getFreeHeap());
}

void loop() {
  int packetSize = Udp.parsePacket();
  if (!packetSize) {
    return;
  }

  //printReceivedPacket(packetSize);

  int n = Udp.read(packetBuffer, PACKET_BUFFER_SIZE);
  switch (n)
  {
    case 1: // Set intensity
      lmd.setIntensity(packetBuffer[0]);
      break;
    case 64: // Set frame
      for (int x = 0; x < 64; x++) {
        lmd.setColumn(x, packetBuffer[x]);
      }
      lmd.display();
      break;
    default:
      for (int x = 0; x < 64; x++) {
        if (x >= n) {
          lmd.setColumn(x, 255);
          continue;
        }

        if (x % 2 == 0) {
          lmd.setColumn(x, 170);
        }
        else {
          lmd.setColumn(x, 85);
        }
      }
      lmd.display();
      break;
  }
}
