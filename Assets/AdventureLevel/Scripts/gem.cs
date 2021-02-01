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
    int j = 0;

    float startShakeX = 0f;


    void Start()
    {
        GetComponent<SpriteRenderer>().color = m.color;
    }

    // Update is called once per frame
    void Update()
    {

        if (charged)
        {

            if (j < 1)
            {
                startShakeX = chest.transform.position.x;
                j++;
            }

            if (i < 60)
            {
                //SHAKE
                chest.transform.position = new Vector3(startShakeX + Mathf.Sin(Time.time * shakeSpeed) * shakeAmount, chest.transform.position.y, chest.transform.position.z);

                i++;
            }
            else
                chest.GetComponent<SpriteRenderer>().sprite = openChest;


        }
        else
        {
            i = 0;
            j = 0;
        }

    }
}
