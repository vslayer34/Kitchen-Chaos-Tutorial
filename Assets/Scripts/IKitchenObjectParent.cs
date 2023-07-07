using UnityEngine;

public interface IKitchenObjectParent
{
    public Transform GetCounterTopPoint();
    public void ClearKitchenCounter();

    public void SetKitchenObject(KitchenObject kitchenObject);

    public KitchenObject GetKitchenObject();

    public bool HasKitchenObject();
}
