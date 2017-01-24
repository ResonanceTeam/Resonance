using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public int currentHealth = 1;
    public int maxHealth = 1;

    public delegate void DeathAction();
    public event DeathAction OnDeath;

    public delegate void HurtAction();
    public event HurtAction OnHurt;

    public delegate void HealAction();
    public event HealAction OnHeal;

    public delegate void HealMaxAction();
    public event HealMaxAction OnMaxHeal;

    // Use this for initialization
    void Start() {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update() {
    }

    public void Damage(int amt) {
        currentHealth -= amt;
        if (currentHealth <= 0) {
            if (OnDeath != null) {
                OnDeath();
            }
        } else {
            if (OnHurt != null) {
                OnHurt();
            }
        }
    }

    void Heal(int amt) {
        int newHP = currentHealth + amt;
        if (newHP > maxHealth){
            currentHealth = maxHealth;
            if (currentHealth <= 0) {
                if (OnMaxHeal != null) {
                    OnMaxHeal();
                }
            }
        }
        else {
            currentHealth = newHP;
            if (currentHealth <= 0) {
                if (OnHeal != null) {
                    OnHeal();
                }
            }
        }
    }

    public void OnTriggerEnter(Collider other) {
        if (other.tag == "Bullet") {
            //Damage(other.GetComponent<Bullet>().bulletDamage);
        }
    }
}