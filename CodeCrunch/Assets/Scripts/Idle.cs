using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Idle : MonoBehaviour
{
    public float idleTimer = 15;
    public float transitionTimer = 2.0f;
    bool sceneChangeIdle = false;
    public GameObject FadePanel;
    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount == 0)
        {
            idleTimer -= Time.deltaTime;
        }
        else
        {
            idleTimer = 60;
        }

        if(idleTimer <= 0)
        {
            sceneChangeIdle = true;
        }

        if (sceneChangeIdle)
        {
            transitionTimer -= Time.deltaTime;
            var tempColour = FadePanel.GetComponent<Image>().color;
            float fadeAlpha = Mathf.Lerp(1, 0, transitionTimer);
            tempColour.a = fadeAlpha;
            FadePanel.GetComponent<Image>().color = tempColour;
            if (transitionTimer <= 0)
            {
                sceneChangeIdle = false;
                SceneManager.LoadScene(0);
            }
        }
    }
}
