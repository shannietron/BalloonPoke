using System.Collections; 
using System.Collections.Generic;
using UnityEngine;

public class timeCollision : MonoBehaviour {

    public static float delayDestroy = 0.2f; //time in seconds before balloon gets destroyed
    public static float delayThreshold = 0.1f;
    private float duration = 0;
    private Renderer rend;
    private Shader originalShader;
    private Shader highlightShader;

    // Use this for initialization
    void Start () {
        highlightShader = Shader.Find("Flare");

    }
	
	// Update is called once per frame
	void Update () {
		
	}



    private void OnTriggerEnter(Collider other)
    {
        originalShader = GetComponent<Renderer>().material.shader;
        GetComponent<Renderer>().material.shader = highlightShader;
        //Debug.Log(gameObject.name + "was triggered by!" + other.gameObject.name);
        duration = 0;
    }

    private void OnTriggerExit(Collider other)
    {
        GetComponent<Renderer>().material.shader = originalShader;
        //Debug.Log(gameObject.name + "was triggered by!" + other.gameObject.name);
        if (duration > delayThreshold)
        {
            logger.logCoords(Time.time, transform, false,duration); //failed to destroy balloon
        }
        duration = 0;
    }



    void OnTriggerStay(Collider other)
    {
        duration = Time.deltaTime + duration;
        //Debug.Log(duration);
        if(duration > delayDestroy)
        {
            duration = 0;
            logger.logCoords(Time.time, transform,true); //successfully destroyed balloon
            SendMessageUpwards("ApplyDamage", SendMessageOptions.DontRequireReceiver);
        }
    }


}
