using UnityEngine;

public class ClearCounter : BaseCounter, IKitchenObjectParent
{
    [SerializeField] SO_KitchenObject kitchenObjectSO;
 
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
}
