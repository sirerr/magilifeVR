using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoulderHelpers : MonoBehaviour
{
    public float shoulderspot=.3f;
    public GameObject leftShoulder;
    public GameObject rightShoulder;
    Vector3 leftPos;
    Vector3 rightPos;
    public GameObject points;
    public Transform forwardWall;

    // Start is called before the first frame update
    void Awake()
    {
        
        leftShoulder = Instantiate(points);
        rightShoulder  = Instantiate(points);
        leftShoulder.transform.parent = forwardWall;
        rightShoulder.transform.parent = forwardWall;
    }

    // Update is called once per frame
    void Update()
    {
        leftPos = transform.position;
        rightPos = transform.position;
        leftPos.y = transform.position.y - shoulderspot;
        rightPos.y = transform.position.y - shoulderspot;
        rightPos.x = transform.position.x + shoulderspot;
        leftPos.x = transform.position.x - shoulderspot;

        leftShoulder.transform.position = leftPos;
        rightShoulder.transform.position = rightPos;


    }
}
