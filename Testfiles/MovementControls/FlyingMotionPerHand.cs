using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using Valve.VR;


public class FlyingMotionPerHand : MonoBehaviour
{

  public  float forceMult = 1;
  public float torqueMult = 1;

    public Transform centerOfMass;
    public Rigidbody playArea;

    public SteamVR_Action_Single CurrentTriggerValue;
    public Hand thisHand;
    public SteamVR_Behaviour_Pose handPose;

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

    private void FixedUpdate()
    {
        SteamVR_Action_Boolean pulltriggeraction = SteamVR_Input.GetBooleanAction("TrigPull");
        bool trigstate = pulltriggeraction.GetState(handPose.inputSource);

        if(trigstate)
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

        //    if (thisHand == null)
        //        thisHand = this.GetComponent<Hand>();

        //    CurrentTriggerValue.AddOnChangeListener(FlightChosing, thisHand.handType);
        //
    }

    private void OnDisable()
    {
        //if (CurrentTriggerValue != null)
        //    CurrentTriggerValue.RemoveOnChangeListener(FlightChosing, thisHand.handType);
    }

    //public void FlightChosing(ISteamVR_Action_Single action_In, SteamVR_Input_Sources inputsource, float newvalue, float newdelta )
    //{
    //    if(CurrentTriggerValue.GetChanged(thisHand.handType))
    //    {

    //    }
    //}
}
