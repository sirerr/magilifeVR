using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform PlayerTransform;

    float StartHeightDistance = 0;
    public float movespeed = 3f;
   Vector3 VecOffset;
    private void Awake()
    {
        VecOffset = transform.position - PlayerTransform.position;
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position, PlayerTransform.position + VecOffset, Time.deltaTime * movespeed);

        transform.LookAt(PlayerTransform, Vector3.up);
    }
}
