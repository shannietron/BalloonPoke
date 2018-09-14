using System.Collections; 
using System.Collections.Generic;
using UnityEngine;
public class timeCollision : MonoBehaviour {

    public  float delayDestroy; //time in seconds before balloon gets destroyed
    public  float delayThreshold;
    private float duration = 0;
    private Renderer rend;
    private Shader originalShader;
    private Shader highlightShader;
    private float myScale;

    // Use this for initialization
    void Start () {
        highlightShader = Shader.Find("Flare");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setBalloonParams(float threshold,float destroy,float scale)
    {
        delayDestroy = destroy;
        delayThreshold = threshold;
        myScale = scale;

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
            logger.logCoords(Time.time, transform, false,duration,myScale); //failed to destroy balloon
        }
        duration = 0;
    }



    void OnTriggerStay(Collider other)
    {
        duration = Time.deltaTime + duration;
        //Debug.Log(duration);
        if(duration > delayDestroy)
        {

            logger.logCoords(Time.time, transform,true,duration,myScale); //successfully destroyed balloon
            duration = 0;
            SendMessageUpwards("ApplyDamage", SendMessageOptions.DontRequireReceiver);
        }
    }


}
