using UnityEngine;
using System.Collections;
using System;

public class PlanetRotations : MonoBehaviour {

	private Quaternion rot;
	private float smooth;

	private float maxLocalScale = 2.0f;
	private float minLocalScale = 0.5f;
	private float curLocalScale;

	private float maxOrbitRadius = 1.75f;
	private float minOrbitRadius = 0.5f;
	private float curOrbitRadius;

	private float curRadians;
	private int localID;
	private bool expanding;

	public bool initialLarge;


	// Use this for initialization
	void Start () {
		rot = Quaternion.identity;
		smooth = 200.0f;

		if (!initialLarge) {
			curLocalScale = minLocalScale;
			expanding = true;
			localID = Int32.Parse (transform.name);
			curOrbitRadius = minOrbitRadius;
			curRadians = (Mathf.PI / 3.0f) * localID;
			transform.localScale = new Vector3 (curLocalScale, curLocalScale, curLocalScale);

		} else {
			curLocalScale = maxLocalScale;
			expanding = false;
			localID = Int32.Parse (transform.name);
			curOrbitRadius = maxOrbitRadius;
			curRadians = (Mathf.PI / 3.0f) * localID;
			transform.localScale = new Vector3 (curLocalScale, curLocalScale, curLocalScale);
		}
		float xPos = curOrbitRadius * Mathf.Cos (curRadians);
		float yPos = curOrbitRadius * Mathf.Sin (curRadians);
		transform.localPosition = new Vector3 (xPos, yPos, 0.0f);
	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround(transform.position, transform.forward, -2.0f);

		if (curLocalScale >= maxLocalScale) {
			expanding = false;
		}
		if (curLocalScale <= minLocalScale) {
			expanding = true;
		}

		if (expanding) {
			curLocalScale += 0.02f;
		} else {
			curLocalScale -= 0.02f;
		}

		curRadians = curRadians + 0.02f;

		transform.localScale = new Vector3 (curLocalScale, curLocalScale, curLocalScale);

		float ratio = curLocalScale / (maxLocalScale - minLocalScale);
		curOrbitRadius = minOrbitRadius + (ratio * (maxOrbitRadius - minOrbitRadius));
		float xPos = curOrbitRadius * Mathf.Cos (curRadians);
		float yPos = curOrbitRadius * Mathf.Sin (curRadians);
		transform.localPosition = new Vector3 (xPos, yPos, 0.0f);
	}
}
