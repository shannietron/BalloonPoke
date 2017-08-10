using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour {
    private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }
    private SteamVR_TrackedObject trackedObj;
    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
    public bool triggerButtonDown = false;
    public bool triggerButtonUp = false;
    public bool triggerButtonPressed = false;
    
    // Use this for initialization
    void Start () {

        trackedObj = GetComponent<SteamVR_TrackedObject>();
       
    }
	
	// Update is called once per frame
	void Update () {
        triggerButtonDown = controller.GetPressDown(triggerButton);
        triggerButtonUp = controller.GetPressUp(triggerButton);
        triggerButtonPressed = controller.GetPress(triggerButton);


        if (triggerButtonDown)
        {
            Debug.Log("Trigger Button was just pressed");
            laser.thickness += 0.0005f;

        }
        if (triggerButtonUp)
        {
            Debug.Log("Trigger Button was just unpressed");
        }

    }
}
