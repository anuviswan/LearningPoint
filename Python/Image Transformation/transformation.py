# -*- coding: utf-8 -*-
"""
Created on Sat Aug 23 10:29:55 2025

@author: anuvi
"""
import cv2 as cv
import helper
import numpy as np


def rotate90(imgSrc:np.ndarray):
    assert imgSrc is not None, "file could not be read"
    rotated = cv.rotate(imgSrc, cv.ROTATE_90_CLOCKWISE)
    helper.displayImage("Rotated", rotated)
    
def rotateAny(imgSrc:np.ndarray, angle:int):
    assert imgSrc is not None, "file could not be read"
    
    rows,cols,_ = imgSrc.shape
    center = (cols-1)/2.0 , (rows-1)/2.0
    M = cv.getRotationMatrix2D(center, angle, 1)
    rotated = cv.warpAffine(imgSrc,M,(cols,rows))
    helper.displayImage('rotateAny', rotated)