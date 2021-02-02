using UnityEngine;
using System.Collections;

public class LookAtMouseScript : MonoBehaviour
{
    private Vector3 mousePos;
    public float speed;
    public float rayDistance = 5f;
    public static bool ray1Overlap = false;

    public GameObject reaper;

    bool dead;

    GameObject nextLight;

    public float vecDistance = 500f;

    public int i = -1000;

    public float offsetX;
    public float offsetY;

    public float damping = 1f;

    void Update()
    {
        if (!Player.dead)
        {
            if (Input.GetKey(KeyCode.F1))
                offsetX -= 1f;
            if (Input.GetKey(KeyCode.F2))
                offsetX += 1f;

            if (Input.GetKey(KeyCode.F3))
                offsetY -= 1f;
            if (Input.GetKey(KeyCode.F4))
                offsetY += 1f;

            //ROTATION
            Vector3 realMouse = (new Vector3(Input.mousePosition.x - offsetX, Input.mousePosition.y - offsetY, Input.mousePosition.z) - transform.position) * vecDistance;
            float angle = Mathf.Atan2(realMouse.y, realMouse.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            bool lmb = Input.GetKey(KeyCode.Mouse0);

            RaycastHit hit;

            // Bit shift the index of the layer (8) to get a bit mask
            int layerMask = 1 << 9;

            // This would cast rays only against colliders in layer 8.
            // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
            layerMask = ~layerMask;

            if (lmb)
            {
                Debug.DrawRay(transform.position, realMouse * vecDistance, Color.red);

                if (Physics.Raycast(transform.position, realMouse, out hit, vecDistance, layerMask))
                {
                    if (hit.transform.gameObject.CompareTag("LightObjects"))
                    {
                        //if (nextLight == null)
                        //{
                            nextLight = hit.transform.gameObject;

                        //}
                        nextLight.GetComponent<Mirror>().l.enabled = true;

                        nextLight.GetComponent<Mirror>().canReflect = true;

                        nextLight.GetComponent<Mirror>().prevLight = gameObject;

                        nextLight.transform.GetChild(0).transform.position = new Vector3(hit.point.x, hit.point.y, nextLight.transform.GetChild(0).transform.position.z);
                    }
                    else if (hit.transform.gameObject.CompareTag("Enemy"))
                    {

                        if (!hit.transform.gameObject.GetComponent<Reaper>().dead && !hit.transform.gameObject.GetComponent<Reaper>().isBoss || hit.transform.gameObject.GetComponent<Reaper>().isBoss && !hit.transform.gameObject.GetComponent<Reaper>().dead && Flashlight.super )
                        {
                            print("here2"); 
                            hit.transform.gameObject.SendMessage("Damage", 1f);
                        }
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
        
    }

    void ResetFL()
    {
        if (nextLight != null)
        {
            nextLight.GetComponent<Mirror>().canReflect = false;
            nextLight.GetComponent<Mirror>().prevLight = null;

            nextLight.GetComponent<Mirror>().l.enabled = false;

            nextLight = null;
        }
    }
}