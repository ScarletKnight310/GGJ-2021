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

    // Start is called before the first frame update

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
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

