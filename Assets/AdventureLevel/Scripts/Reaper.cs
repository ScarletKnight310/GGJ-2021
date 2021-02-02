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

    Vector3 spawnLoc;

    public float shakeSpeed = 1f;
    public float shakeAmount = 1f;

    float startShakeX = 0f;

    int j = 0;

    public bool isBoss;

    public List<Material> mats = new List<Material>(4);
    public List<MeshRenderer> shieldCubes = new List<MeshRenderer>(8);
    public int currentMat = 0;

    public GameObject superbit;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

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

        if (isBoss)
        {
            if (currentMat < mats.Count)
            {
                for (int i = 0; i < shieldCubes.Count; i++)
                {
                    shieldCubes[i].material = mats[currentMat];
                }
            }
            else
            {
                for (int i = 0; i < shieldCubes.Count; i++)
                {
                    shieldCubes[i].enabled = false;
                }

            }
            anim.SetFloat("RespawnTime", 10f);
        }
        else
            anim.SetFloat("RespawnTime", 1f);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            attack = true;

            anim.SetTrigger("attack");

            if (anim.GetCurrentAnimatorStateInfo(0).IsName("attack") & !Player.dead)
                other.gameObject.SendMessage("Damage", 3f);
        }
        else 
            attack = false;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            attack = false;
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

        if (currentMat < mats.Count - 1)
        {
            currentMat++;

            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Dead"))
                Respawn();
        }
        else
            anim.SetBool("superDead", true);
        
        if (currentMat == mats.Count - 1)
            superbit.SetActive(true);
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
