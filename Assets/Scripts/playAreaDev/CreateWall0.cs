using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum WhichHand { left, right};

public class CreateWall0 : MonoBehaviour
{
    public GameObject makeObj;
    public Transform Textbox1;
    public Transform Textbox2;
    public float DistanceFromWall = .5f;
    public Vector3 ArmDirection;
    public WhichHand CurrentHandHit;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
       

        if (other.CompareTag("hands"))
        {
            WhichHand(other);

        }

    }


    void WhichHand(Collider col)
    {
        Vector3 vec3 = col.transform.position;
        vec3.z += DistanceFromWall;

        HandWallInteraction wallInteract = col.GetComponent<HandWallInteraction>();
        GameObject obj = Instantiate(makeObj, vec3, col.transform.rotation);
        obj.GetComponent<CreateBall>().direction = wallInteract.Direction;

    }
}
