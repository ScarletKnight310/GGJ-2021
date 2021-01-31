using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;
    [SerializeField]
    private float moveSpeed = 100f;

    private void Awake()
    {
       
        characterController = GetComponent<CharacterController > ();
   
    }

    // Update is called once per frame
    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        var movement = new Vector3(horizontal, 0, vertical);
        
        characterController.SimpleMove(movement * Time.deltaTime * moveSpeed);

        Quaternion newDirection = Quaternion.LookRotation(movement);
        transform.rotation = newDirection;

    }
}
