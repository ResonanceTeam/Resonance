using UnityEngine;
using System.Collections;
public class ControllerManager : MonoBehaviour {

   


    public enum VRKeyCode { Trigger,TouchPadPress}

	//public bool triggerButtonDown = false;
    //private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;

    private SteamVR_TrackedObject trackedObj;
    private SteamVR_Controller.Device controller {
		get {
            return SteamVR_Controller.Input((int)trackedObj.index);
		}
    }






	void Start() {
		trackedObj = GetComponent<SteamVR_TrackedObject>();
	}

	void Update() {

		if (controller == null) {
			Debug.Log("Controller not initialized");
			return;
		}

        //Input.GetAxis("")
	}


    public bool GetButton(VRKeyCode input) {
        bool isPressed = false;
        switch (input) {
            case VRKeyCode.Trigger:
                isPressed = controller.GetHairTrigger();
                break;
            case VRKeyCode.TouchPadPress:
                // name and add next button here, need a guide to btn masks to figure out which btn is which
                isPressed = controller.GetPress(SteamVR_Controller.ButtonMask.Touchpad);
                break;
        }
        return isPressed;
    }



	/*public void OnTriggerStay(Collider other) {
		if (other.tag == "Item") {
			triggerButtonDown = controller.GetPressDown(triggerButton);

			if (triggerButtonDown) {
				Debug.Log (gameObject.name);
				if (other.gameObject.name == "Laser_Pistol_pickup") {
					gameObject.GetComponent<Collider> ().enabled = false;
					gameObject.transform.FindChild ("Model").gameObject.SetActive (false);
					laserGun.SetActive (true);
				} else if (other.gameObject.name == "Speaker_Gun_pickup") {
					gameObject.GetComponent<Collider> ().enabled = false;
					gameObject.transform.FindChild ("Model").gameObject.SetActive (false);
					sonarGun.SetActive (true);
				}
				Debug.Log ("Item picked up");
				Destroy (other.gameObject);
			}
		}
	}*/
}