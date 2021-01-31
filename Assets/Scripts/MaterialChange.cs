using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChange : MonoBehaviour
{

    public Material materialPos;
    public Material materialNeg;
    public GameObject poster;
    public GameObject projectile;

    private int i = 0;
    // Start is called before the first frame update
    void Start()
    {

        poster.GetComponent<MeshRenderer>().material = materialPos;

    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKey(KeyCode.H))
        {

            if(i % 2 == 0)
            {

                poster.GetComponent<MeshRenderer>().material = materialNeg;

            }

        }
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.tag == "projectile")
        {

            poster.GetComponent<MeshRenderer>().material = materialNeg;
            Shoot.instance.SendMessage("stapleHit", collision.collider.gameObject);

        }

    }

}
