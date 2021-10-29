using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateWall0 : MonoBehaviour
{
    public GameObject makeObj;

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
        GameObject obj = Instantiate(makeObj, other.transform.position, other.transform.rotation);

    }
}
