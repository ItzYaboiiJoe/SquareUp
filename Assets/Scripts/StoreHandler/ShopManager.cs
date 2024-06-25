using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public int coins;
    public TMP_Text coinUI;
    public ShopItemSO[] shopItemSO;
    public GameObject[] shopPanelsGO;
    public ShopTemplate[] shopPanels;
    public Button[] myPurchaseBtns;

    private void Start()
    {
        for(int i = 0; i < shopItemSO.Length; i++)
        {
            shopPanelsGO[i].SetActive(true);
        }
        LoadPanels();
        CheckPurhaseable();
        UpdateCoinUI();

    }

    public void AddCoins()
    {
        coins++;
        UpdateCoinUI();
        CheckPurhaseable();
    }
        public void CheckPurhaseable()
        {
            for (int i = 0; i < shopItemSO.Length; i++)
            {
            if (coins >= shopItemSO[i].baseCost)
                myPurchaseBtns[i].interactable = true;
            else
                myPurchaseBtns[i].interactable = false;
            }
            
        }
    public void purchaseItem(int btnNo)
    {
       if(coins >= shopItemSO[btnNo].baseCost)
        {
            coins = coins - shopItemSO[btnNo].baseCost;
            UpdateCoinUI();
            CheckPurhaseable();
            //unloks item
        }
    }

    public void LoadPanels()
    {
        for(int i = 0; i < shopItemSO.Length; i++)
        {
            shopPanels[i].titleText.text = shopItemSO[i].title;
            shopPanels[i].descriptionTxt.text = shopItemSO[i].description;
            shopPanels[i].costTxt.text = "Coins: " + shopItemSO[i].baseCost.ToString();
            shopPanels[i].skinImage.sprite = shopItemSO[i].skinImage;
        }
    }
    private void UpdateCoinUI()
    {
        coinUI.text = "Coins: " + coins.ToString();
    }
}
