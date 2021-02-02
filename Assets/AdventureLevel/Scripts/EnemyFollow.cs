using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{ 
    public float speed;
    public Transform target;
    public float closingDistance;
    public float runningDistance;
    public bool chase = true;

    bool isFacingRight = false;

    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<Reaper>().dead)
        {
            anim.SetFloat("speed", speed);
            
            if (target.position.x < transform.position.x && isFacingRight)
            {
                isFacingRight = false;
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            }
            if (target.position.x > transform.position.x && !isFacingRight)
            {
                isFacingRight = true;
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            }

            if (chase)
            {
                if (Vector2.Distance(transform.position, target.position) > closingDistance)
                {
                    transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                }
            }
            else
            {
                if (Vector2.Distance(transform.position, target.position) < runningDistance)
                {
                    transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);
                }
                else if (Vector2.Distance(transform.position, target.position) > runningDistance)
                {
                    chase = true;
                }
            }
        }
    }
}