using UnityEngine;


[CreateAssetMenu(fileName = "newShopItem", menuName = "Scriptable Objects/new Shop Item", order = 1)]
public class ShopItemSO : ScriptableObject
{
    public string title;
    public Sprite skinImage;
    public string description;
    public int baseCost;
}
