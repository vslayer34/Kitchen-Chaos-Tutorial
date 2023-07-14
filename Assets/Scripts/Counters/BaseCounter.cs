using System;
using UnityEngine;
using UnityEngine.UI;

public class BaseCounter : MonoBehaviour, IKitchenObjectParent
{
    [SerializeField] protected Transform counterTopPoint;

    protected KitchenObject kitchenObject;

    
    public virtual void Interact(Player player) { }
    public virtual void InteractAlternative(Player player) { }


    public Transform GetCounterTopPoint() => counterTopPoint;

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
