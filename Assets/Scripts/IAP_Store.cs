using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;
using UnityEngine.Purchasing;
using System.Collections;

public class IAP_Store : MonoBehaviour, IUnityAdsListener
{
    public Button button, presentButton;
    private int coins, presents;
    public Text CountCoinsText, countPresentsText;
    public GameObject noAds;
    public static int adsCountForCoins = 0;

    private void Start()
    {
        Advertisement.AddListener(this);

        StartCoroutine(CheckAds());
    }

    private void Update()
    {
        if (PlayerPrefs.GetString("NoAds").Equals("true")) noAds.SetActive(false);

        if (Menu.isLoad || LoadLevels.isLoadLevels)
        {
            Advertisement.RemoveListener(this);
        } else
        {
            Advertisement.AddListener(this);
        }
    }

    public void ShowRewardedVideo()
    {
        if (adsCountForCoins == 0 || adsCountForCoins % 4 == 0) adsCountForCoins++;

        if (Advertisement.IsReady("rewardedVideo") && adsCountForCoins % 4 != 0)
        {
            Advertisement.Show("rewardedVideo");
            adsCountForCoins++;

            if (adsCountForCoins % 4 == 0)
            {
                button.interactable = false;

                PlayerPrefs.SetInt("Minute", System.DateTime.Now.Minute);
                PlayerPrefs.SetInt("Hour", System.DateTime.Now.Hour);
                PlayerPrefs.SetInt("Day", System.DateTime.Now.Day);
            }
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.Log(message);
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        switch (showResult)
        {
            case ShowResult.Finished:
                coins = PlayerPrefs.GetInt("Coins");
                presents = PlayerPrefs.GetInt("Present");
                if (!Shop.isShop)
                {
                    PlayerPrefs.SetInt("Coins", coins += 20);
                    if (CountCoinsText != null) CountCoinsText.text = PlayerPrefs.GetInt("Coins").ToString();
                    Debug.Log("Add coins with result: " + showResult);
                } else if (Shop.isShop)
                {
                    PlayerPrefs.SetInt("Present", ++presents);
                    if (countPresentsText != null) countPresentsText.text = "x" + PlayerPrefs.GetInt("Present").ToString();
                    Debug.Log("Add present with result: " + showResult);
                }
                break;
            case ShowResult.Skipped:
                Debug.Log("Video was skipped");
                break;
            case ShowResult.Failed:
                Debug.Log("Fail");
                break;
        }
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        Debug.Log("Start showing");
    }

    public void OnUnityAdsReady(string placementId)
    {
        if (placementId.Equals("3861549")) button.interactable = true;
    }

    public void OnPurchaseComplete(Product product)
    {
        coins = PlayerPrefs.GetInt("Coins");
        if (product.definition.id == "coins_75")
        {
            coins += 75;
            Result();
        }
        else if (product.definition.id == "coins_120")
        {
            coins += 120;
            Result();
        }
        else if (product.definition.id == "coins_200")
        {
            coins += 200;
            Result();
        }
        else if (product.definition.id == "no_ads")
        {
            PlayerPrefs.SetString("NoAds", "true");
        }
    }

    public void OnPurchaseFailure(Product product, PurchaseFailureReason reason)
    {
        Debug.Log("Purchase of product " + product.definition.id + "failed because " + reason);
    }

    private void Result()
    {
        PlayerPrefs.SetInt("Coins", coins);
        CountCoinsText.text = PlayerPrefs.GetInt("Coins").ToString();
    }

    IEnumerator CheckAds()
    {
        while (!Menu.isLoad || !LoadLevels.isLoadLevels)
        {
            if (System.DateTime.Now.Day - PlayerPrefs.GetInt("Day") == 0)
            {
                if (System.DateTime.Now.Hour - PlayerPrefs.GetInt("Hour") == 0)
                {
                    if (System.DateTime.Now.Minute - PlayerPrefs.GetInt("Minute") >= 5)
                    {
                        button.interactable = true;
                    }
                }
                else if (System.DateTime.Now.Hour - PlayerPrefs.GetInt("Hour") >= 1)
                {
                    int currentMinutes = 60 * (System.DateTime.Now.Hour - PlayerPrefs.GetInt("Hour")) + System.DateTime.Now.Minute;

                    if (currentMinutes - PlayerPrefs.GetInt("Minute") >= 5)
                    {
                        button.interactable = true;
                    }
                }
            }
            else if (System.DateTime.Now.Day - PlayerPrefs.GetInt("DayPresent") >= 1)
            {
                int currentMinutes = 60 * (System.DateTime.Now.Day - PlayerPrefs.GetInt("DayPresent")) + System.DateTime.Now.Minute;

                if (currentMinutes - PlayerPrefs.GetInt("MinutePresent") >= 5)
                {
                    button.interactable = true;
                }
            }

            if (System.DateTime.Now.Day - PlayerPrefs.GetInt("DayPresent") == 0)
            {
                if (System.DateTime.Now.Hour - PlayerPrefs.GetInt("HourPresent") == 0)
                {
                    if (System.DateTime.Now.Minute - PlayerPrefs.GetInt("MinutePresent") >= 5)
                    {
                        presentButton.interactable = true;
                    }
                }
                else if (System.DateTime.Now.Hour - PlayerPrefs.GetInt("HourPresent") >= 1)
                {
                    int currentMinutes = 60 * (System.DateTime.Now.Hour - PlayerPrefs.GetInt("HourPresent")) + System.DateTime.Now.Minute;

                    if (currentMinutes - PlayerPrefs.GetInt("MinutePresent") >= 5)
                    {
                        presentButton.interactable = true;
                    }
                }
            }
            else if (System.DateTime.Now.Day - PlayerPrefs.GetInt("DayPresent") >= 1)
            {
                int currentMinutes = 60 * (System.DateTime.Now.Day - PlayerPrefs.GetInt("DayPresent")) + System.DateTime.Now.Minute;

                if (currentMinutes - PlayerPrefs.GetInt("MinutePresent") >= 5)
                {
                    presentButton.interactable = true;
                }
            }

            yield return null;
        }
    }
}