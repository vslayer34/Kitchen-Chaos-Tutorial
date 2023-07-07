using System;
using UnityEngine;

public class ContainerCounter : BaseCounter, IKitchenObjectParent
{
    // fire an event when the player interact with the container counter
    public event EventHandler OnPlayerGrabbingObject;

    [SerializeField] private SO_KitchenObject kitchenObjectSO;

    public override void Interact(Player player)
    {
        Transform kitchenObjectPrefab = Instantiate(kitchenObjectSO.prefab);
        kitchenObjectPrefab.GetComponent<KitchenObject>().SetParentCounter(player);
        kitchenObjectPrefab.localPosition = Vector3.zero;

        OnPlayerGrabbingObject?.Invoke(this, EventArgs.Empty);
    }
}
