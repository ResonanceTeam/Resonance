using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public bool isFadingIn = false;
    public bool isFadingOut = false;

	private bool delayed = false;

    public float currentAlpha = 0.0f;
    public float maxAlpha = 1.0f;

    public float currentDelay = 0.0f;
    public float maxDelay = 3.0f;

    public MeshRenderer mesh;

    private Color currentColor;

    private void Start() {
		currentColor = mesh.material.color;
		mesh.material.color = new Color(currentColor.r, currentColor.b, currentColor.g, 0);
		mesh.enabled = false;
    }
    void Update() {
        if (isFadingIn) {
            if (currentAlpha >= maxAlpha) {
                currentAlpha = maxAlpha;
                isFadingIn = false;
            } else {
                currentAlpha += Time.deltaTime;
                mesh.material.color = new Color(currentColor.r, currentColor.b, currentColor.g, currentAlpha);
            }
        }

        if (isFadingOut) {
            currentDelay += Time.deltaTime;

			if (currentDelay >= maxDelay || delayed == false) {
                currentDelay = maxDelay;
                if (currentAlpha <= 0) {
                    currentAlpha = 0;
                    isFadingOut = false;
					gameObject.GetComponent<EnemyController>().SetInactive();
                    mesh.enabled = false;
                } else {
                    currentAlpha -= Time.deltaTime;
                    mesh.material.color = new Color(currentColor.r, currentColor.b, currentColor.g, currentAlpha);
                }
            }
        }
    }

    public void FadeIn() {
        isFadingIn = true;
        mesh.enabled = true;
		gameObject.GetComponent<EnemyController>().SetActive();
    }

	public void FadeOut(bool isDelayed = true) {
		delayed = isDelayed;
		isFadingOut = true;
		currentDelay = 0.0f;
    }
}
