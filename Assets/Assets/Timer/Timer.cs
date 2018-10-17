using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    Image timerBar;
    public float maxTime = 5f;
    public static float timeLeft;
    public GameObject timesUpText;

	// Use this for initialization
	void Start () {
        timesUpText.SetActive(false);
        timerBar = GetComponent<Image>();
        timeLeft = maxTime;
	}
	
	// Update is called once per frame
	void Update () {
        if (timeLeft > 0) {
            timeLeft -= Time.deltaTime;
            timerBar.fillAmount = timeLeft / maxTime;
            //Debug.Log("timeLeft = " + timeLeft);
        } else {
            timesUpText.SetActive(true);
            Time.timeScale = 0;
        }
	}
}
