using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    public float transitionTimer = 3.0f;
    public GameObject FadePanel;

    void Update()
    {
        transitionTimer -= Time.deltaTime;
        var tempColour = FadePanel.GetComponent<Image>().color;
        float fadeAlpha = Mathf.Lerp(0, 1, transitionTimer);
        tempColour.a = fadeAlpha;
        FadePanel.GetComponent<Image>().color = tempColour;
        if (transitionTimer <= 0)
        {
            Destroy(FadePanel);
        }
    }
}
