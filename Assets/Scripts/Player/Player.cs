using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float movementSpeed = 7.0f;
    [SerializeField] GameInput gameInput;

    bool isWalking;
    Vector3 lastInteractDirection;


    // properties
    /// <summary>
    /// return the state of the input if it's active or not
    /// </summary>
    public bool IsWalking { get => isWalking; }


    private void Update()
    {
        HandleMovement();
        HanldeInteractions();
    }


    void HanldeInteractions()
    {
        Vector2 inputVector = gameInput.GetInputVectorNormalized();
        Vector3 moveDirection = new Vector3(inputVector.x, 0.0f, inputVector.y);

        if (moveDirection != Vector3.zero )
        {
            lastInteractDirection = moveDirection;
        }

        float interactionDistance = 2.0f;

        if (Physics.Raycast(transform.position, lastInteractDirection, out RaycastHit hit, interactionDistance))
        {
            Debug.Log(hit.collider.gameObject.name);
        }
        else
        {
            Debug.Log("-");
        }
    }

    void HandleMovement()
    {
        Vector2 inputVector = gameInput.GetInputVectorNormalized();

        Vector3 moveDirection = new Vector3(inputVector.x, 0.0f, inputVector.y);

        // check if the player is walking or stopped for the animation
        isWalking = (moveDirection != Vector3.zero);

        // chekc for collison to prevent the player from moving
        float moveDistance = Time.deltaTime * movementSpeed;
        float playerRadious = 0.7f;
        float playerHeight = 2.0f;
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadious, moveDirection, moveDistance);

        if (!canMove)
        {
            // check which direction the player can't move
            // check if the player can move in the x direction
            Vector3 moveDirectionX = new Vector3(moveDirection.x, 0.0f, 0.0f);
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadious, moveDirectionX, moveDistance);

            if (canMove)
            {
                // can move only in x
                moveDirection = moveDirectionX;
            }
            else
            {
                // check if the player can move in the z direction
                Vector3 moveDirectionZ = new Vector3(0.0f, 0.0f, moveDirection.z);
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadious, moveDirectionZ, moveDistance);

                if (canMove)
                {
                    // can move only in z
                    moveDirection = moveDirectionZ;
                }
                else
                {
                    // can't move at all
                }
            }
        }

        if (canMove)
        {
            transform.position += moveDirection * moveDistance;
        }

        float rotaionSpeed = 10.0f;
        transform.forward = Vector3.Slerp(transform.forward, moveDirection, Time.deltaTime * rotaionSpeed);
    }
}
