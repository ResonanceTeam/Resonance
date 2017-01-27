using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	public float lifeSpan = 5.0f;
	public float currentLifeTimer = 0.0f;
	public int bulletDamage = 1;
	// Use this for initialization
	void Awake () {
		currentLifeTimer = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		currentLifeTimer += Time.deltaTime;
		if (currentLifeTimer >= lifeSpan) {
			Destroy (gameObject);
		}

	}

	public void OnTriggerEnter(Collider other) {
		if (other.tag == "Enemy") {
			if (other.GetComponent<CharacterController>().enabled == true) {
				other.gameObject.GetComponent<Health>().Damage(bulletDamage);
			}
		}

		if (other.tag == "Menu") {
			Application.LoadLevel (1);
		}
	}
}
