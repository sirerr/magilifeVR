using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandWallInteraction : MonoBehaviour
{
    public WhichHand currentHand;
    public GameObject ShoulderSpot;
    public Vector3 Direction;
    private void Update()
    {
        Direction = transform.position - ShoulderSpot.transform.position;
    }
}
