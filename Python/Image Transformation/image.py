import cv2 as cv
import helper
import transformation as t

imgPath = "d:\\Demo.jpg"

# Load Image
imgOriginal = cv.imread(imgPath)
helper.displayImage('Original', imgOriginal)

# Transformation Demo
t.rotate90(imgOriginal)
t.rotateAny(imgOriginal, 45)


cv.waitKey(0)
helper.closeAllWindows()