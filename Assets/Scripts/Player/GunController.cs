using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.VR;

public class GunController : MonoBehaviour {

    //public GameObject controllerRight;

    //private SteamVR_TrackedObject trackedObj;
    //private SteamVR_Controller.Device device;
    //private SteamVR_TrackedController controller;

    public GameObject bulletPrefab;
    public Transform muzzleTransform;
    public AudioClip shootSound;

    public bool AllowMultipleBullets = true;
    public bool LaunchProjectile = true;
    public float speed = 15f;

	private AudioSource source;
    public float vol = 6.5f;

    public bool RandomizeSound = false;
	public float volLowRange = 5f;
	public float volHighRange = 8f;
	public float pitchLowRange = 1.5f;
	public float pitchHighRange = 2.0f;


	public ushort hap = 3999;


	void Start() {
		source = this.GetComponent<AudioSource> ();
	}

	public void ShootWeapon()
	{
        if (!GameObject.FindGameObjectWithTag("Sonar") || AllowMultipleBullets) {
            GameObject instantiatedProjectile = Instantiate(bulletPrefab, muzzleTransform.position, transform.rotation) as GameObject;

            if (LaunchProjectile) {
                instantiatedProjectile.GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector3(0, speed, 0));
            }

            //device = SteamVR_Controller.Input((int)trackedObj.index);
            //device.TriggerHapticPulse(hap);

            if (shootSound != null) {
                if (RandomizeSound) {
                    vol = Random.Range(volLowRange, volHighRange);
                    source.pitch = Random.Range(pitchLowRange, pitchHighRange);
                }
                source.PlayOneShot(shootSound, vol);
            }
        }
	}
}
