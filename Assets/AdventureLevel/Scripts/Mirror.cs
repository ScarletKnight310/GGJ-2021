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

    public float vecDistance = 500f;

    GameObject lastGem;

    public GameObject reaperBoss;

    public bool bossMirror;

    Transform lightPos;


    private void Start()
    {  
        l = gameObject.transform.GetChild(0).GetComponent<Light>();
        l.color = GetComponent<MeshRenderer>().material.color;
        lightPos = l.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.DrawRay(transform.position, gameObject.transform.up * -1000f, Color.red);

        lmb = Input.GetKey(KeyCode.Mouse0);

        if (lmb && canReflect && !Flashlight.super)
        {
            //CURRENT REFLECTION
            reflectVec = Vector3.Reflect(l.transform.position - prevLight.transform.position, transform.up * -1f);

            RaycastHit hit;

            //ROTATION
            l.transform.LookAt(reflectVec * 500f);

            //NEXT REFLECTION
            Debug.DrawRay(l.transform.position, reflectVec * vecDistance, Color.red);
            
            // Bit shift the index of the layer (9) to get a bit mask
            int layerMask = 1 << 9;

            // This would cast rays only against colliders in layer 9.
            // But instead we want to collide against everything except layer 9. The ~ operator does this, it inverts a bitmask.
            layerMask = ~layerMask;

            //RAYCAST 1
            if (Physics.Raycast(l.transform.position, reflectVec, out hit, vecDistance, layerMask))
            {
                if (hit.transform.gameObject.CompareTag("LightObjects"))
                {
                    if (nextLight == null)
                    {
                        nextLight = hit.transform.gameObject;

                    }

                    nextLight.GetComponent<Mirror>().l.enabled = true;

                    nextLight.GetComponent<Mirror>().prevLight = l.gameObject;

                    nextLight.GetComponent<Mirror>().canReflect = true;

                    nextLight.transform.GetChild(0).transform.position = new Vector3(hit.point.x, hit.point.y, nextLight.transform.GetChild(0).transform.position.z);
                }
                else
                    ResetL();

                if (hit.transform.gameObject.CompareTag("Gem"))
                {
                    lastGem = hit.transform.gameObject;

                    if (GetComponent<MeshRenderer>().material.color == hit.transform.gameObject.GetComponent<SpriteRenderer>().color)
                    {

                        lastGem.GetComponent<gem>().charged = true;

                    }
                    else
                        lastGem.GetComponent<gem>().charged = false;
                }
                else
                {
                    if (lastGem != null)
                        lastGem.GetComponent<gem>().charged = false;
                }

                if (hit.transform.gameObject.CompareTag("Enemy"))
                {
                    if (bossMirror && hit.transform.gameObject.GetComponent<Reaper>().isBoss && !hit.transform.gameObject.GetComponent<Reaper>().dead && l.color == hit.transform.gameObject.GetComponent<Reaper>().mats[reaperBoss.GetComponent<Reaper>().currentMat].color)
                    {
                        hit.transform.gameObject.SendMessage("Damage", 1f);
                    }
                }
            }
            else
            {
                ResetL();
                //print(gameObject.name + " no hit reset");
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
        if (lastGem != null)
            lastGem.GetComponent<gem>().charged = false;

        if (nextLight != null)
        {
            nextLight.GetComponent<Mirror>().canReflect = false;
            nextLight.GetComponent<Mirror>().prevLight = null;

            nextLight.GetComponent<Mirror>().l.enabled = false;

            nextLight = null;
        }
    }

}
