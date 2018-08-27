using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeCollision : MonoBehaviour {

    public static int numFrames = 45; //number of frames to capture @ 90fps, 45=0.5sec
    private int count = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}



    private void OnTriggerEnter(Collider other)
    {
        GetComponent<Renderer>().material.color = Color.green;
        //Debug.Log(gameObject.name + "was triggered by!" + other.gameObject.name);
        count = 0;
    }

    private void OnTriggerExit(Collider other)
    {
        GetComponent<Renderer>().material.color = Color.red;
        //Debug.Log(gameObject.name + "was triggered by!" + other.gameObject.name);
        count = 0;

    }



    void OnTriggerStay(Collider other)
    {
       count++;
        //Debug.Log("count:" + count);
        Transform trans = other.transform;
        if (count == numFrames)
        {
            count = 0;
            SendMessageUpwards("ApplyDamage", SendMessageOptions.DontRequireReceiver);
        }

    }


}
