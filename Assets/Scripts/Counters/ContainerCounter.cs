using UnityEngine;

public class ContainerCounter : BaseCounter, IKitchenObjectParent
{
    [SerializeField] private SO_KitchenObject kitchenObjectSO;

    public override void Interact(Player player)
    {
        Transform kitchenObjectPrefab = Instantiate(kitchenObjectSO.prefab);
        kitchenObjectPrefab.GetComponent<KitchenObject>().SetParentCounter(player);
        kitchenObjectPrefab.localPosition = Vector3.zero;
    }
}
