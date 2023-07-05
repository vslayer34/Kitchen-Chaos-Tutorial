using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] SO_KitchenObject kitchenObject;


    // set the counter parent for the kitchen object
    private ClearCounter parentCounter;

    public SO_KitchenObject GetKitchenObjectSO() => kitchenObject;


    public void SetParentCounter(ClearCounter clearCounter)
    {
        // remove the old parent
        if (parentCounter != null)
        {
            parentCounter.ClearKitchenCounter();
        }

        // add to the new parent
        parentCounter = clearCounter;

        if (clearCounter.HasKitchenObject())
            Debug.Log("Error: the counter already has a kitchenobject");

        clearCounter.SetKitchenObject(this);

        // move the kitchen object visual to the new parent
        transform.parent = clearCounter.CounterTopPoint;
        transform.localPosition = Vector3.zero;
    }

    public ClearCounter GetParentCounter() => parentCounter;
}
