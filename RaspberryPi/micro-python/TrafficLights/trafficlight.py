from machine import Pin
from utime import sleep

# Global Variables
# Define pins
RED = Pin(1, Pin.OUT)
GREEN = Pin(13, Pin.OUT)
YELLOW = Pin(3, Pin.OUT)

def TurnYellow():
    RED.value(0)
    YELLOW.value(1)
    GREEN.value(0)
    print("Yellow")
    sleep(1)

def TurnRed():
    TurnYellow()

    RED.value(1)
    YELLOW.value(0)
    GREEN.value(0)
    print("Red")
    sleep(1)

def TurnGreen():
    TurnYellow()

    RED.value(0)
    YELLOW.value(0)
    GREEN.value(1)
    print("Green")
    sleep(1)    



print("Traffic Light Demo")


while True:
    TurnRed()
    TurnGreen()

    