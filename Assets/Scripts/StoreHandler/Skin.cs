using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSkin", menuName = "Store/Skin")]
public class Skin : ScriptableObject
{
    public string skinName;
    public Sprite skinSprite;
    public int cost;
    public bool isPurchased;
}
