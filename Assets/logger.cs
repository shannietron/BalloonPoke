using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logger : MonoBehaviour {

    private System.DateTime startGame;
    private string startGameString;
    private static string TrackerfilePath;
    private static string TargetSuccessfilePath;
    private static string TargetFailfilePath;

    // Use this for initialization
    void Start () {
        startGame = System.DateTime.Now;
        startGameString = startGame.ToString("dd-MM-yyyy-hh-mm-ss");
        TrackerfilePath = "Data/" + "TrackerCoords" + startGameString + ".txt";
        TargetFailfilePath = "Data/" + "TargetFail" + startGameString + ".txt";
        TargetSuccessfilePath = "Data/" + "TargetSuccess" + startGameString + ".txt";
    }
	
	// Update is called once per frame
	void Update () {
        System.IO.File.AppendAllText(TrackerfilePath, Time.time.ToString()+','+ transform.position.x.ToString() + ',' + transform.position.y.ToString() + ',' + transform.position.z.ToString() + System.Environment.NewLine);
    }

    public static void logCoords(float logTime,Transform logTransform,bool success,float logDuration=0)
    {
        if (success)
        {
            System.IO.File.AppendAllText(TargetSuccessfilePath, logTime.ToString() + ',' + logTransform.position.x.ToString() + ',' + logTransform.position.y.ToString() + ',' + logTransform.position.z.ToString() + System.Environment.NewLine);
        }
        else
        {
            System.IO.File.AppendAllText(TargetFailfilePath, logTime.ToString() + ',' + logDuration.ToString() + ',' + logTransform.position.x.ToString() + ',' + logTransform.position.y.ToString() + ',' + logTransform.position.z.ToString() + System.Environment.NewLine);
        }
    }
}