using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCharacterAttack : MonoBehaviour
{
    public GameObject attack;
    public Transform CreatePoint;
    public float Speed = 10f;


    public void DoAttack()
    {
        GameObject obj = Instantiate(attack, CreatePoint.position, Quaternion.identity);
        Rigidbody rbody = obj.GetComponent<Rigidbody>();
        rbody.velocity = CreatePoint.forward * Speed;
    }
}
