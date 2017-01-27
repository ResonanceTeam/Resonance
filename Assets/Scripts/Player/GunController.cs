using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {

	public GameObject controllerRight;

	private SteamVR_TrackedObject trackedObj;
	private SteamVR_Controller.Device device;
	private SteamVR_TrackedController controller;
	public Transform muzzleTransform;

	public AudioClip shootSound;
	private AudioSource source;

	public float volLowRange = 5f;
	public float volHighRange = 8f;
	public float pitchLowRange = 1.5f;
	public float pitchHighRange = 2.0f;


	public ushort hap = 3999;

	public float speed = 15f;

	public GameObject bulletPrefab;

	void Start() {
		source = this.GetComponent<AudioSource> ();
		controller = controllerRight.GetComponent <SteamVR_TrackedController>();
		controller.TriggerClicked += TriggerPressed;
		trackedObj = controllerRight.GetComponent <SteamVR_TrackedObject>();
	}

	private void TriggerPressed(object sender, ClickedEventArgs e) {
		ShootWeapon();
	}

	public void ShootWeapon()
	{
		GameObject instantiatedProjectile = Instantiate (bulletPrefab, muzzleTransform.position, transform.rotation) as GameObject;

		instantiatedProjectile.GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector3(0, speed, 0));
		device = SteamVR_Controller.Input((int)trackedObj.index);
		device.TriggerHapticPulse(hap);

		float vol = Random.Range (volLowRange, volHighRange);
		source.pitch = Random.Range (pitchLowRange, pitchHighRange);
		source.PlayOneShot (shootSound, vol);
	}
}
