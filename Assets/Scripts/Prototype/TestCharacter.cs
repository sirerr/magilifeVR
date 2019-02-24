using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCharacter : MonoBehaviour
{
    Rigidbody rbody;
    public float WalkSpeed =2f;
    public float JumpAmount = 2f;


    float startRotx;
    float startRotz;
    bool buttonsPressed = false;
    TestCharacterAttack AttackRef;

    private void Awake()
    {
        rbody = GetComponent<Rigidbody>();
        startRotx = transform.rotation.x;
        startRotz = transform.rotation.z;
        AttackRef = GetComponent<TestCharacterAttack>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float hor;
        float ver;



        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");
       // print(hor + " " + ver);
        rbody.AddRelativeForce(new Vector3(hor, 0, ver) * WalkSpeed);

        if(buttonsPressed)
        {
            print(buttonsPressed);
            rbody.AddRelativeForce(transform.up * JumpAmount,ForceMode.Impulse);
            buttonsPressed = false;
        }
  
        
    }

    private void Update()
    {
        Vector2 screenpoint;
        screenpoint = Input.mousePosition;
        Camera cam = Camera.main;
        Vector3 point;

        point = cam.ScreenToWorldPoint(new Vector3(screenpoint.x, screenpoint.y, cam.transform.forward.z * 50f));
        transform.LookAt(point, Vector3.up);
        Quaternion rot = transform.rotation;
        rot = new Quaternion(startRotx, rot.y, startRotz, rot.w);
        transform.rotation = rot;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            buttonsPressed = true;
        }

        if(Input.GetMouseButtonDown(0))
        {
            AttackRef.DoAttack();
        }
    }


}
