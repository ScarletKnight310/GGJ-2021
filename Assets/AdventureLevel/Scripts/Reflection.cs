using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reflection : MonoBehaviour
{
    public GameObject player;
    public GameObject Mirror;

    GameObject lastLightObject;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Light>().color = Mirror.GetComponent<MeshRenderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3.Distance(Mirror.transform.position, player.transform.position);
        //Vector3 playerPos = player.transform.position

        Vector3 reflectVec = Vector3.Reflect(transform.position - player.transform.position, Mirror.transform.up * -1f);

        Debug.DrawRay(transform.position, reflectVec * 10000f, Color.red);

        //ROTATION
        transform.LookAt(reflectVec * 10000f);

        RaycastHit hit;

        if (Physics.Raycast(transform.position, reflectVec, out hit, Mathf.Infinity))
        {
            if (hit.transform.gameObject.CompareTag("LightObjects"))
            {
                lastLightObject = hit.transform.gameObject;

                if (hit.transform.gameObject.GetComponent<Mirror>().lmb)
                    hit.transform.gameObject.GetComponent<Mirror>().l.enabled = true;
                else
                    hit.transform.gameObject.GetComponent<Mirror>().l.enabled = false;
            }
        }
    }
}
