using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using Valve.VR;

public class WorldPainter : MonoBehaviour
{
    public GameObject Floor;
    public Transform Emitter;
    int LayerMask = 1 << 9 | 1<<10;
   //bool Emit = false;

    public SteamVR_Behaviour_Pose handPose;
    // Start is called before the first frame update
    void Start()
    {
        if (handPose == null)
            handPose = GetComponent<SteamVR_Behaviour_Pose>();

    }

    // Update is called once per frame
    void Update()
    {
        SteamVR_Action_Boolean pulltriggeraction = SteamVR_Input.GetBooleanAction("GripPull");

        bool GripperState = pulltriggeraction.GetState(handPose.inputSource);


        if (GripperState)
        {

            RaycastHit hit;
            if (Physics.Raycast(Emitter.position, Emitter.forward, out hit, Mathf.Infinity, LayerMask))
            {
                if (hit.transform.CompareTag("WorldFloor"))
                {

                }
                else
                {
                    Quaternion rot = Quaternion.LookRotation(hit.normal);
                    Vector3 spot = hit.point;
                    spot.y += .02f;
                    Instantiate(Floor, spot, Quaternion.Inverse(rot));
                }
            }


        }

    }
}
