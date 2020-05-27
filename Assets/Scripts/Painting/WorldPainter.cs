using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldPainter : MonoBehaviour
{
    public GameObject Floor;
    public Transform Emitter;
    int LayerMask = 1 << 9 | 1<<10;

    // Start is called before the first frame update
    void Start()
    {
        Emitter = transform;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetMouseButtonDown(0))
        {

            RaycastHit hit;
            if(Physics.Raycast(Emitter.position,Emitter.forward,out hit, Mathf.Infinity,LayerMask))
            {
                if(hit.transform.CompareTag("WorldFloor"))
                {

                }
                else
                {
                    Quaternion rot = Quaternion.LookRotation(hit.normal);
                    Vector3 spot = hit.point;
                    spot.y += .1f;
                    Instantiate(Floor, spot,Quaternion.Inverse(rot));
                }
            }


        }

    }
}
