using UnityEngine;

public class ClearCounter : BaseCounter, IKitchenObjectParent
{
    [SerializeField] SO_KitchenObject kitchenObjectSO;
 
    public override void Interact(Player player) { }
}
