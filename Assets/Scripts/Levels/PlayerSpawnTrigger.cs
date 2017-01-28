using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnTrigger : MonoBehaviour {

    public GameObject levelLoadTarget;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			levelLoadTarget.gameObject.SetActive (true);
			//Debug.Log ("player entered spawn trigger");
		} else {

			//Debug.Log (other.name + " entered spawn trigger");
		}

    }

	public void OnTriggerExit(Collider other) {
        if (other.tag == "Player") {
			levelLoadTarget.gameObject.SetActive(false);
			//Debug.Log ("player left spawn trigger");
		} else {
			//Debug.Log (other.name + " exited spawn trigger");
		}
    }
}
