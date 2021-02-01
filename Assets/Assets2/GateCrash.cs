using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateCrash : MonoBehaviour
{
    public float timer;
    public float lifeTime = 1.5f;

    public void Crash()
    {
        AudioSource audio = gameObject.GetComponent<AudioSource>();
        if (audio != null)
        {
            audio.Play();

        }

    }

    // Start is called before the first frame update
    void Awake()
    {
        timer = lifeTime;
        
    }

    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // timer -= Time.deltaTime;
        if (timer <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
