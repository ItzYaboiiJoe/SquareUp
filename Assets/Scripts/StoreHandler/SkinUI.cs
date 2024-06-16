using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinUI : MonoBehaviour
{
    public Image skinImage;
    public Text skinNameText;
    public Text skinCostText;
    public Button purchaseButton;
    public Button equipButton;

    private Skin currentSkin;
    private StoreManager storeManager;

    public void SetSkin(Skin skin, StoreManager manager)
    {
        currentSkin = skin;
        storeManager = manager;
        skinImage.sprite = skin.skinSprite;
        skinNameText.text = skin.skinName;
        skinCostText.text = skin.isPurchased ? "Purchased" : "Cost: " + skin.cost;
        purchaseButton.interactable = !skin.isPurchased;
        equipButton.interactable = skin.isPurchased;

        purchaseButton.onClick.AddListener(() => PurchaseSkin());
        equipButton.onClick.AddListener(() => EquipSkin());
    }

    void PurchaseSkin()
    {
        storeManager.PurchasedSkins(currentSkin);
        SetSkin(currentSkin, storeManager);
    }
    void EquipSkin()
    {
        storeManager.EquipSkin(currentSkin);
        //Additional things to be done to make skin visible for user
    }
}
