# -*- coding: utf-8 -*-
"""
Created on Sat Aug 23 20:19:04 2025

@author: anuvi

Aim is to learn drawing shapes and text on a live video stream
"""


import cv2 as cv
import numpy as np

cap = cv.VideoCapture(1)

if not cap.isOpened():
    print('Camera not opened')
    exit()

while True:
    
    ret, frame = cap.read()
    
    if not ret:
        print("Failed to grab frame")
        break
    
    overlay = frame.copy()
    
    cv.rectangle(overlay, (100,100), (300,300), (255,0,0),2)
    cv.putText(overlay, 'Sample Text', (320,320), cv.FONT_HERSHEY_SIMPLEX, 1, (255,0,0))
    
    # Display the frame
    cv.imshow('Captured Video',overlay)
           
    # Press q to exit
    if cv.waitKey(1) == ord('q'):
        break

# Release camera and destroy created windows
cap.release()
cv.destroyAllWindows()

