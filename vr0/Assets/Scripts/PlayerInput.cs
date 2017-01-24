using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {
    public GameObject sonarPrefab;
    public GameObject bulletPrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp(KeyCode.Space)) {
            UseSonar();
        } //else if (Input.GetButtonUp("Fire")) {
            //SpawnBullet();
        //}
	}

    public void UseSonar() {
        // Check to see if there is already a sonar
        if (!GameObject.FindGameObjectWithTag("Sonar")) {
            Instantiate(sonarPrefab);
        }
    }

    private void SpawnBullet() {
        // instantiate an object at the mouse's position, at 20 units away from the camera
        var screenPos = Input.mousePosition;
        screenPos.z = 20;
        var worldPos = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().ScreenToWorldPoint(screenPos);
        var newInstance = Instantiate(bulletPrefab, worldPos, Quaternion.identity);
    }
}
