using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonar : MonoBehaviour {
    public float currentSpeed = 0.0f;
    public float minSpeed = 1.0f;
    public float maxSpeed = 2.0f;
    public float currentRadius = 0.0f;
    public float maxRadius = 5.0f;
    public float acceleration = 10f;
    //public float sonarTimeTocomplete = 5.0f;
    //public float sonarTimeElapsed = 0;
    //public GameObject[] wavePrefabs;
    public enum SonarStates
    {
        Forward,
        Back
    }

    public SonarStates currentState;

    // Use this for initialization
    void Awake () {
        //transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
        currentState = SonarStates.Forward;
        currentSpeed = minSpeed;
        //if (gameObject.tag == "Sonar") {
            //StartCoroutine("SpawnMore");
        //}
    }
	
	// Update is called once per frame
	void Update () {
        Grow();
	}

    /*IEnumerator SpawnMore() {
        yield return new WaitForSeconds(0.5f);
        Instantiate(wavePrefabs[0]);
        yield return new WaitForSeconds(0.33f);
        Instantiate(wavePrefabs[1]);
    }*/

    private void Grow()
    {
        //sonarTimeElapsed += Time.deltaTime;
        //currentRadius = Mathf.Lerp(0, maxRadius, 1/(1+Mathf.Sin(Mathf.Lerp(0, Mathf.PI * 2, (sonarTimeElapsed)))));
        //currentSpeed += Mathf.Sin(Mathf.Lerp(minSpeed, maxSpeed, Time.deltaTime/100));
        //currentRadius += Mathf.Sin(Mathf.PI * Time.deltaTime);
        //currentRadius = Mathf.Sin(testRad);
        //currentSpeed += Time.deltaTime * Mathf.Lerp(minSpeed,maxSpeed,1+Mathf.Sin((Mathf.PI / 1.5f)*Time.deltaTime));//* 5;// Mathf.Sin(Mathf.Lerp(minSpeed, maxSpeed, Time.deltaTime / 100));
        //currentSpeed += Time.deltaTime * 10f;
        if(currentSpeed >= minSpeed && currentSpeed <= maxSpeed) {
            currentSpeed += Time.deltaTime * acceleration;
        }
        switch (currentState)
        {
            case SonarStates.Forward:
                currentRadius += Time.deltaTime * currentSpeed;
                if (currentRadius >= maxRadius) {
                    currentState = SonarStates.Back;
                    currentSpeed = minSpeed;
                }
                break;
            case SonarStates.Back:
                currentRadius -= Time.deltaTime * currentSpeed;
                if (currentRadius <= 0) {
                    Destroy(gameObject);
                }
                break;
            default:
                currentRadius = 0;
                break;
        }

        transform.localScale = new Vector3(currentRadius, currentRadius, currentRadius);
    }

    public void OnTriggerEnter(Collider other) {
        if (other.tag == "Enemy") {
            other.GetComponent<Enemy>().FadeIn();
			other.GetComponent<Enemy>().FadeOut();
            //other.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}