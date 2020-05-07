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
            }
        }

    }

    public void PlayGame()
    {
        AudioManager.instance.Play("gamestart");
        FadePanel.SetActive(true);
        sceneChangePlay = true;
    }

    public void QuitGame()
    {

        AudioManager.instance.Play("menu_selection");
        Debug.Log("Quit");
        Application.Quit();
    }

    public void ReturnMenu()
    {
        AudioManager.instance.Play("menu_selection");
        AudioManager.instance.Play("background_song");
        FadePanel.SetActive(true);
        sceneChangeMenu = true;
    }

    public void MenuSelection()
    {
        AudioManager.instance.Play("menu_selection");
    }
}
