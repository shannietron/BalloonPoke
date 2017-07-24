using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour {

    public static int score;
    Text text;

    void Awake () {
        text = GetComponentInChildren<Text>();
        Debug.Log(text.text);
        score = 0;
		
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(score);
        text.text = "Score "+ score;
        
	}
}
    