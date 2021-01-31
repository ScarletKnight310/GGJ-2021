using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour
{
    public Light l;

    public bool lmb;

    public GameObject player;

    Vector3 reflectVec;

    public GameObject nextLight;

    public bool canReflect = false;

    public GameObject prevLight;

    public int i = 0;

    //public bool isReflecting;



    private void Start()
    {  
        l = gameObject.transform.GetChild(0).GetComponent<Light>();
        l.color = GetComponent<MeshRenderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.DrawRay(transform.position, gameObject.transform.up * -1000f, Color.red);

        lmb = Input.GetKey(KeyCode.Mouse0);

        if (lmb && canReflect)
        {
            //CURRENT REFLECTION
            reflectVec = Vector3.Reflect(l.transform.position - prevLight.transform.position, transform.up * -1f);

            RaycastHit hit;

            

            //ROTATION
            l.transform.LookAt(reflectVec * 10000f);

            //NEXT REFLECTION
            if (i < 2)
            {
                Debug.DrawRay(l.transform.position, reflectVec * 10000f, Color.red);

                if (Physics.Raycast(l.transform.position, reflectVec, out hit, Mathf.Infinity))
                {
                    if (hit.transform.gameObject.CompareTag("LightObjects"))
                    {
                        if (nextLight == null)
                        {
                            nextLight = hit.transform.gameObject;

                            nextLight.GetComponent<Mirror>().i++;

                            print(nextLight.name + " " + i);
                        }

                        nextLight.GetComponent<Mirror>().l.enabled = true;

                        nextLight.GetComponent<Mirror>().prevLight = l.gameObject;

                        nextLight.GetComponent<Mirror>().canReflect = true;

                        nextLight.transform.GetChild(0).transform.position = new Vector3(hit.point.x, hit.point.y, nextLight.transform.GetChild(0).transform.position.z);
                    }
                    else
                    {
                        ResetL();
                        //print( gameObject.name + " not a light object reset");
                    }
                }
                else
                {
                    ResetL();
                    //print(gameObject.name + " no hit reset");
                }
            }
        }
        else
        {
            ResetL();
            //print(gameObject.name + " no input or previous reflect");
        }
    }

    void ResetL()
    {
        if (nextLight != null)
        {
            nextLight.GetComponent<Mirror>().canReflect = false;
            nextLight.GetComponent<Mirror>().prevLight = null;

            nextLight.GetComponent<Mirror>().l.enabled = false;

            nextLight.GetComponent<Mirror>().i = 0;

            nextLight = null;
        }
    }
}
