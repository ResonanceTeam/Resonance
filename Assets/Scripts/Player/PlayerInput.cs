using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class PlayerInput : MonoBehaviour{

    public GameObject VRController0;
    public GameObject VRController1;

    public enum BtnCode { Action0, Action1, QuickMenu0, QuickMenu1 }
    public enum AxisCode { MoveX, MoveY}

    private static SteamVR_Controller.Device vr0;
    private static SteamVR_Controller.Device vr1;

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

    public static bool GetBtn(BtnCode btn) {
        switch (btn) {
            case BtnCode.Action0:
                return VRDevice.isPresent == true ? vr0.GetHairTrigger() : Input.GetMouseButton(0);
            case BtnCode.Action1:
                return VRDevice.isPresent == true ? vr1.GetHairTrigger() : Input.GetMouseButton(1);
            case BtnCode.QuickMenu0:
                return VRDevice.isPresent == true ? vr0.GetPress(SteamVR_Controller.ButtonMask.Touchpad) : Input.GetKey(KeyCode.Q);
            case BtnCode.QuickMenu1:
                return VRDevice.isPresent == true ? vr1.GetPress(SteamVR_Controller.ButtonMask.Touchpad) : Input.GetKey(KeyCode.E);
        }
        return false;
    }

    public static bool GetBtnDown(BtnCode btn) {
        switch (btn) {
            case BtnCode.Action0:
                return VRDevice.isPresent == true ? vr0.GetHairTriggerDown() : Input.GetMouseButtonDown(0);
            case BtnCode.Action1:
                return VRDevice.isPresent == true ? vr1.GetHairTriggerDown() : Input.GetMouseButtonDown(1);
            case BtnCode.QuickMenu0:
                return VRDevice.isPresent == true ? vr0.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad) : Input.GetKeyDown(KeyCode.Q);
            case BtnCode.QuickMenu1:
                return VRDevice.isPresent == true ? vr1.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad) : Input.GetKeyDown(KeyCode.E);
        }
        return false;
    }

    public static bool GetBtnUp(BtnCode btn) {
        switch (btn) {
            case BtnCode.Action0:
                return VRDevice.isPresent == true ? vr0.GetHairTriggerUp() : Input.GetMouseButtonUp(0);
            case BtnCode.Action1:
                return VRDevice.isPresent == true ? vr1.GetHairTriggerUp() : Input.GetMouseButtonUp(1);
            case BtnCode.QuickMenu0:
                return VRDevice.isPresent == true ? vr0.GetPressUp(SteamVR_Controller.ButtonMask.Touchpad) : Input.GetKeyUp(KeyCode.Q);
            case BtnCode.QuickMenu1:
                return VRDevice.isPresent == true ? vr1.GetPressUp(SteamVR_Controller.ButtonMask.Touchpad) : Input.GetKeyUp(KeyCode.E);
        }
        return false;
    }

    public static float GetAxis(AxisCode axis) {
        switch (axis) {
            case AxisCode.MoveX:
                return VRDevice.isPresent == true ? vr0.GetAxis().x : Input.GetAxis("Horizonal");
            case AxisCode.MoveY:
                return VRDevice.isPresent == true ? vr0.GetAxis().y : Input.GetAxis("Vertical");
        }
        return 0f;
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
