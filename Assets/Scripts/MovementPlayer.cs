using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    public float speed = 4.0f;
    public float gravity = -9.8f;
    public float volume = 1;
    public AudioClip audicC;
    private CharacterController charController;

    // Start is called before the first frame update
    void Start() { 
        charController=GetComponent<CharacterController>(); 
    }

    // Update is called once per frame
    void Update()
    {
        Vector2Int input = new Vector2Int((int)Input.GetAxisRaw("Horizontal"), (int)Input.GetAxisRaw("Vertical"));
        float deltaX = input.x * speed;
        float deltaZ = input.y * speed;
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);

        movement.y = gravity;

        movement *= Time.deltaTime;

        movement = transform.TransformDirection(movement);

        if ((!(input.x == 0) || !(input.y == 0)) && !GetComponent<AudioSource>().isPlaying) {
            GetComponent<AudioSource>().PlayOneShot(audicC, volume);
        }
        charController.Move(movement);


    }
}
