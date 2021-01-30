using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    //Records the number of projectiles the player has, the player, and the projectile
    public GameObject player;
    public GameObject projectile;
    public int numProj = 1;

    //Determines the distance for spawning in the projectile
    public float spawnDistance = 10;

    //Records the fire rate
    [SerializeField]
    private float fireRate = 1f;

    //Creates the timer
    [SerializeField]
    private float timer;

    //Creates the firepoint
    [SerializeField]
    private Transform firePoint;


    // Start is called before the first frame update
    void Start()
    {

        

    }

    // Update is called once per frame
    void Update()
    {

        //Records player position, direction, and rotation for spawning in projectile
        Vector3 playerPos = player.transform.position;
        Vector3 playerDir = player.transform.forward;
        Quaternion playerRot = player.transform.rotation;

        //Records the position to spawn in the projectile
        Vector3 spawnPos = playerPos + playerDir * spawnDistance;
        
        //Timer for recording for fire rate
        timer += Time.deltaTime;
        if(timer >= fireRate)
        {

            //Fires gun
            if (Input.GetButton("Fire1"))
            {

                timer = 0f;
                fireStapler();

            }

        }
       
    }

    //Fires projectiles
    private void fireStapler()
    {

        Debug.DrawRay(firePoint.position, firePoint.forward * 100, Color.red, 2f);
        projectile.GetComponent<Rigidbody>().AddForce(transform.forward * 100);
        Destroy(projectile, 3);
         
        Ray ray = new Ray(firePoint.position, firePoint.forward);
        RaycastHit hitInfo;

        if(Physics.Raycast(ray, out hitInfo, 100))
        {


        }

    }

}
