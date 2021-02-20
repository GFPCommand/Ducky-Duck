using UnityEngine;
using UnityEngine.UI;

public class SkinsShop : MonoBehaviour
{
    public static bool isSkinsShop;
    private int coins;
    private string birdsBuy;
    public Button[] ButtonsForBuyingBirds = new Button[4];
    public Text[] TextOnButtons = new Text[4];
    public GameObject IAPStore, noAds, SkinsShopObj, Plus;
    public Text mainText;
    public Button GetCoinsButton;

    public void FirstBirdBuyButton()
    {
        PlayerPrefs.SetInt("BirdActive", 1);

        for (int i = 0; i < 4; i++)
        {
            if (i == PlayerPrefs.GetInt("BirdActive") - 1)
                ButtonsForBuyingBirds[i].interactable = false;
            else
                ButtonsForBuyingBirds[i].interactable = true;
        }
    }

    public void SecondBirdBuyButton()
    {
        coins = PlayerPrefs.GetInt("Coins");

        if (coins >= 150 && !PlayerPrefs.GetString("BirdsBuy").Contains("2"))
        {
            PlayerPrefs.SetInt("Coins", coins -= 150);

            TextOnButtons[1].text = "Use";

            birdsBuy = PlayerPrefs.GetString("BirdsBuy");

            PlayerPrefs.SetString("BirdsBuy", birdsBuy += "2");
        } else if (coins <= 150 && !PlayerPrefs.GetString("BirdsBuy").Contains("2"))
        {
            Activate_IAPStore();
        } else if (PlayerPrefs.GetString("BirdsBuy").Contains("2"))
        {
            PlayerPrefs.SetInt("BirdActive", 2);

            for (int i = 0; i < 4; i++)
            {
                if (i == PlayerPrefs.GetInt("BirdActive") - 1)
                    ButtonsForBuyingBirds[i].interactable = false;
                else
                    ButtonsForBuyingBirds[i].interactable = true;
            }
        }
    }

    public void ThirdBirdBuyButton()
    {
        coins = PlayerPrefs.GetInt("Coins");

        if (coins >= 200 && !PlayerPrefs.GetString("BirdsBuy").Contains("3"))
        {
            PlayerPrefs.SetInt("Coins", coins -= 200);

            TextOnButtons[2].text = "Use";

            birdsBuy = PlayerPrefs.GetString("BirdsBuy");

            PlayerPrefs.SetString("BirdsBuy", birdsBuy += "3");
        } else if (coins <= 200 && !PlayerPrefs.GetString("BirdsBuy").Contains("3"))
        {
            Activate_IAPStore();
        } else if (PlayerPrefs.GetString("BirdsBuy").Contains("3"))
        {
            PlayerPrefs.SetInt("BirdActive", 3);

            for (int i = 0; i < 4; i++)
            {
                if (i == PlayerPrefs.GetInt("BirdActive") - 1)
                    ButtonsForBuyingBirds[i].interactable = false;
                else
                    ButtonsForBuyingBirds[i].interactable = true;
            }
        }
    }

    public void FourthBirdBuyButton()
    {
        coins = PlayerPrefs.GetInt("Coins");

        if (coins >= 250 && !PlayerPrefs.GetString("BirdsBuy").Contains("4"))
        {
            PlayerPrefs.SetInt("Coins", coins -= 250);

            TextOnButtons[3].text = "Use";

            birdsBuy = PlayerPrefs.GetString("BirdsBuy");

            PlayerPrefs.SetString("BirdsBuy", birdsBuy += "4");
        } else if (coins <= 250 && !PlayerPrefs.GetString("BirdsBuy").Contains("4"))
        {
            Activate_IAPStore();
        } else if (PlayerPrefs.GetString("BirdsBuy").Contains("4"))
        {
            PlayerPrefs.SetInt("BirdActive", 4);

            for (int i = 0; i < 4; i++)
            {
                if (i == PlayerPrefs.GetInt("BirdActive") - 1)
                    ButtonsForBuyingBirds[i].interactable = false;
                else
                    ButtonsForBuyingBirds[i].interactable = true;
            }
        }
    }

    public void Activate_IAPStore()
    {
        if (IAP_Store.adsCountForCoins >= 3) GetCoinsButton.interactable = false;

        mainText.text = "Buy coins";

        isSkinsShop = false;

        SkinsShopObj.SetActive(false);
        Plus.SetActive(false);

        IAPStore.SetActive(true);

        if (PlayerPrefs.GetString("NoAds").Equals("True"))
            noAds.SetActive(false);
        else noAds.SetActive(true);
    }
}