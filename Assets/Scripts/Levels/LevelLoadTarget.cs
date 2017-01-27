using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoadTarget : MonoBehaviour {

    public string levelToLoad;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void ShowTarget() {

    }

    public void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Bullet") {
            Application.LoadLevel(levelToLoad);
        }
    }
}
