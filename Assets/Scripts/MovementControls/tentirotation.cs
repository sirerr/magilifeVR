using UnityEngine;
using System.Collections;

public class tentirotation : MonoBehaviour {

	public float rotSpeed = 45;

	void Update()

	{
		transform.Rotate(transform.forward * rotSpeed *Time.deltaTime);
	}

}
