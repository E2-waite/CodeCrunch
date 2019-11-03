using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownText : MonoBehaviour
{
    private Text countdownText;

    //change size
    public float currentTime = 0.0f;
    public float countdown;
    public float goCountdown = 1.0f;

    public float lerpTimer = 0f;
    public float lerpSpeed = 1.0f;

    private bool sound1 = false;
    private bool sound2 = false;
    private bool sound3 = false;
    private bool sound4 = false;

    private void Start()
    {
        countdownText = GetComponent<Text>();
        countdownText.text = GetComponentInParent<Countdown>().countdown.ToString();
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {        
        //if(countdown <= 10 && countdown >= 1)
        //{
        //    int countdownInt = (int)countdown;
        //    countdownText.text = countdownInt.ToString();
        //}
        //else if(countdown <= 1)
        //{
        //    countdownText.text = "Go!";
        //    countdownText.fontSize = (int)Mathf.Lerp(50, 300, lerpTimer);
        //    lerpTimer += Time.fixedDeltaTime;
        //    if (lerpTimer >= 1)
        //    {
        //        Destroy(countdownText.gameObject);
        //    }
        //}
        //else
        //{
        //    countdownText.text = "";
        //}

        if(countdown <= 4 && countdown >= 3 && !sound1)
        {
            sound1 = true;
            AudioManager.instance.Play("countdown");
        }
        else if(countdown <= 3 && countdown >= 2 && !sound2)
        {
            sound2 = true;
            AudioManager.instance.Play("countdown");
        }
        else if (countdown <= 2 && countdown >= 1 && !sound3)
        {
            sound3 = true;
            AudioManager.instance.Play("countdown");
        }
        else if (countdown <= 1 && countdown >= 0 && !sound4)
        {
            sound4 = true;
            AudioManager.instance.Play("go");
        }

        if (countdown <= 0)
        {
            Destroy(countdownText.gameObject);
        }

        countdown -= Time.deltaTime;


    }
}
