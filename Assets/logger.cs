using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logger : MonoBehaviour {

    private System.DateTime startGame;
    private string startGameString;
    private static string TrackerfilePath;
    private static string TargetSuccessLaserfilePath;
    private static string TargetFailLaserfilePath;
    private static string TargetSuccessTrackerfilePath;
    private static string TargetFailTrackerfilePath;
    public static Transform myTransform;

    // Use this for initialization
    void Start () {
        startGame = System.DateTime.Now;
        startGameString = startGame.ToString("dd-MM-yyyy-hh-mm-ss");
        TrackerfilePath = "Data/" + "TrackerCoords" + startGameString + ".txt";
        TargetFailTrackerfilePath = "Data/" + "TargetFailTracker" + startGameString + ".txt";
        TargetFailLaserfilePath = "Data/" + "TargetFailLaser" + startGameString + ".txt";

        TargetSuccessTrackerfilePath = "Data/" + "TargetSuccessTracker" + startGameString + ".txt";
        TargetSuccessLaserfilePath = "Data/" + "TargetSuccessLaser" + startGameString + ".txt";
        myTransform = transform; //assign myTransform instance to the static var

    }

    // Update is called once per frame
    void Update () {
        System.IO.File.AppendAllText(TrackerfilePath, Time.time.ToString()+','+ transform.position.x.ToString() + ',' + transform.position.y.ToString() + ',' + transform.position.z.ToString() + System.Environment.NewLine);
    }

    public static void logCoords(float logTime,Transform logTransform,bool success,float logDuration,float myScale)
    {
        if (success)
        {
            //log tracker location during balloon pop
            System.IO.File.AppendAllText(TargetSuccessTrackerfilePath, Time.time.ToString() + ',' + myScale.ToString() + ',' + logDuration.ToString() + ',' + myTransform.transform.position.x.ToString() + ',' + myTransform.position.y.ToString() + ',' + myTransform.position.z.ToString() + System.Environment.NewLine);
            //log actual location of balloon
            System.IO.File.AppendAllText(TargetSuccessLaserfilePath, logTime.ToString() + ',' + myScale.ToString() + ',' + logDuration.ToString() + ',' + logTransform.position.x.ToString() + ',' + logTransform.position.y.ToString() + ',' + logTransform.position.z.ToString() + System.Environment.NewLine);
        }
        else
        {
            //log tracker location when leaving balloon
            System.IO.File.AppendAllText(TargetFailTrackerfilePath, Time.time.ToString() + ',' + myScale.ToString() + ',' + logDuration.ToString() + ',' + myTransform.position.x.ToString() + ',' + myTransform.position.y.ToString() + ',' + myTransform.position.z.ToString() + System.Environment.NewLine);
            //log actual location of balloon 
            System.IO.File.AppendAllText(TargetFailLaserfilePath, logTime.ToString() + ',' + myScale.ToString() + ',' + logDuration.ToString() + ',' + logTransform.position.x.ToString() + ',' + logTransform.position.y.ToString() + ',' + logTransform.position.z.ToString() + System.Environment.NewLine);
        }
    }
}