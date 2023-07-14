using System;
using UnityEngine;

public class ContainerCounter : BaseCounter, IKitchenObjectParent
{
    // fire an event when the player interact with the container counter
    public event EventHandler OnPlayerGrabbingObject;

    [SerializeField] private SO_KitchenObject kitchenObjectSO;

    public override void Interact(Player player)
    {
        // if the player isn't caryying anything
        if (!player.HasKitchenObject())
        {
            KitchenObject.SpawnKitchenObject(kitchenObjectSO, player);

            OnPlayerGrabbingObject?.Invoke(this, EventArgs.Empty);
        }
    }
}
