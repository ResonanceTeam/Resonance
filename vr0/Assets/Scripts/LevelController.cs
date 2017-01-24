using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

    public PlayerSpawnTrigger spawn;
    private int mobCount = 0;
    
	// Use this for initialization
	void Start () {
        GameObject[] mobs = GameObject.FindGameObjectsWithTag("Enemy");
        mobCount = mobs.Length;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void mobCountDec() {
        mobCount--;
        if (mobCount >= 0) {

			Debug.Log ("setting spawn trigger active");
            spawn.gameObject.SetActive(true);
        }
    }
}
