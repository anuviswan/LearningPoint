from machine import Pin
from utime import sleep

sleep(0.01) 
print("Traffic Light Example")

# Define pins
RED = Pin(1, Pin.OUT)
GREEN = Pin(3, Pin.OUT)
YELLOW = Pin(13, Pin.OUT)

DEMO = Pin(22, Pin.OUT)

while True:
    RED.value(1)
    YELLOW.value(0)
    GREEN.value(0)
    sleep(0.5)

    RED.value(0)
    YELLOW.value(1)
    GREEN.value(0)
    sleep(0.5)

    RED.value(0)
    YELLOW.value(0)
    GREEN.value(1)
    sleep(0.5)

    RED.value(0)
    YELLOW.value(1)
    GREEN.value(0)
    sleep(0.5)
    