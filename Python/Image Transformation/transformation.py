# -*- coding: utf-8 -*-
"""
Created on Sat Aug 23 10:29:55 2025

@author: anuvi
"""
import cv2 as cv
import helper
import numpy as np

# Scale
def scale(imgSrc:np.ndarray, scaleFactor:int):
    assert imgSrc is not None, "file count not be read"
    
    height, width = imgSrc.shape[:2]
    scaled = cv.resize(imgSrc,(width * scaleFactor, height * scaleFactor) , interpolation= cv.INTER_LINEAR)
    helper.displayImage('Scaled', scaled)

# Rotate By 90
def rotate90(imgSrc:np.ndarray):
    assert imgSrc is not None, "file could not be read"
    rotated = cv.rotate(imgSrc, cv.ROTATE_90_CLOCKWISE)
    helper.displayImage("Rotated", rotated)

# Rotate by any angle    
def rotateAny(imgSrc:np.ndarray, angle:int):
    assert imgSrc is not None, "file could not be read"
    
    rows,cols,_ = imgSrc.shape
    center = (cols-1)/2.0 , (rows-1)/2.0
    M = cv.getRotationMatrix2D(center, angle, 1)
    rotated = cv.warpAffine(imgSrc,M,(cols,rows))
    helper.displayImage('rotateAny', rotated)
    
# Perspective Correction

def correctPerspective(imgSrc:np.ndarray):
    assert imgSrc is not None, "file could not be read"
    
    inArr = np.float32([[506,317],[1047,317],[318,684],[1200,684]])
    outArr = np.float32([[0,0],[300,0],[0,300],[300,300]])
    
    debug = imgSrc.copy()
    for (x, y) in inArr.astype(int):
        cv.circle(debug, (x, y), 5, (0,0,255), -1)
      
    helper.displayImage('Perspective Intermediate',debug)

    M = cv.getPerspectiveTransform(inArr, outArr)
    dist = cv.warpPerspective(imgSrc, M, (300,300))
    
    helper.displayImage('Perspective Correction', dist)
    
    