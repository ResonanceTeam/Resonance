using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rig : MonoBehaviour {
	// Use this for initialization
	void Awake() {
		Object.DontDestroyOnLoad (gameObject);
	}
}
