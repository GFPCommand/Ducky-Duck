using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class Shop : MonoBehaviour
{
    private int coins, rand;
    private int ExtraLifes, Shields, DoubleCoins, Presents;
    public static int CheckShop = 0, adsCountForPresents = 0;
    public static bool isShop;

    public Sprite[] productSprites;
    public Image GetPresent;

    public Text CountCoins, mainText, Count;
    public Text upText, downText, secondButtonText;
    public Text firstNum, secondNum;

    public Button button, GetCoinsButton;

    public GameObject[] products;

    public GameObject IAPStore, BoostersShop, PresentButton, noAds, SkinsShopObj, Plus, PresentMenu, GetPresentMenu, OpenPresentMenuObj;

    public void FirstButton()
    {
        switch (CheckShop)
        {
            case 0:
                coins = PlayerPrefs.GetInt("Coins");
                if (coins >= 50)
                {
                    ExtraLifes = PlayerPrefs.GetInt("ExtraLife");
                    PlayerPrefs.SetInt("ExtraLife", ++ExtraLifes);
                    PlayerPrefs.SetInt("Coins", coins -= 50);
                    CountCoins.text = PlayerPrefs.GetInt("Coins").ToString();
                    firstNum.text = "x" + PlayerPrefs.GetInt("ExtraLife").ToString();
                }
                else
                {
                    Activate_IAPStore();
                    isShop = false;
                }
                break;
            case 1:
                coins = PlayerPrefs.GetInt("Coins");
                if (coins >= 100)
                {
                    DoubleCoins = PlayerPrefs.GetInt("DoubleCoin");
                    PlayerPrefs.SetInt("DoubleCoin", ++DoubleCoins);
                    PlayerPrefs.SetInt("Coins", coins -= 100);
                    CountCoins.text = PlayerPrefs.GetInt("Coins").ToString();
                    firstNum.text = "x" + PlayerPrefs.GetInt("DoubleCoin").ToString();
                }
                else
                {
                    Activate_IAPStore();
                    isShop = false;
                }
                break;
        }
    }

    public void SecondButton()
    {
        switch (CheckShop)
        {
            case 0:
                coins = PlayerPrefs.GetInt("Coins");
                if (coins >= 75)
                {
                    Shields = PlayerPrefs.GetInt("Shield");
                    PlayerPrefs.SetInt("Shield", ++Shields);
                    PlayerPrefs.SetInt("Coins", coins -= 75);
                    CountCoins.text = PlayerPrefs.GetInt("Coins").ToString();
                    secondNum.text = "x" + PlayerPrefs.GetInt("Shield").ToString();
                }
                else
                {
                    Activate_IAPStore();
                    isShop = false;
                }
                break;
            case 1:
                if (Advertisement.IsReady("rewardedVideo") && adsCountForPresents < 3)
                {
                    Advertisement.Show("rewardedVideo");
                    adsCountForPresents++;

                    if (adsCountForPresents >= 3)
                    {
                        button.interactable = false;

                        PlayerPrefs.SetInt("MinutePresent", System.DateTime.Now.Minute);
                        PlayerPrefs.SetInt("HourPresent", System.DateTime.Now.Hour);
                        PlayerPrefs.SetInt("DayPresent", System.DateTime.Now.Day);
                    }
                }
                break;
        }
    }

    public void LeftArrow()
    {
        if (CheckShop == 1)
        {
            ExtraLifes = PlayerPrefs.GetInt("ExtraLife");
            Shields = PlayerPrefs.GetInt("Shield");

            CheckShop = 0;

            PresentButton.GetComponent<Button>().enabled = false;

            button.interactable = true;

            upText.text = "Extra Life\nGive you chance in the game\n50 coins";
            downText.text = "Shield\nTakes all the punches\n75 coins";

            products[0].GetComponent<Image>().sprite = productSprites[0];
            products[1].GetComponent<Image>().sprite = productSprites[1];

            firstNum.text = "x" + ExtraLifes.ToString();
            secondNum.text = "x" + Shields.ToString();

            secondButtonText.text = "Buy";
        }
    }

    public void RightArrow()
    {
        if (CheckShop == 0)
        {
            DoubleCoins = PlayerPrefs.GetInt("DoubleCoin");
            Presents = PlayerPrefs.GetInt("Present");

            CheckShop = 1;

            PresentButton.GetComponent<Button>().enabled = true;

            if (adsCountForPresents >= 3)
            {
                button.interactable = false;
            }

            upText.text = "Double coin\nDuplicates your coins\n100 coins";
            downText.text = "Present\nGive present\nClick on present for opening";

            products[0].GetComponent<Image>().sprite = productSprites[2];
            products[1].GetComponent<Image>().sprite = productSprites[3];

            firstNum.text = "x" + DoubleCoins.ToString();
            secondNum.text = "x" + Presents.ToString();

            secondButtonText.text = "Get";
        }
    }

    public void Activate_IAPStore()
    {
        if (IAP_Store.adsCountForCoins >= 3) GetCoinsButton.interactable = false;

        mainText.text = "Buy coins";

        isShop = false;

        BoostersShop.SetActive(false);
        SkinsShopObj.SetActive(false);
        Plus.SetActive(false);

        IAPStore.SetActive(true);

        if (PlayerPrefs.GetString("NoAds").Equals("True"))
            noAds.SetActive(false);
        else noAds.SetActive(true);
    }

    public void OpenPresentMenu()
    {
        if (PlayerPrefs.GetInt("Present") > 0)
        {
            OpenPresentMenuObj.SetActive(true);
            GetPresentMenu.SetActive(false);

            PresentMenu.SetActive(true);
        }
    }

    public void OpenPresent()
    {
        OpenPresentMenuObj.SetActive(false);
        GetPresentMenu.SetActive(true);

        Presents = PlayerPrefs.GetInt("Present");
        coins = PlayerPrefs.GetInt("Coins");

        PlayerPrefs.SetInt("Present", --Presents);
        secondNum.text = "x" + Presents.ToString();

        rand = Random.Range(1, 9);

        switch (rand)
        {
            case 1:
                PlayerPrefs.SetInt("Shield", ++Shields);
                GetPresent.sprite = productSprites[1];
                Count.text = "x1";
                break;
            case 2:
                PlayerPrefs.SetInt("ExtraLife", ++ExtraLifes);
                GetPresent.sprite = productSprites[0];
                Count.text = "x1";
                break;
            case 3:
                PlayerPrefs.SetInt("DoubleCoin", ++DoubleCoins);
                GetPresent.sprite = productSprites[2];
                Count.text = "x1";
                firstNum.text = "x" + DoubleCoins.ToString();
                break;
            case 4:
                PlayerPrefs.SetInt("Coins", coins += 20);
                GetPresent.sprite = productSprites[4];
                Count.text = "x20";
                CountCoins.text = coins.ToString();
                break;
            case 5:
                PlayerPrefs.SetInt("Shield", Shields += 2);
                GetPresent.sprite = productSprites[1];
                Count.text = "x2";
                break;
            case 6:
                PlayerPrefs.SetInt("ExtraLife", ExtraLifes += 2);
                GetPresent.sprite = productSprites[0];
                Count.text = "x2";
                break;
            case 7:
                PlayerPrefs.SetInt("DoubleCoin", DoubleCoins += 2);
                GetPresent.sprite = productSprites[2];
                Count.text = "x2";
                firstNum.text = DoubleCoins.ToString();
                break;
            case 8:
                PlayerPrefs.SetInt("Coins", coins += 70);
                GetPresent.sprite = productSprites[4];
                Count.text = "x70";
                CountCoins.text = coins.ToString();
                break;
        }
    }

    public void ClosePresentMenu()
    {
        PresentMenu.SetActive(false);
    }
}
