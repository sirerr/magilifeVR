using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using Valve.VR;
using OVR;


public class FlyingMotionPerHand : MonoBehaviour
{
 
    public enum HMDChoice { Oculus, Vive };
    public HMDChoice CurrentHMD;

    //the Vive parts
    SteamVR_Behaviour_Pose handPose;
    bool TriggerCurrentState = false;
    //oculus
    public OVRInput.Controller controller;

    public  float forceMult = 1;
    public float torqueMult = 1;

    public Transform centerOfMass;
    public Rigidbody playArea;
    
    // From Old System
    public bool secondInputPressed = false;

    public FlyingMotionPerHand partnerPaddle;
   
    [HideInInspector]
    public bool isSwimming = false;
    [HideInInspector]
    public bool isTriggered = false;
    
    private Vector3 controllerForce;
    private Vector3 controllerDistance;
    private Vector3 controllerTorque;

    private Vector3 lastControllerPositionGolbal;
    private Vector3 lastControllerPositionLocal;

    //

    public void Update()
    {
        switch(CurrentHMD)
        {
            case HMDChoice.Oculus:
                TriggerCurrentState = OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, controller);

                break;
            case HMDChoice.Vive:
                //vive part
                SteamVR_Action_Boolean pulltriggeraction = SteamVR_Input.GetBooleanAction("TrigPull");
                TriggerCurrentState = pulltriggeraction.GetState(handPose.inputSource);
                break;

        }

        print(TriggerCurrentState + " on " + controller.ToString());
    }

    private void FixedUpdate()
    {        

        if(TriggerCurrentState)
        {
            isTriggered = true;

            if (partnerPaddle == null || partnerPaddle.isTriggered)
            {

                isSwimming = true;
                
                
                Vector3 globalVelocity = (transform.position - lastControllerPositionGolbal) / Time.fixedDeltaTime;
                Vector3 localVelocity = (transform.localPosition - lastControllerPositionLocal) / Time.fixedDeltaTime;

                float globalSpeed = globalVelocity.magnitude;
                globalVelocity.Normalize();

                float localSpeed = localVelocity.magnitude;
                localVelocity.Normalize();

                float velAdjustment = (Vector3.Dot(globalVelocity, localVelocity) + 1.3f) / 2.3f;

                float finalSpeed = Mathf.Lerp(globalSpeed, localSpeed, velAdjustment);

                controllerForce = globalVelocity * finalSpeed * -forceMult;
                controllerDistance = transform.position - centerOfMass.position;
              

                playArea.AddForce(controllerForce);
                //playArea.AddTorque (controllerTorque);
            }
            else
            {
                isSwimming = false;
            }


        }
        else
        {
            isSwimming = false;
            isTriggered = false;
        }

        lastControllerPositionGolbal = transform.position;
        lastControllerPositionLocal = transform.localPosition;

    }

    private void OnEnable()
    {
        if (handPose == null)
            handPose = GetComponent<SteamVR_Behaviour_Pose>();
    }

    private void OnDisable()
    { 
    }

 
}
