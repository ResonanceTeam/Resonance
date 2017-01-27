using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastWave : MonoBehaviour {
	public void OnTriggerExit(Collider other) {
		if (other.tag == "Enemy") {
			other.GetComponent<Enemy>().FadeOut(false);
			//other.GetComponent<MeshRenderer>().enabled = false;
		}
	}
}
