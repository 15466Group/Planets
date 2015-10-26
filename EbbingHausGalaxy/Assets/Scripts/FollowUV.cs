using UnityEngine;
using System.Collections;

public class FollowUV : MonoBehaviour {

	public float parralax = 2f;
	public GameObject cam;
	public float initialOffset;
	private float offset;

	void Start () {
		transform.position = new Vector3 (cam.transform.position.x + 4.0f, cam.transform.position.y, 10.0f);
		offset = initialOffset;
	}

	void Update () {
		if (Time.frameCount < 240) {
			return;
		}
		offset -= parralax;
		transform.position = new Vector3 (cam.transform.position.x+offset+4.0f, cam.transform.position.y, 10.0f);
	}

}
