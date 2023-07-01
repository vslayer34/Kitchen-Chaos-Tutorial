using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float movementSpeed = 7.0f;

    private bool isWalking;


    // properties
    /// <summary>
    /// return the state of the input if it's active or not
    /// </summary>
    public bool IsWalking { get => isWalking; }


    private void Update()
    {
        Vector2 inputVector = new Vector2(0.0f, 0.0f);
        
        if (Input.GetKey(KeyCode.W))
        {
            inputVector.y = 1.0f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputVector.y = -1.0f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputVector.x = 1.0f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputVector.x = -1.0f;
        }

        inputVector = inputVector.normalized;

        Vector3 moveDirection = new Vector3(inputVector.x, 0.0f, inputVector.y);

        // check if the player is walking or stopped
        isWalking = (moveDirection != Vector3.zero);

        transform.position += moveDirection * movementSpeed * Time.deltaTime;

        float rotaionSpeed = 10.0f;
        transform.forward = Vector3.Slerp(transform.forward, moveDirection, Time.deltaTime * rotaionSpeed);
    }
}
