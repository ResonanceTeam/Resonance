using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour {
    public float currentSpeed = 2.0f;
    public float minSpeed = 1.0f;
    public float maxSpeed = 2.0f;
    public float currentRadius = 0.0f;
    public float maxRadius = 5.0f;


    public enum SonarStates
    {
        Forward,
        Back
    }

    public SonarStates currentState;

    // Use this for initialization
    void Awake () {
        //transform.position = GameObject.FindGameObjectWithTag("Sonar").transform.position;
        currentState = SonarStates.Forward;       
    }
	
	// Update is called once per frame
	void Update () {
        Grow();
	}

    private void Grow()
    {
        currentSpeed += Mathf.Sin(Mathf.Lerp(minSpeed, maxSpeed, Time.deltaTime/100));
       
        switch(currentState)
        {
            case SonarStates.Forward:
                currentRadius += Time.deltaTime * currentSpeed;
                if (currentRadius >= maxRadius) {
                    currentState = SonarStates.Back;
                    currentSpeed = 0;
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
}
