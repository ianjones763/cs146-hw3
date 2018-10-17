using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    Image timerBar;
    public float maxTime = 5f;
    public float timeReward = 10f;
    public static bool timeAdd;
    public static float timeLeft;
    public GameObject timesUpText;

	// Use this for initialization
	void Start () {
        timesUpText.SetActive(false);
        timerBar = GetComponent<Image>();
        timeLeft = maxTime;
        timeAdd = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (timeLeft > 0) {
            timeLeft -= Time.deltaTime;
            if (timeAdd) {
                timeLeft += timeReward;
            }
            timeAdd = false;
            timerBar.fillAmount = timeLeft / maxTime;
        } else {
            timesUpText.SetActive(true);
            Time.timeScale = 0;
        }
	}
}
