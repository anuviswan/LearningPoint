import cv2 as cv
import numpy as np

# Display image as per title and size
def displayImage(title:str,imgSrc:np.ndarray,height:int = 300, width:int = 300, shouldCloseWindow:bool=False):
    if imgSrc is None:
     print("⚠️ Image is None! Check your path or source.")
     return
 
    cv.namedWindow(title,cv.WINDOW_NORMAL)
    cv.resizeWindow(title,(width, height))
    
    #resize image to fit the size
    resizedImage = cv.resize(imgSrc,(width,height))
    
    cv.imshow(title,resizedImage)
    
    if shouldCloseWindow:
        cv.waitKey(0)  #display infinetely until keypress
    #cv.destroyWindow(title)
    

# close all active windows
def closeAllWindows():
    cv.destroyAllWindows()    
    
    