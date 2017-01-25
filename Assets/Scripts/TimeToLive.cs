using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeToLive : MonoBehaviour {

	public float maxTime;
	private float currentTime;
	// Use this for initialization
	void Start () {
		currentTime = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		currentTime += Time.deltaTime;
		if (currentTime > maxTime) {
			Destroy(gameObject);
		}
	}
}
