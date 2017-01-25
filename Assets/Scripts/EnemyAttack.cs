using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {


    public AudioClip attackSound;

    // Use this for initialization
    void Start () {
        this.GetComponent<EnemyController>().OnSetStateAttackingMelee += Melee;
	}
	
	// Update is called once per frame
	void Update () {

	}

    void Melee() {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().Damage(1);
        if (attackSound != null) {
            this.GetComponent<AudioSource>().PlayOneShot(attackSound);
        }
    }

    
}
