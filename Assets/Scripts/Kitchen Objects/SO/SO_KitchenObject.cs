using UnityEngine;

[CreateAssetMenu(fileName = "Properties", menuName = "Kitchen Objects/Ingredients")]
public class SO_KitchenObject : ScriptableObject
{
    public Transform prefab;
    public Sprite icon;
    public string objectName;
}