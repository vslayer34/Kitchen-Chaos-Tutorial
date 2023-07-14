using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter
{
    [SerializeField] SO_KitchenObject cutKitchenObject;
    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            // The Counter is empty
            if (player.HasKitchenObject())
            {
                // The player is carrying something
                player.GetKitchenObject().SetParentCounter(this);
            }
            else
            {
                // The player hands are empty
            }
        }
        else
        {
            // There's a kitchen object up here

            if (player.HasKitchenObject())
            {
                // the player is carrying something
            }
            else
            {
                // the player isn't caryying anything
                GetKitchenObject().SetParentCounter(player);
            }
        }
    }

    public override void InteractAlternative(Player player)
    {
        if (HasKitchenObject())
        {
            // there is a kitchenobject here
            GetKitchenObject().DestroySelf();

            KitchenObject.SpawnKitchenObject(cutKitchenObject, this);
        }
    }
}
