using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JD.Utils
{
    public class SpecMath
    {

        public static Vector2 GetXYComponents(float angleFromYaxis)
        {
            float xComponent;
            float yComponent;
            int xMultiplier = 1;
            int yMultiplier = 1;

            if (Mathf.Abs(angleFromYaxis) >= 180)
            {
                yMultiplier *= -1;
                xMultiplier *= -1;
            }

            angleFromYaxis %= 180f;

            if (Mathf.Abs(angleFromYaxis) >= 90)
            {
                if (angleFromYaxis > 0)
                {
                    xMultiplier *= -1;
                }
                yMultiplier *= -1;
                angleFromYaxis %= 90;
            }
            else
            {
                if (angleFromYaxis > 0)
                {
                    xMultiplier *= -1;
                }
                angleFromYaxis = 90 - angleFromYaxis;
            }

            xComponent = Mathf.Cos(angleFromYaxis * Mathf.Deg2Rad);
            yComponent = Mathf.Sin(angleFromYaxis * Mathf.Deg2Rad);

            return new Vector2(xComponent * xMultiplier, yComponent * yMultiplier);
        }

        public static Vector2 GetScreenEdgePosition(ScreenSection screenSect, float percentFromCentre)
        {
            float xPosition = 0, yPosition = 0;
            float screenWidth = Screen.width;
            float screenHeight = Screen.height;
            float halfScreenWidth = Screen.width / 2;
            float halfScreenHeight = Screen.height / 2;
            float verticalOverflow = Screen.height / 4;

            //for calculations
            float totalHalfLength, widthPercent, heightPercent;

            switch (screenSect){
                case ScreenSection.Top:
                    yPosition = screenHeight;
                    xPosition = halfScreenWidth * percentFromCentre;
                    xPosition += halfScreenWidth;
                    break;
                case ScreenSection.Bottom:
                    yPosition = 0;
                    xPosition = halfScreenWidth * percentFromCentre;
                    xPosition += halfScreenWidth;
                    break;
                case ScreenSection.Right:
                    yPosition = halfScreenHeight * percentFromCentre;
                    yPosition += halfScreenHeight;
                    xPosition = screenWidth;
                    break;
                case ScreenSection.Left:
                    yPosition = halfScreenHeight * percentFromCentre;
                    yPosition += halfScreenHeight;
                    xPosition = 0;
                    break;
                case ScreenSection.TopOverflow:
                    totalHalfLength = halfScreenWidth + verticalOverflow;
                    widthPercent = halfScreenWidth / totalHalfLength;
                    
                    if (Mathf.Abs(percentFromCentre) <= widthPercent)
                    {
                        xPosition = percentFromCentre * totalHalfLength;
                        xPosition += halfScreenWidth;
                        yPosition = screenHeight;
                    }
                    else
                    {
                        xPosition = halfScreenWidth * (percentFromCentre / Mathf.Abs(percentFromCentre));
                        xPosition += halfScreenWidth;
                        yPosition = screenHeight - ((Mathf.Abs(percentFromCentre) * totalHalfLength) - halfScreenWidth);
                    }
                    break;
                case ScreenSection.BottomOverflow:
                    totalHalfLength = halfScreenWidth + verticalOverflow;
                    widthPercent = halfScreenWidth / totalHalfLength;

                    if (Mathf.Abs(percentFromCentre) <= widthPercent)
                    {
                        xPosition = percentFromCentre * totalHalfLength;
                        xPosition += halfScreenWidth;
                        yPosition = 0;
                    }
                    else
                    {
                        xPosition = halfScreenWidth * (percentFromCentre / Mathf.Abs(percentFromCentre));
                        xPosition += halfScreenWidth;
                        yPosition = ((Mathf.Abs(percentFromCentre) * totalHalfLength) - halfScreenWidth);
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
                        yPosition = screenHeight;
                    }
                    else if (percentFromCentre < 0)             // right of screen
                    {
                        xPosition = screenWidth; 
                        yPosition = Mathf.Abs(percentFromCentre) * totalHalfLength;
                    }
                    else if (percentFromCentre < widthPercent)  // bottom of screen
                    {
                        xPosition = screenWidth - (percentFromCentre * totalHalfLength);
                        yPosition = 0;
                    }
                    else                                        // left of screen
                    {
                        xPosition = 0;
                        yPosition = (percentFromCentre * totalHalfLength) - screenWidth;
                    }
                    break;
            }

            return new Vector2(xPosition, yPosition);
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
