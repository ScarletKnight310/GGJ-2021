using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gem : MonoBehaviour
{
    // Start is called before the first frame update
    public Material m;

    public bool charged;

    public GameObject chest;

    public Sprite openChest;

    public float shakeSpeed = 1f;
    public float shakeAmount = 1f;

    int i = 0;

    void Start()
    {
        GetComponent<SpriteRenderer>().color = m.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (charged)
        {


            chest.transform.position = new Vector3(Mathf.Sin(Time.time * shakeSpeed) * shakeAmount, chest.transform.position.y, chest.transform.position.z);

            if (i < 60)
                i++;
            else
                chest.GetComponent<SpriteRenderer>().sprite = openChest;


        }
        else
            i = 0;

    }
}
