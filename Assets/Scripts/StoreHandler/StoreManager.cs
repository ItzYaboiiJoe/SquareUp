using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour
{
    public List<Skin> availibleSkins;
    public Transform skinContainer;
    public GameObject skinPrefab;
    public Text CurrencyText;

    private int playerCurrency = 500; //Sample player curreny for tesdting

    private void Start()
    {
        UpdateCurrencyUI();
        LoadSkins();
    }

    void LoadSkins()
    {
        foreach(var skin in availibleSkins)
        {
            GameObject skinObj = Instantiate(skinPrefab, skinContainer);
            SkinUI skinUI = skinObj.GetComponent<SkinUI>();
            skinUI.SetSkin(skin, this);
        }
    }

    public void PurchasedSkins(Skin skin)
    {
        if(playerCurrency >= skin.cost && !skin.isPurchased)
        {
            playerCurrency -= skin.cost;
            skin.isPurchased = true;
            UpdateCurrencyUI();
        }
    }

    public void EquipSkin(Skin skin)
    {
        //TODO: Add code to configure skin
        // Will implement into playerController for ENABLE
    }
    void UpdateCurrencyUI()
    {
        CurrencyText.text = "Currency" + playerCurrency.ToString();
    }
}
