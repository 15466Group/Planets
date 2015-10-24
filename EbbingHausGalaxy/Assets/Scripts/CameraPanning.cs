using UnityEngine;
using System.Collections;

public class CameraPanning : MonoBehaviour {

	private Vector3 velocity;
	public Vector3 endPos;
	private float runTime;
	private float totalTime;
	private AudioSource clip;

	// Use this for initialization
	void Start () {
		clip = GetComponent<AudioSource> ();
		runTime = clip.clip.length;
		velocity = Vector3.zero;
		velocity.x = (Vector3.Distance(endPos, transform.position))/runTime;
		totalTime = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		totalTime += Time.deltaTime;
		if (totalTime < runTime) {
			transform.position += velocity * Time.deltaTime;
//			Debug.Log (totalTime);
		}
	}
}
