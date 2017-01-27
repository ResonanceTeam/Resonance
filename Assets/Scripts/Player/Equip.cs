using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equip : MonoBehaviour {

    public GameObject EquipedItem;
    public byte Id;
    private GunController GC;
	// Use this for initialization
	void Start () {
        if(EquipedItem != null) {
            EquipItem(EquipedItem);
        }
    }
	
	// Update is called once per frame
	void Update () {
        // use equipped item action
        if (Id == 0) {
            if (PlayerInput.GetBtnUp(PlayerInput.BtnCode.Action0)) {
                GC.ShootWeapon();
            }
        } else if(Id == 1) {
            if (PlayerInput.GetBtnUp(PlayerInput.BtnCode.Action1)) {
                GC.ShootWeapon();
            }
        }
	}

    public void EquipItem(GameObject item) {
        EquipedItem = Instantiate(item,transform.position,transform.rotation,transform) as GameObject;
        if (EquipedItem.GetComponent<GunController>() != null) {
            GC = EquipedItem.GetComponent<GunController>();
        }
    }

    public void UnequipItem() {
        if (EquipedItem != null) {
            GC = null;
            Destroy(EquipedItem);
        }
    }
}
