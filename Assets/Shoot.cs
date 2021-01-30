using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public static GameObject instance = null;

    //Records the number of projectiles the player has, the player, and the projectile
    public GameObject player;
    public GameObject projectile;
    public int maxProj = 5;

    //Determines the distance for spawning in the projectile
    public float spawnDistance = 10;

    //Determines the speed at which the projectile moves
    public float speed = 150;

    //Records the fire rate
    [SerializeField]
    private float fireRate = 1f;

    //Creates the timer
    [SerializeField]
    private float timer;

    //Creates the firepoint
    [SerializeField]
    private Transform firePoint;

    private List<GameObject> staples = new List<GameObject>();
    public int maxCurrStaples = 3;

    // Start is called before the first frame update
    void Awake()
    {

        if (instance != null)
        {

            Destroy(gameObject);

        }
        else
        {

            instance = gameObject;

        }


    }

    // Update is called once per frame
    void Update()
    {

        //Timer for recording for fire rate
        timer += Time.deltaTime;
        if (timer >= fireRate)
        {

            //Fires gun
            if (Input.GetButtonDown("Fire1"))
            {

                //Records player position, direction, and rotation for spawning in projectile
                Vector3 playerPos = player.transform.position;
                Vector3 playerDir = player.transform.forward;
                Quaternion playerRot = player.transform.rotation;

                //Records the position to spawn in the projectile
                Vector3 spawnPos = playerPos + (playerDir * spawnDistance);

                timer = 0f;
                if (maxProj > 0 && staples.Count < maxCurrStaples)
                {

                    fireStapler();
                    GameObject proj2 = Instantiate(projectile, spawnPos, playerRot);
                    staples.Add(proj2);
                    maxProj--;

                }
                else
                {



                }

            }

        }

    }

    //Fires projectiles
    private void fireStapler()
    {

        Debug.DrawRay(firePoint.position, firePoint.forward * 100, Color.red, 2f);
        projectile.GetComponent<Rigidbody>().AddForce(transform.forward * speed);
        if (projectile != null)
        {

            Destroy(projectile, 3);
            projectile = null;

        }

        Ray ray = new Ray(firePoint.position, firePoint.forward);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, 100))
        {


        }

    }

    private void stapleHit()
    {



    }

}
