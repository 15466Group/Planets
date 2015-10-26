using UnityEngine;
using System.Collections;

public class CameraPanning : MonoBehaviour {

	private Vector3 step;
	public Vector3 endPos;
	private float runTime;
	private float totalTime;
	private AudioSource clip;
	private float totalFrames = 480.0f;
	private float totalDistance = 20;
	private float frameCount;

	// Use this for initialization
	void Start () {
		frameCount = 0.0f;
		clip = GetComponent<AudioSource> ();
		runTime = clip.clip.length;
		step = Vector3.zero;
		step.x = totalDistance / totalFrames;
//		Application.targetFrameRate = 30;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Time.frameCount < 240) {
			return;
		}
		frameCount++;
		totalTime += Time.deltaTime;
		if (frameCount <= totalFrames) {
			transform.position += step;
//			Debug.Log (totalTime);
		} else {
			//Debug.Break();
		}
	}
}
