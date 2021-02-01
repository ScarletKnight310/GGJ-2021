using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reaper : MonoBehaviour
{
    public bool attack = false;

    Animator anim;

    public float maxHealth = 100f;

    public float currentHealth;

    public bool dead;

    SpriteRenderer sr;

    Vector3 spawnLoc;

    public float shakeSpeed = 1f;
    public float shakeAmount = 1f;

    float startShakeX = 0f;

    int i = 0;
    int j = 0;

    public bool isBoss;

    int deathCount;

    public List<Material> mats = new List<Material>(4);

    public int currentMat = 0;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        sr = GetComponent<SpriteRenderer>();

        currentHealth = maxHealth;

        spawnLoc = transform.position;

        if (isBoss)
        {
            sr.color = mats[currentMat].color;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Dead"))
        {
            Respawn();
        }

        if (isBoss)
        {
            sr.color = mats[currentMat].color;
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
        
        startShakeX = transform.position.x;

        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("reaperdamaged") & !dead)
        {

            anim.SetTrigger("Damaged");
            //SHAKE
            transform.position = new Vector3(startShakeX + Mathf.Sin(Time.time * shakeSpeed) * shakeAmount, transform.position.y, transform.position.z);
        }

        //DEATH
        if (currentHealth < 1f && j < 1)
        {
            Die();
            j++;
        }
    }

    void Die()
    {
        dead = true;

        anim.SetTrigger("Die");

        if (currentMat < 3)
            currentMat++;

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

        j = 0;

        anim.SetTrigger("Respawn");

    }

}
