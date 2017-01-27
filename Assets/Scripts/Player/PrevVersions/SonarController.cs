using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonarController : MonoBehaviour {

	public GameObject controllerLeft;

	private SteamVR_TrackedObject trackedObj;
	private SteamVR_Controller.Device device;
	private SteamVR_TrackedController controller;
	public Transform muzzleTransform;

	public GameObject[] wavePrefabs;

	public ushort hap = 3999;

	public GameObject sonarPrefab;

	void Start() {
		controller = controllerLeft.GetComponent <SteamVR_TrackedController>();
		controller.TriggerClicked += TriggerPressed;
		trackedObj = controllerLeft.GetComponent <SteamVR_TrackedObject>();
	}

	private void TriggerPressed(object sender, ClickedEventArgs e) {
		ShootWeapon();
	}

	public void ShootWeapon()
	{
		// Check to see if there is already a sonar
		if (!GameObject.FindGameObjectWithTag("Sonar")) {
			Instantiate(sonarPrefab, muzzleTransform.position, transform.rotation);


		}

		device = SteamVR_Controller.Input((int)trackedObj.index);
		device.TriggerHapticPulse(hap);
		device.TriggerHapticPulse(hap);
		device.TriggerHapticPulse(hap);
	}

	//IEnumerator SpawnMore() {
		//yield return new WaitForSeconds(0.5f);
		//Instantiate(wavePrefabs[0], muzzleTransform.position, transform.rotation);
		//yield return new WaitForSeconds(0.33f);
		//Instantiate(wavePrefabs[1], muzzleTransform.position, transform.rotation);
	//}
}
