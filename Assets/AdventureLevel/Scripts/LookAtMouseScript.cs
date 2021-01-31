using UnityEngine;
using System.Collections;

public class LookAtMouseScript : MonoBehaviour
{
    private Vector3 mousePos;
    public float speed;
    public float rayDistance = 5f;
    public static bool ray1Overlap = false;

    GameObject nextLight;

    

    void Update()
    {
        //ROTATION
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 dir = Input.mousePosition - pos;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        bool lmb = Input.GetKey(KeyCode.Mouse0);

        RaycastHit hit;

        if (lmb)
        {
            Debug.DrawRay(transform.position, Input.mousePosition - pos, Color.red);

            if (Physics.Raycast(transform.position, Input.mousePosition - pos, out hit, Mathf.Infinity))
            {
                if (hit.transform.gameObject.CompareTag("LightObjects"))
                {
                    if (nextLight == null)
                    {
                        nextLight = hit.transform.gameObject;

                        nextLight.GetComponent<Mirror>().i++;
                        
                        print(nextLight.gameObject.name + " " + nextLight.GetComponent<Mirror>().i);
                    }

                    nextLight.GetComponent<Mirror>().l.enabled = true;
                    
                    nextLight.GetComponent<Mirror>().canReflect = true;

                    nextLight.GetComponent<Mirror>().prevLight = gameObject;

                    nextLight.transform.GetChild(0).transform.position = new Vector3(hit.point.x, hit.point.y, nextLight.transform.GetChild(0).transform.position.z);

                }
                else
                    ResetFL();
            }
            else
                ResetFL();
        }
        else
            ResetFL();
    }

    void ResetFL()
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