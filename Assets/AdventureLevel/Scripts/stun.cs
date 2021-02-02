using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stun : MonoBehaviour
{
    

    public bool enemyCollided;

    GameObject enemy;

    bool rmb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        rmb = Input.GetKey(KeyCode.Mouse1);

    }

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.CompareTag("Enemy") && rmb)
        {
            other.gameObject.GetComponent<EnemyFollow>().chase = false;

        }
    }
}
