import cv2 as cv
import helper
import transformation as t

imgPath = "d:\\Demo.png"

# Load Image
imgOriginal = cv.imread(imgPath)
helper.displayImage('Original', imgOriginal)

# Transformation Demo
t.rotate90(imgOriginal)
t.rotateAny(imgOriginal, 45)

t.scale(imgOriginal, 10)

t.correctPerspective(imgOriginal)

# 
cv.waitKey(0)
helper.closeAllWindows()