using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reflection : MonoBehaviour
{
    public GameObject player;
    public GameObject Mirror;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (LookAtMouseScript.hitNormal != null)
            transform.LookAt(Vector3.Reflect(player.transform.position, LookAtMouseScript.hitNormal));
    }
}
