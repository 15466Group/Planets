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
	private float expansionRate;
	
	public bool initialLarge;
	private float numOscillations;
	public GameObject cam;
	private float clipLen;
	private float frameRate;
	private float totalFrames = 480.0f;


	// Use this for initialization
	void Start () {
		frameRate = 60.0f;
		rot = Quaternion.identity;
		smooth = 200.0f;
		//numOscillations = 0.5f;
		clipLen = cam.GetComponent<AudioSource> ().clip.length;
		expansionRate = (maxLocalScale-minLocalScale) / (totalFrames / 4.0f);
//		Debug.Log (expansionRate);

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
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Time.frameCount < 240) {
			return;
		}
//		frameRate = 1.0f / Time.deltaTime;
//		Debug.Log (frameRate);
		expansionRate = (maxLocalScale-minLocalScale) / (totalFrames / 4.0f);
//		transform.RotateAround(transform.position, transform.forward, 360.0f/(clipLen * frameRate));

		if (curLocalScale >= maxLocalScale) {
			expanding = false;
		}
		if (curLocalScale <= minLocalScale) {
			expanding = true;
		}

		if (expanding) {
			curLocalScale += expansionRate;
		} else {
			curLocalScale -= expansionRate;
		}

		curRadians = curRadians + (Mathf.PI / 480.0f);
//		curRadians = 0.0f;

		transform.localScale = new Vector3 (curLocalScale, curLocalScale, curLocalScale);

		float ratio = curLocalScale / (maxLocalScale - minLocalScale);
		curOrbitRadius = minOrbitRadius + (ratio * (maxOrbitRadius - minOrbitRadius));
		float xPos = curOrbitRadius * Mathf.Cos (curRadians);
		float yPos = curOrbitRadius * Mathf.Sin (curRadians);
		transform.localPosition = new Vector3 (xPos, yPos, 0.0f);
	}
}
