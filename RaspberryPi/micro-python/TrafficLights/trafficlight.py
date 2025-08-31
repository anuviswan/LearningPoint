from machine import Pin
from utime import sleep

# Define pins
RED = Pin(1, Pin.OUT)
GREEN = Pin(3, Pin.OUT)
YELLOW = Pin(13, Pin.OUT)

while True:
    RED.toggle()
    sleep(0.5)
    