import cv2 as cv

def displayImage(title,imgSrc,height = 300, width = 300):
    cv.namedWindow(title,cv.WINDOW_NORMAL)
    cv.resizeWindow(title,height, width)
    
    resizedImage = cv.resize(imgSrc,(height,width))
    
    cv.imshow(title,resizedImage)
    cv.waitKey(0)  #display infinetely until keypress
    cv.destroyWindow(title)
    

def closeAllWindows():
    cv.destroyAllWindows()    
    
    