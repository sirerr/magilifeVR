using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBall : MonoBehaviour
{
    public float LifeTime = 2f;
    public float speed = 5f;
    Rigidbody rbody;
    public Vector3 direction;

    private void Awake()
    {
        rbody = GetComponent<Rigidbody>();
        StartCoroutine(Life());
    }

    private void FixedUpdate()
    {
        rbody.AddForce(transform.forward * speed,ForceMode.Force);
    }

    IEnumerator Life()
    {
        yield return new WaitForSeconds(LifeTime);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
