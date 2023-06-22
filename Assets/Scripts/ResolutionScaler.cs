using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionScaler : MonoBehaviour
{
    private int referenceWidth = 1366;
    private int referenceHeight = 768;
    private void Start()
    {
        int screenWidth = Screen.width;
        int screenHeight = Screen.height;
        float scaleFactorX = (float)screenWidth / referenceWidth;
        float scaleFactorY = (float)screenHeight / referenceHeight;
        RectTransform[] uiElements = GetComponentsInChildren<RectTransform>(true);
        foreach (RectTransform element in uiElements)
        {
            // Preserve the original position and size of the UI element
            Vector3 originalPosition = element.localPosition;
            Vector2 originalSize = element.sizeDelta;

            // Apply the scale factor
            element.localScale = new Vector3(scaleFactorX, scaleFactorY, 1f);

            // Restore the original position and size by scaling them back
            element.localPosition = new Vector3(originalPosition.x / scaleFactorX, originalPosition.y / scaleFactorY, originalPosition.z);
            element.sizeDelta = new Vector2(originalSize.x / scaleFactorX, originalSize.y / scaleFactorY);
        }
    }

}
