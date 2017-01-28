using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {
    public enum Behavior { towardTarget, awayFromTarget }
    public Behavior moveBehavior = Behavior.towardTarget; 
    public Behavior lookBehavior = Behavior.towardTarget;

    public bool moveTargetPlayerOverride = true;
    public bool moveTargetWaveOverride = false;
    public bool lookTargetPlayerOverride = true;
    public bool lookTargetWaveOverride = false;

    public Transform moveTarget;
    public Transform lookTarget;

    public float moveSpeed;
    public float rotationSpeed;
    public float maxDistance = 5.0f;
    public float minDistance = 0.0f;

    //private Transform transform;
    private CharacterController myCharController;
    //public EnemyController controller;

    // Use this for initialization
    void Start () {
        //transform = transform;
        myCharController = this.GetComponent<CharacterController>();

        // override move target options
        if (moveTargetPlayerOverride) {
            moveTarget = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }
        // override look target options
        if (lookTargetPlayerOverride) {
            lookTarget = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }
		this.GetComponent<EnemyController>().WhileStateFollowing += WhileFollowing;
        this.GetComponent<EnemyController>().WhileStateIdle += WhileIdle;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void WhileIdle() {
        // override look target options
        if (lookTargetWaveOverride) {
            if (GameObject.FindGameObjectWithTag("Sonar")) {
                lookTarget = GameObject.FindGameObjectWithTag("Sonar").GetComponent<Transform>();
            }
        }
        lookTowards(lookTarget);
    }

    void WhileFollowing() {
        if (moveTargetWaveOverride) {
            if (GameObject.FindGameObjectWithTag("Sonar")) {
                moveTarget = GameObject.FindGameObjectWithTag("Sonar").GetComponent<Transform>();
            }
        }
        // override look target options
        if (lookTargetWaveOverride) {
            if (GameObject.FindGameObjectWithTag("Sonar")) {
                lookTarget = GameObject.FindGameObjectWithTag("Sonar").GetComponent<Transform>();
            }
        }

        // move
        switch (moveBehavior) {
            case Behavior.towardTarget:
                if (moveTarget != null) {
                    moveTowards(moveTarget);
                }
                break;
            case Behavior.awayFromTarget:
                if (moveTarget != null) {
                    moveAwayFrom(moveTarget);
                }
                break;
        }
        // look
        switch (lookBehavior) {
            case Behavior.towardTarget:
                if (moveTarget != null) {
                    lookTowards(lookTarget);
                }
                break;
            case Behavior.awayFromTarget:
                if (moveTarget != null) {
                    lookAwayFrom(lookTarget);
                }
                break;
        }
    }

    void lookTowards(Transform target) {
        //Look at target
        transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
    }

    void moveTowards(Transform target) {
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance < maxDistance && distance > minDistance) {

            // always move along the camera forward as it is the direction that it being aimed at
            Vector3 desiredMove = Vector3.Normalize(target.position - transform.position);
            Vector3 moveDir = new Vector3();
            // get a normal for the surface that is being touched to move along it
            RaycastHit hitInfo;
            Physics.SphereCast(transform.position, myCharController.radius, Vector3.down, out hitInfo,
                               myCharController.height / 2f, Physics.AllLayers, QueryTriggerInteraction.Ignore);
            desiredMove = Vector3.ProjectOnPlane(desiredMove, hitInfo.normal).normalized;

            moveDir.x = desiredMove.x * moveSpeed;
            moveDir.z = desiredMove.z * moveSpeed;

            myCharController.Move(moveDir * Time.deltaTime);//Time.fixedDeltaTime);
        }
    }

    void lookAwayFrom(Transform target) {
        //Look away from target
        Vector3 newDir = new Vector3(transform.position.x - target.position.x, 0, transform.position.z - target.position.z);
        transform.rotation = Quaternion.LookRotation(newDir);
    }

    void moveAwayFrom(Transform target) {
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance < maxDistance && distance > minDistance) {

            // always move along the camera forward as it is the direction that it being aimed at
            Vector3 desiredMove = Vector3.Normalize(transform.position - target.position);
            Vector3 moveDir = new Vector3();
            // get a normal for the surface that is being touched to move along it
            RaycastHit hitInfo;
            Physics.SphereCast(transform.position, myCharController.radius, Vector3.down, out hitInfo,
                               myCharController.height / 2f, Physics.AllLayers, QueryTriggerInteraction.Ignore);
            desiredMove = Vector3.ProjectOnPlane(desiredMove, hitInfo.normal).normalized;

            moveDir.x = desiredMove.x * moveSpeed;
            moveDir.z = desiredMove.z * moveSpeed;

            myCharController.Move(moveDir * Time.deltaTime);//Time.fixedDeltaTime);
        }
    }
}
