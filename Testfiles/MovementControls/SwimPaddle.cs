using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Valve.VR;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class SwimPaddle : MonoBehaviour {

    public float forceMult = 1;
    public float torqueMult = 1;

    public Transform centerOfMass;
	public Rigidbody playArea;

	public enum SwimButton {
		Trigger,
		Grip,
		TrackPress,
		Menu
	}

    public SwimButton swimButton = SwimButton.Trigger;
     
    public bool secondInputPressed = false;
    [Tooltip ("Optional: If this is filled with another SwimButton object, both need to be triggered to produce force.")]
	public SwimPaddle partnerPaddle;

	[HideInInspector]
	public bool isSwimming = false;
	[HideInInspector]
	public bool isTriggered = false;

 // SteamVR_Controller.Device device;
  SteamVR_TrackedObject trackedObj;

    private Vector3 controllerForce;
    private Vector3 controllerDistance;
    private Vector3 controllerTorque;

	private Vector3 lastControllerPositionGolbal;
	private Vector3 lastControllerPositionLocal;

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }
 

  //  void FixedUpdate()
  //  {
  //      device = SteamVR_Controller.Input((int)trackedObj.index);

  //      //print("Grip: " + device.GetTouch(SteamVR_Controller.ButtonMask.Grip));

  //      if(device == null)
  //      {
  //          Debug.Log("Device not found");
  //      }

		//ulong triggerButton = SteamVR_Controller.ButtonMask.Trigger;
 

		//switch (swimButton) {
		//case SwimButton.Trigger:
		//	triggerButton = SteamVR_Controller.ButtonMask.Trigger;
		//	break;
		//case SwimButton.Grip:
		//	triggerButton = SteamVR_Controller.ButtonMask.Grip;
		//	break;
		//case SwimButton.TrackPress:
		//	triggerButton = SteamVR_Controller.ButtonMask.Touchpad;
		//	break;
		//case SwimButton.Menu:
		//	triggerButton = SteamVR_Controller.ButtonMask.ApplicationMenu;
		//	break;
		//}


  //      //second type of input for button

  //      if (device.GetTouch (triggerButton)) {

		//	isTriggered = true;

		//	if (partnerPaddle == null || partnerPaddle.isTriggered) {

		//		isSwimming = true;

		//		// float triggerVal = Mathf.Pow(device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger).x, 2f);

		//		Vector3 globalVelocity = (transform.position - lastControllerPositionGolbal) / Time.fixedDeltaTime;
		//		Vector3 localVelocity = (transform.localPosition - lastControllerPositionLocal) / Time.fixedDeltaTime;

		//		float globalSpeed = globalVelocity.magnitude;
		//		globalVelocity.Normalize ();

		//		float localSpeed = localVelocity.magnitude;
		//		localVelocity.Normalize ();

		//		float velAdjustment = (Vector3.Dot (globalVelocity, localVelocity) + 1.3f) / 2.3f;

		//		float finalSpeed = Mathf.Lerp (globalSpeed, localSpeed, velAdjustment);

		//		controllerForce = globalVelocity * finalSpeed * -forceMult;// * triggerVal;
		//		controllerDistance = transform.position - centerOfMass.position;
		//		//controllerTorque = Vector3.Cross (controllerDistance, controllerForce / forceMult * torqueMult);


		//		playArea.AddForce (controllerForce);
		//		//playArea.AddTorque (controllerTorque);
		//	} else {
		//		isSwimming = false;
		//	}

            
		//} else {
		//	isSwimming = false;
		//	isTriggered = false;
		//}

  //      lastControllerPositionGolbal = transform.position;
		//lastControllerPositionLocal = transform.localPosition;

  //  }

}
