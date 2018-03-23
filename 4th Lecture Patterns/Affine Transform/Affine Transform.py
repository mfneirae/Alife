import cv2
import numpy as np

img = cv2.imread("monster.png")
rows, cols, ch = img.shape

cv2.circle(img, (155, 120), 5, (0, 0, 255), -1)
cv2.circle(img, (480, 120), 5, (0, 0, 255), -1)
cv2.circle(img, (20, 475), 5, (0, 0, 255), -1)
cv2.circle(img, (620, 475), 5, (0, 0, 255), -1)

pts1 = np.float32([[155, 120], [480, 120], [20, 475], [620, 475]])
pts2 = np.float32([[170, 230], [570, 210], [180, 560], [590, 560]])
matrix = cv2.getPerspectiveTransform(pts1, pts2)

result = cv2.warpPerspective(img, matrix, (600, 600))

cv2.imshow("img", img)
cv2.imshow("Perspective transformation", result)
cv2.waitKey(0)
cv2.destroyAllWindows()
