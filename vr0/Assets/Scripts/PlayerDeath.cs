using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour {
    private AudioSource audioSource;
    public AudioClip deathSound;

    // Use this for initialization
    void Start () {
        audioSource = this.GetComponent<AudioSource>();
		this.GetComponent<Health>().OnDeath += Die;
    }
	
	// Update is called once per frame
	void Update () {

    }

    void Die() {
        audioSource.PlayOneShot(deathSound);
        // add death effects here
		Application.LoadLevel("MainMenuCopy");
    }
}
