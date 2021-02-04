using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxHealth = 100f;

    public float currentHealth;

    public static bool dead;

    SpriteRenderer sr;

    public Vector3 spawnLoc;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        
        sr = GetComponent<SpriteRenderer>();

        spawnLoc = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth < 1f)
            Die();
    }

    void Damage(float damage)
    {
        currentHealth -= damage;
    }

    void Die()
    {
        dead = true;

        sr.enabled = false;

        Respawn();
    }

    void Respawn()
    {
        transform.position = spawnLoc;

        dead = false;
        
        currentHealth = maxHealth;

        sr.enabled = true;
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(5f);
    }
}
