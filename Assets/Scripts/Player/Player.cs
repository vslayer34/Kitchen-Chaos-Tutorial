using System;
using UnityEngine;

public class Player : MonoBehaviour, IKitchenObjectParent
{
    #region Singleton
    public static Player Instance { get; private set; }
    #endregion

    public event EventHandler<OnSelectedCounterChangedEventArgs> OnSelectedCounterChanged;
    public class OnSelectedCounterChangedEventArgs : EventArgs
    {
        public BaseCounter SelectedCounter { get; set; }
    }

    [SerializeField] float movementSpeed = 7.0f;
    [SerializeField] GameInput gameInput;
    [SerializeField] LayerMask layerMask;
    [SerializeField] Transform kitchenObjectHoldingPoint;


    // get the spawned kitchen object
    private KitchenObject kitchenObject;

    bool isWalking;
    Vector3 lastInteractDirection;
    BaseCounter selectedCounter;


    // properties
    /// <summary>
    /// return the state of the input if it's active or not
    /// </summary>
    public bool IsWalking { get => isWalking; }


    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("More than one instance of the player.");
        }
        Instance = this;
    }


    void Start()
    {
        gameInput.OnInteractionAction += GameInput_OnInteractionAction;
        gameInput.OnInteractionAlternativeAction += GameInput_OnInteractionAlternativeAction;
    }

    private void GameInput_OnInteractionAction(object sender, EventArgs e)
    {
        selectedCounter?.Interact(this);
    }

    private void GameInput_OnInteractionAlternativeAction(object sender, EventArgs e)
    {
        selectedCounter?.InteractAlternative(this);
    }

    private void Update()
    {
        HandleMovement();
        HandleInteractions();
    }


    void HandleInteractions()
    {
        Vector2 inputVector = gameInput.GetInputVectorNormalized();
        Vector3 moveDirection = new Vector3(inputVector.x, 0.0f, inputVector.y);

        // get the last interaction so it remebers the interaction without the player moving
        if (moveDirection != Vector3.zero)
        {
            lastInteractDirection = moveDirection;
        }

        float interactionDistance = 2.0f;

        if (Physics.Raycast(transform.position, lastInteractDirection, out RaycastHit hit, interactionDistance, layerMask))
        {
            // Try to get the ClearCounter script to identify the object the player collided with
            if (hit.transform.TryGetComponent(out BaseCounter counter))
            {
                if (counter != selectedCounter)
                {
                    SetSelectedCounter(counter);
                }
            }
            else
            {
                SetSelectedCounter(null);
            }
        }
        else
        {
            SetSelectedCounter(null);
        }
    }


    /// <summary>
    /// Set the selected counter when the player goes near it
    /// </summary>
    /// <param name="clearCounter">referance to the counter the player selected</param>
    void SetSelectedCounter(BaseCounter baseCounter)
    {
        // set the selected counter and fire an event that it was selected
        selectedCounter = baseCounter;

        OnSelectedCounterChanged?.Invoke(this, new OnSelectedCounterChangedEventArgs { SelectedCounter = selectedCounter });
    }

    /// <summary>
    /// Handle the player movement
    /// </summary>
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
            canMove = moveDirectionX.x != 0 && !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadious, moveDirectionX, moveDistance);

            if (canMove)
            {
                // can move only in x
                moveDirection = moveDirectionX;
            }
            else
            {
                // check if the player can move in the z direction
                Vector3 moveDirectionZ = new Vector3(0.0f, 0.0f, moveDirection.z);
                canMove = moveDirectionX.y != 0 && !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadious, moveDirectionZ, moveDistance);

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

    // IKitchenObjectInterface Implementaion
    public Transform GetCounterTopPoint() => kitchenObjectHoldingPoint;


    public void ClearKitchenCounter()
    {
        kitchenObject = null;
    }

    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;
    }

    public KitchenObject GetKitchenObject() => kitchenObject;

    public bool HasKitchenObject()
    {
        Debug.Log(kitchenObject != null);
        return kitchenObject != null;
    }
}
