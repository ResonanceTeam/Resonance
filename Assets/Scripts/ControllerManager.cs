using UnityEngine;
using System.Collections;
public class ControllerManager : MonoBehaviour {
	public bool triggerButtonDown = false;

	public GameObject laserGun;
	public GameObject sonarGun;

	private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;

	private SteamVR_Controller.Device controller {

		get { return SteamVR_Controller.Input((int)trackedObj.index);

		}

	}

	private SteamVR_TrackedObject trackedObj;

	void Start() {

		trackedObj = GetComponent<SteamVR_TrackedObject>();

	}

	void Update() {

		if (controller == null) {

			Debug.Log("Controller not initialized");

			return;

		}
	}

	public void OnTriggerStay(Collider other) {
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
	}
}