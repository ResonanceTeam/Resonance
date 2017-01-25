using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour {
    private AudioSource audioSource;
    public AudioClip deathSound;
    public int killScore;
    private GameController gameController;
	private LevelController levelController;
	public GameObject deathPrefab;

    // Use this for initialization
    void Start () {
        gameController = GameObject.FindGameObjectWithTag("Player").GetComponent<GameController>();
		levelController = GameObject.Find ("LevelController").GetComponent<LevelController>();
        audioSource = this.GetComponent<AudioSource>();
		this.GetComponent<Health>().OnDeath += Die;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Die() {
        audioSource.PlayOneShot(deathSound);
        gameController.AddScore(killScore);
		levelController.mobCountDec();
		Debug.Log ("calling mob count dec");
        // add enemy death animation and stuff here
		Instantiate(deathPrefab, transform.position,transform.rotation);
        Destroy(gameObject);
    }
}
