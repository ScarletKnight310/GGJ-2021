using UnityEngine;
using System.Collections;

public class LookAtMouseScript : MonoBehaviour
{
    private Vector3 mousePos;
    public float speed;
    public float rayDistance = 5f;
    public bool rayOverlap = false;

    GameObject lastLightObject;

    public static Vector3 hitNormal;

    void Update()
    {
        //ROTATION
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 dir = Input.mousePosition - pos;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);


        //Debug.DrawRay(transform.position, Input.mousePosition - pos, Color.red);

        RaycastHit hit;

        int layerMask = 1 << 8;

        if (Physics.Raycast(transform.position, Input.mousePosition - pos, out hit, Mathf.Infinity, layerMask))
        {
            rayOverlap = true;

            lastLightObject = hit.transform.gameObject;

            hitNormal = hit.normal;

            if(hit.transform.gameObject.GetComponent<Mirror>().lmb)
                hit.transform.gameObject.GetComponent<Mirror>().l.enabled = true;
            else
                hit.transform.gameObject.GetComponent<Mirror>().l.enabled = false;

        }
        else
        {
            rayOverlap = false;

            if (lastLightObject != null)
                lastLightObject.GetComponent<Mirror>().l.enabled = false;
        }
    }
}