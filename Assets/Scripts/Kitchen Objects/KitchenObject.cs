using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] SO_KitchenObject kitchenObject;


    // set the counter parent for the kitchen object
    private IKitchenObjectParent kitchenObjectParent;

    public SO_KitchenObject GetKitchenObjectSO() => kitchenObject;


    public static KitchenObject SpawnKitchenObject(SO_KitchenObject kitchenObjectSo, IKitchenObjectParent parent)
    {
        Transform kitchenObjectPrefab = Instantiate(kitchenObjectSo.prefab);
        KitchenObject kitchenObject = kitchenObjectPrefab.GetComponent<KitchenObject>();
        kitchenObject.SetParentCounter(parent);
        kitchenObjectPrefab.localPosition = Vector3.zero;

        return kitchenObject;
    }

    public void SetParentCounter(IKitchenObjectParent newKitchenObjectParent)
    {
        // remove the old parent
        if (kitchenObjectParent != null)
        {
            kitchenObjectParent.ClearKitchenCounter();
        }

        // add to the new parent
        kitchenObjectParent = newKitchenObjectParent;

        if (kitchenObjectParent.HasKitchenObject())
        {
            Debug.LogError("Error: the counter already has a kitchenobject");
        }

        newKitchenObjectParent.SetKitchenObject(this);

        // move the kitchen object visual to the new parent
        transform.parent = newKitchenObjectParent.GetCounterTopPoint();
        transform.localPosition = Vector3.zero;
    }

    public IKitchenObjectParent GetParentCounter() => kitchenObjectParent;

    public void DestroySelf()
    {
        kitchenObjectParent.ClearKitchenCounter();

        Destroy(gameObject);
    }
}
