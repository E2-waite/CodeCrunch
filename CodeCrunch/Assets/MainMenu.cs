using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    float transitionTimer = 2.0f;
    bool sceneChangePlay = false;
    bool sceneChangeMenu = false;
    bool sceneChangeWinner = false;
    public GameObject FadePanel;

    private void Update()
    {
        if(sceneChangePlay)
        {
            transitionTimer -= Time.deltaTime;
            var tempColour = FadePanel.GetComponent<Image>().color;
            float fadeAlpha = Mathf.Lerp(1, 0, transitionTimer);
            tempColour.a = fadeAlpha;
            FadePanel.GetComponent<Image>().color = tempColour;
            if (transitionTimer <= 0)
            {
                sceneChangePlay = false;
                SceneManager.LoadScene(1);
                AudioManager.instance.Play("menu_selection");
            }
        }

        if(sceneChangeMenu)
        {
            transitionTimer -= Time.deltaTime;
            var tempColour = FadePanel.GetComponent<Image>().color;
            float fadeAlpha = Mathf.Lerp(1, 0, transitionTimer);
            tempColour.a = fadeAlpha;
            FadePanel.GetComponent<Image>().color = tempColour;
            if (transitionTimer <= 0)
            {
                sceneChangePlay = false;
                SceneManager.LoadScene(0);
                AudioManager.instance.Play("menu_selection");
            }
        }

        if (sceneChangeWinner)
        {
            transitionTimer -= Time.deltaTime;
            var tempColour = FadePanel.GetComponent<Image>().color;
            float fadeAlpha = Mathf.Lerp(1, 0, transitionTimer);
            tempColour.a = fadeAlpha;
            FadePanel.GetComponent<Image>().color = tempColour;
            if (transitionTimer <= 0)
            {
                sceneChangePlay = false;
                SceneManager.LoadScene(0);
                AudioManager.instance.Play("menu_selection");
            }
        }

    }

    public void PlayGame()
    {
        FadePanel.SetActive(true);
        sceneChangePlay = true;
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void ReturnMenu()
    {
        FadePanel.SetActive(true);
        sceneChangeMenu = true;
    }
}
