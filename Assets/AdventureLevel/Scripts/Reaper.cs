using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reaper : MonoBehaviour
{
    public bool attack = false;

    Animator anim;

    public float maxHealth = 100f;

    public float currentHealth;

    public static bool dead;

    SpriteRenderer sr;

    Vector3 spawnLoc;

    public float shakeSpeed = 1f;
    public float shakeAmount = 1f;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        sr = GetComponent<SpriteRenderer>();

        currentHealth = maxHealth;

        spawnLoc = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Dead"))
        {
            Respawn();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger("attack");

            if (anim.GetCurrentAnimatorStateInfo(0).IsName("attack") & !Player.dead)
                other.gameObject.SendMessage("Damage", 3f);
        }
    }

    void Damage(float damage)
    {
        currentHealth -= damage;

        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("reaperdamaged"))
            anim.SetTrigger("Damaged");

        //shake
        transform.position = new Vector3(Mathf.Sin(Time.time * shakeSpeed) * shakeAmount, transform.position.y, transform.position.z);

        if (currentHealth < 1f)
            Die();
    }

    void Die()
    {
        dead = true;

        anim.SetTrigger("Die");
        
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Dead"))
        {
            Respawn();
        }
    }

    void Respawn()
    {
        transform.position = spawnLoc;

        dead = false;
        
        currentHealth = maxHealth;


        anim.SetTrigger("Respawn");

    }

}
