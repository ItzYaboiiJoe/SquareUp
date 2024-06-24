using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "shopMenu", menuName = "Scriptable Objects/new Shop Item", order = 1)]
public class ShopItemSO : ScriptableObject
{
    public string title;
//public Image skinImage;
    public string description;
    public int baseCost;
}
