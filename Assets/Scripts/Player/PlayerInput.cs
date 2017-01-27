using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class PlayerInput : MonoBehaviour{

    public GameObject VRController0;
    public GameObject VRController1;

    public enum BtnCode { Action0, Action1, QuickMenu }
    public enum AxisCode { MoveX, MoveY}

    private SteamVR_Controller.Device vr0;
    private SteamVR_Controller.Device vr1;

    // Use this for initialization
    void Start () {
        if (VRDevice.isPresent) {
            vr0 = VRController0.GetComponent<SteamVR_Controller.Device>();
            vr1 = VRController1.GetComponent<SteamVR_Controller.Device>();
        }
    }
	
	// Update is called once per frame
	void Update () {
	}

    public bool GetBtn(BtnCode btn) {
        switch (btn) {
            case BtnCode.Action0:
                return VRDevice.isPresent == true ? vr0.GetHairTrigger() : Input.GetMouseButton(0);
            case BtnCode.Action1:
                return VRDevice.isPresent == true ? vr1.GetHairTrigger() : Input.GetMouseButton(1);
        }
        return false;
    }

    public bool GetBtnDown(BtnCode btn) {
        bool onDown = false;
        switch (btn) {
            case BtnCode.Action0:
                break;
        }
        return onDown;
    }

    public bool GetBtnUp(BtnCode btn) {
        bool onUp = false;
        switch (btn) {
            case BtnCode.Action0:
                break;
        }
        return onUp;
    }

    public float GetAxis(AxisCode axis) {
        float output = 0.0f;
        switch (axis) {
            case AxisCode.MoveX:
                break;
            case AxisCode.MoveY:
                break;
        }
        return output;
    }
}






    //public GameObject sonarPrefab;
    //public GameObject bulletPrefab;

	// Use this for initialization
	/*void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//if (Input.GetKeyUp(KeyCode.Space)) {
            //UseSonar();
        //} //else if (Input.GetButtonUp("Fire")) {
            //SpawnBullet();
        //}
	}

    public void UseSonar() {
        // Check to see if there is already a sonar
        if (!GameObject.FindGameObjectWithTag("Sonar")) {
            Instantiate(sonarPrefab);
        }
    }

    private void SpawnBullet() {
        // instantiate an object at the mouse's position, at 20 units away from the camera
        var screenPos = Input.mousePosition;
        screenPos.z = 20;
        var worldPos = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().ScreenToWorldPoint(screenPos);
        var newInstance = Instantiate(bulletPrefab, worldPos, Quaternion.identity);
    }
}*/
