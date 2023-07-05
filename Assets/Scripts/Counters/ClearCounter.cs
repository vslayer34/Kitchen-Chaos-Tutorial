using Unity.VisualScripting;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField] Transform counterTopPoint;
    [SerializeField] SO_KitchenObject kitchenObjectSO;
    [SerializeField] ClearCounter secondCounter;
    bool testing = true;
    
    // get the spawned kitchen object
    private KitchenObject kitchenObject;


    // properties
    public Transform CounterTopPoint => counterTopPoint;


    // methods
    private void Update()
    {
        if (testing && Input.GetKeyDown(KeyCode.T))
        {
            if (kitchenObject != null)
            {
                kitchenObject.SetParentCounter(secondCounter);
                //Debug.Log(kitchenObject.GetParentCounter());
            }
            testing = false;
        }
    }


    public void Interact()
    {
        // let the counter know that it spawned a kitchen objectt so not to spawn it again
        if (kitchenObject == null)
        {
            Transform kitchenObjectPrefab = Instantiate(kitchenObjectSO.prefab, counterTopPoint);
            kitchenObjectPrefab.localPosition = Vector3.zero;

            kitchenObject = kitchenObjectPrefab.GetComponent<KitchenObject>();
            kitchenObject.SetParentCounter(this);
        }
    }

    public void ClearKitchenCounter()
    {
        kitchenObject = null;
    }

    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;
    }

    public KitchenObject GetKitchenObject() => kitchenObject;

    public bool HasKitchenObject() => kitchenObject != null;
}
