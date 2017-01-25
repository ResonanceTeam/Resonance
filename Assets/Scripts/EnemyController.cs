using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public bool isActive = false;
    public enum state { following, idle, spawning, dieing, hurt, attackingMelee, attackingProjectile };
    public state currentState = state.following;
    public state defaultState = state.following;

    // attack specific stuff
    public float minProjectileDistance = 2.0f;
    public float maxProjectileDistance = 3.0f;

    public GameObject projectile;

	public Collider meshCollider;

    // events to run when setting active or inactive
    public delegate void OnSetActiveAction();
    public static event OnSetActiveAction OnSetActive;
    public delegate void OnSetInactiveAction();
    public static event OnSetInactiveAction OnSetInactive;

    // events to run on change state
    public delegate void OnSetStateIdleAction();
    public event OnSetStateIdleAction OnSetStateIdle;

    public delegate void OnSetStateFollowingAction();
    public event OnSetStateFollowingAction OnSetStateFollowing;

    public delegate void OnSetStateSpawningAction();
    public event OnSetStateSpawningAction OnSetStateSpawning;

    public delegate void OnSetStateDieingAction();
    public event OnSetStateDieingAction OnSetStateDieing;

    public delegate void OnSetStateHurtAction();
    public event OnSetStateHurtAction OnSetStateHurt;

    // attack events (all on statechange to attacking)
    public delegate void OnAttackAction();          // this onei s not its own state, split into the next two but this is called by both
    public event OnAttackAction OnAttack;

    public delegate void OnSetStateAttackingMeleeAction();
    public event OnSetStateAttackingMeleeAction OnSetStateAttackingMelee;

    public delegate void OnSetStateAttackingProjectileAction();
    public event OnSetStateAttackingProjectileAction OnSetStateAttackingProjectile;

    // events to run continuously in state
    public delegate void WhileStateIdleAction();
    public event WhileStateIdleAction WhileStateIdle;

    public delegate void WhileStateFollowingAction();
    public event WhileStateFollowingAction WhileStateFollowing;

    public delegate void WhileStateSpawningAction();
    public event WhileStateSpawningAction WhileStateSpawning;

    public delegate void WhileStateDieingAction();
    public event WhileStateDieingAction WhileStateDieing;

    public delegate void WhileStateHurtAction();
    public event WhileStateHurtAction WhileStateHurt;

    // attacking
    public delegate void WhileAttackingAction();        // this onei s not its own state, split into the next two but this is called by both
    public event WhileAttackingAction WhileAttacking;

    public delegate void WhileStateAttackingMeleeAction();
    public event WhileStateAttackingMeleeAction WhileStateAttackingMelee;

    public delegate void WhileStateAttackingProjectileAction();
    public event WhileStateAttackingProjectileAction WhileStateAttackingProjectile;

    // Use this for initialization
    void Start () {
        if (isActive) {
            SetActive();
        } else {
            SetInactive();
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (isActive) {
            switch (currentState) {
                case state.idle:
                    if (WhileStateIdle != null) {
                        WhileStateIdle();
                    }
                    break;
                case state.following:
                    if (WhileStateFollowing != null) {
                        WhileStateFollowing();
                    }
                    break;
                case state.spawning:
                    if (WhileStateSpawning != null) {
                        WhileStateSpawning();
                    }
                    break;
                case state.dieing:
                    if (WhileStateDieing != null) {
                        WhileStateDieing();
                    }
                    break;
                case state.attackingMelee:
                    if (WhileStateAttackingMelee != null) {
                        WhileStateAttackingMelee();
                        WhileAttacking();
                    }
                    break;
                case state.attackingProjectile:
                    if (WhileStateAttackingProjectile != null) {
                        WhileStateAttackingProjectile();
                        WhileAttacking();
                    }
                    break;
            }
        } else {
            // do inactive stuff?
        }
	}

    public void SetActive() {
        isActive = true;
		this.GetComponent<CharacterController>().enabled = true;
		meshCollider.enabled = true;
        if (OnSetActive != null) {
			OnSetActive();
		}
    }

    public void SetInactive() {
		isActive = false;
		this.GetComponent<CharacterController>().enabled = false;
		meshCollider.enabled = false;
		if (OnSetInactive != null) {
			OnSetInactive();
		}
    }

    void SetState(state newState) {
		currentState = newState;
        switch (newState) {
		case state.idle:
			    if (OnSetInactive != null) {
				    OnSetStateIdle();
			    }
                break;
		    case state.following:
			    if (OnSetStateFollowing != null) {
				    OnSetStateFollowing();
			    }
                break;
		    case state.spawning:
			    if (OnSetStateSpawning != null) {
				    OnSetStateSpawning();
			    }
                break;
		    case state.dieing:
			    if (OnSetStateSpawning != null) {
				    OnSetStateSpawning();
			    }
                break;
            case state.attackingMelee:
                if (OnSetStateAttackingMelee != null) {
                    OnSetStateAttackingMelee();
					if (OnAttack != null) {
						OnAttack();
					}
                }
                break;
			case state.attackingProjectile:
				if (OnSetStateAttackingProjectile != null) {
					OnSetStateAttackingProjectile ();
					if (OnAttack != null) {
						OnAttack ();
					}
				}
                break;
        }
    }

    // set state to melee if in contact with player
    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            SetState(state.attackingMelee);
            Debug.Log("enemy contact with player, setting state to melee");
        }
    }

    // return to default state if contact is broken
    void OnTriggerExit(Collider other) {
        if (other.tag == "Player") {
            Debug.Log("enemy contact with player broken, returning to default state");
            SetState(defaultState);
        }
    }
}
