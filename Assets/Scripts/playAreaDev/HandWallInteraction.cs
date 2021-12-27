using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandWallInteraction : MonoBehaviour
{
    public WhichHand currentHand;
    public GameObject ShoulderSpot;
    public Vector3 Direction;
    public shoulderHelpers shoulderRef;
    public void Start()
    {
        if(currentHand == WhichHand.left)
        {
            ShoulderSpot = shoulderRef.leftShoulder;
        }else
        {
            ShoulderSpot = shoulderRef.rightShoulder;
        }
    }
    private void Update()
    {
        Direction = transform.position - ShoulderSpot.transform.position;
    }
}
