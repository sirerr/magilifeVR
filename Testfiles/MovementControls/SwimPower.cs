using UnityEngine;
using System.Collections;

public class SwimPower : MonoBehaviour {

	public float depleteTime = 5f;
	public float rechargeTime = 15f;

	[Range (0.0f, 1.0f)]
	public float lowPowerPercent = 0.1f;

	[HideInInspector]
	public float actualPowerPercent = 1.0f;

	private SwimPaddle swimPaddle;
	private float startPower;

	// Use this for initialization
	void Start () {
		swimPaddle = GetComponent<SwimPaddle> ();

		if (swimPaddle == null) {
			Debug.LogWarning ("A SwimPaddle script must be attached to this object!");
			return;
		}

		startPower = swimPaddle.forceMult;
	}
	
	// Update is called once per frame
	void Update () {
		if (swimPaddle != null && swimPaddle.isSwimming) {
			if (swimPaddle.forceMult > swimPaddle.forceMult * lowPowerPercent) {
				swimPaddle.forceMult -= startPower * (1 - lowPowerPercent) / depleteTime * Time.deltaTime;
			} else {
				swimPaddle.forceMult = swimPaddle.forceMult * lowPowerPercent;
			}
		} else if (!swimPaddle.isSwimming) {
			if (swimPaddle.forceMult < startPower) {
				swimPaddle.forceMult += startPower * (1 - lowPowerPercent) / rechargeTime * Time.deltaTime;
			} else {
				swimPaddle.forceMult = startPower;
			}
		}

		actualPowerPercent = swimPaddle.forceMult / startPower;
	}
}
