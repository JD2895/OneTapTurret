using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JD.Utils
{
    public class SpecMath
    {

        public static Vector2 GetXZComponents(float clockwiseAngleFromZaxis)
        {
            //Debug.Log(clockwiseAngleFromZaxis);
            float xComponent;
            float zComponent;
            int xMultiplier = -1;
            int zMultiplier = 1;

            if (Mathf.Abs(clockwiseAngleFromZaxis) >= 180)
            {
                zMultiplier *= -1;
                xMultiplier *= -1;
            }

            clockwiseAngleFromZaxis %= 180f;

            if (Mathf.Abs(clockwiseAngleFromZaxis) >= 90)
            {
                if (clockwiseAngleFromZaxis > 0)
                {
                    xMultiplier *= -1;
                }
                zMultiplier *= -1;
                clockwiseAngleFromZaxis %= 90;
            }
            else
            {
                if (clockwiseAngleFromZaxis > 0)
                {
                    xMultiplier *= -1;
                }
                clockwiseAngleFromZaxis = 90 - clockwiseAngleFromZaxis;
            }

            xComponent = Mathf.Cos(clockwiseAngleFromZaxis * Mathf.Deg2Rad);
            zComponent = Mathf.Sin(clockwiseAngleFromZaxis * Mathf.Deg2Rad);

            return new Vector2(xComponent * xMultiplier, zComponent * zMultiplier);
        }

        public static Vector2 GetScreenEdgePosition(ScreenSection screenSect, float percentFromCentre)
        {
            float xPosition = 0, zPosition = 0;
            float screenWidth = Screen.width;
            float screenHeight = Screen.height;
            float halfScreenWidth = Screen.width / 2;
            float halfScreenHeight = Screen.height / 2;
            float verticalOverflow = Screen.height / 4;

            //for calculations
            float totalHalfLength, widthPercent, heightPercent;

            switch (screenSect){
                case ScreenSection.Top:
                    zPosition = screenHeight;
                    xPosition = halfScreenWidth * percentFromCentre;
                    xPosition += halfScreenWidth;
                    break;
                case ScreenSection.Bottom:
                    zPosition = 0;
                    xPosition = halfScreenWidth * percentFromCentre;
                    xPosition += halfScreenWidth;
                    break;
                case ScreenSection.Right:
                    zPosition = halfScreenHeight * percentFromCentre;
                    zPosition += halfScreenHeight;
                    xPosition = screenWidth;
                    break;
                case ScreenSection.Left:
                    zPosition = halfScreenHeight * percentFromCentre;
                    zPosition += halfScreenHeight;
                    xPosition = 0;
                    break;
                case ScreenSection.TopOverflow:
                    totalHalfLength = halfScreenWidth + verticalOverflow;
                    widthPercent = halfScreenWidth / totalHalfLength;
                    
                    if (Mathf.Abs(percentFromCentre) <= widthPercent)
                    {
                        xPosition = percentFromCentre * totalHalfLength;
                        xPosition += halfScreenWidth;
                        zPosition = screenHeight;
                    }
                    else
                    {
                        xPosition = halfScreenWidth * (percentFromCentre / Mathf.Abs(percentFromCentre));
                        xPosition += halfScreenWidth;
                        zPosition = screenHeight - ((Mathf.Abs(percentFromCentre) * totalHalfLength) - halfScreenWidth);
                    }
                    break;
                case ScreenSection.BottomOverflow:
                    totalHalfLength = halfScreenWidth + verticalOverflow;
                    widthPercent = halfScreenWidth / totalHalfLength;

                    if (Mathf.Abs(percentFromCentre) <= widthPercent)
                    {
                        xPosition = percentFromCentre * totalHalfLength;
                        xPosition += halfScreenWidth;
                        zPosition = 0;
                    }
                    else
                    {
                        xPosition = halfScreenWidth * (percentFromCentre / Mathf.Abs(percentFromCentre));
                        xPosition += halfScreenWidth;
                        zPosition = ((Mathf.Abs(percentFromCentre) * totalHalfLength) - halfScreenWidth);
                    }
                    break;
                case ScreenSection.All:
                    // In this case, 'percentFromCentre' will be considered the bottom-right of the screen
                    totalHalfLength = Screen.width + Screen.height;
                    widthPercent = screenWidth / totalHalfLength;
                    heightPercent = screenHeight / totalHalfLength;
                    if (percentFromCentre < -heightPercent)     // top of screen
                    {
                        xPosition = (percentFromCentre * totalHalfLength) + screenHeight;
                        xPosition += screenWidth;
                        zPosition = screenHeight;
                    }
                    else if (percentFromCentre < 0)             // right of screen
                    {
                        xPosition = screenWidth; 
                        zPosition = Mathf.Abs(percentFromCentre) * totalHalfLength;
                    }
                    else if (percentFromCentre < widthPercent)  // bottom of screen
                    {
                        xPosition = screenWidth - (percentFromCentre * totalHalfLength);
                        zPosition = 0;
                    }
                    else                                        // left of screen
                    {
                        xPosition = 0;
                        zPosition = (percentFromCentre * totalHalfLength) - screenWidth;
                    }
                    break;
            }

            return new Vector2(xPosition, zPosition);
        }
    }

    public enum EnemyType
    {
        basic = 0,
        spiral = 1
    }

    public enum ScreenSection
    {
        All = 0,
        Top = 1,
        Bottom = 2,
        Right = 3,
        Left = 4,
        TopOverflow = 5,
        //TopUnderflow,
        BottomOverflow = 6,
        //BottomUnderflow
    }
}
