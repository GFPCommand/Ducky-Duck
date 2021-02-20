using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

public class LoadLevels : MonoBehaviour
{
    public static bool isLevels, isLoadLevels;
    private double PassLevels, deltaLevel, cost = 30;
    private int SelectLevel, coins;

    public GameObject loadGame, levels, backButton, BuyLevelsPanel, IAP_Store, CoinsValue, CoinsImg, noAds;
    public GameObject[] LevelsButtons;

    public Slider loadSlider;
    public Text CostText, mainText, CoinsValueText;

    public Sprite[] Activity;

    public void loadLevel1()
    {
        PlayerPrefs.SetInt("selLVL", 1);

        isLevels = true;

        loadGame.SetActive(true);
        levels.SetActive(false);
        backButton.SetActive(false);
        
        StartCoroutine(Load());

    }

    public void loadLevel2()
    {
        SelectLevel = 2;
        if (PlayerPrefs.GetInt("passLVL") >= 1)
        {
            

            PlayerPrefs.SetInt("selLVL", SelectLevel);

            isLevels = true;

            loadGame.SetActive(true);
            levels.SetActive(false);
            backButton.SetActive(false);

            StartCoroutine(Load());
        } else
        {
            BuyLevelsPanel.SetActive(true);

            backButton.GetComponent<Button>().enabled = false;

            for (int i = 0; i < LevelsButtons.Length; i++)
            {
                LevelsButtons[i].GetComponent<Button>().enabled = false;
            }

            if (CostText != null) CostText.text = PriceCalculation(SelectLevel).ToString() + " coins";
        }

    }

    public void loadLevel3()
    {
        SelectLevel = 3;
        if (PlayerPrefs.GetInt("passLVL") >= 2)
        {
            

            PlayerPrefs.SetInt("selLVL", SelectLevel);

            isLevels = true;

            loadGame.SetActive(true);
            levels.SetActive(false);
            backButton.SetActive(false);

            StartCoroutine(Load());
        }
        else
        {
            BuyLevelsPanel.SetActive(true);

            backButton.GetComponent<Button>().enabled = false;

            for (int i = 0; i < LevelsButtons.Length; i++)
            {
                LevelsButtons[i].GetComponent<Button>().enabled = false;
            }

            if (CostText != null) CostText.text = PriceCalculation(SelectLevel).ToString() + " coins";
        }
    }

    public void loadLevel4()
    {
        SelectLevel = 4;
        if (PlayerPrefs.GetInt("passLVL") >= 3)
        {
            

            PlayerPrefs.SetInt("selLVL", SelectLevel);

            isLevels = true;

            loadGame.SetActive(true);
            levels.SetActive(false);
            backButton.SetActive(false);

            StartCoroutine(Load());
        }
        else
        {
            BuyLevelsPanel.SetActive(true);

            backButton.GetComponent<Button>().enabled = false;

            for (int i = 0; i < LevelsButtons.Length; i++)
            {
                LevelsButtons[i].GetComponent<Button>().enabled = false;
            }

            if (CostText != null) CostText.text = PriceCalculation(SelectLevel).ToString() + " coins";
        }
    }

    public void loadLevel5()
    {
        SelectLevel = 5;
        if (PlayerPrefs.GetInt("passLVL") >= 4)
        {
            

            PlayerPrefs.SetInt("selLVL", SelectLevel);

            isLevels = true;

            loadGame.SetActive(true);
            levels.SetActive(false);
            backButton.SetActive(false);

            StartCoroutine(Load());
        }
        else
        {
            BuyLevelsPanel.SetActive(true);

            backButton.GetComponent<Button>().enabled = false;

            for (int i = 0; i < LevelsButtons.Length; i++)
            {
                LevelsButtons[i].GetComponent<Button>().enabled = false;
            }
            if (CostText != null) CostText.text = PriceCalculation(SelectLevel).ToString() + " coins";
        }
    }

    public void loadLevel6()
    {
        SelectLevel = 6;
        if (PlayerPrefs.GetInt("passLVL") >= 5)
        {
            

            PlayerPrefs.SetInt("selLVL", SelectLevel);

            isLevels = true;

            loadGame.SetActive(true);
            levels.SetActive(false);
            backButton.SetActive(false);

            StartCoroutine(Load());
        }
        else
        {
            BuyLevelsPanel.SetActive(true);

            backButton.GetComponent<Button>().enabled = false;

            for (int i = 0; i < LevelsButtons.Length; i++)
            {
                LevelsButtons[i].GetComponent<Button>().enabled = false;
            }

            if (CostText != null) CostText.text = PriceCalculation(SelectLevel).ToString() + " coins";
        }
    }

    public void loadLevel7()
    {
        SelectLevel = 7;
        if (PlayerPrefs.GetInt("passLVL") >= 6)
        {
            

            PlayerPrefs.SetInt("selLVL", SelectLevel);

            isLevels = true;

            loadGame.SetActive(true);
            levels.SetActive(false);
            backButton.SetActive(false);

            StartCoroutine(Load());
        }
        else
        {
            BuyLevelsPanel.SetActive(true);

            backButton.GetComponent<Button>().enabled = false;

            for (int i = 0; i < LevelsButtons.Length; i++)
            {
                LevelsButtons[i].GetComponent<Button>().enabled = false;
            }

            if (CostText != null) CostText.text = PriceCalculation(SelectLevel).ToString() + " coins";
        }
    }

    public void loadLevel8()
    {
        SelectLevel = 8;
        if (PlayerPrefs.GetInt("passLVL") >= 7)
        {
            

            PlayerPrefs.SetInt("selLVL", 8);

            isLevels = true;

            loadGame.SetActive(true);
            levels.SetActive(false);
            backButton.SetActive(false);

            StartCoroutine(Load());
        }
        else
        {
            BuyLevelsPanel.SetActive(true);

            backButton.GetComponent<Button>().enabled = false;

            for (int i = 0; i < LevelsButtons.Length; i++)
            {
                LevelsButtons[i].GetComponent<Button>().enabled = false;
            }

            if (CostText != null) CostText.text = PriceCalculation(SelectLevel).ToString() + " coins";
        }
    }

    public void loadLevel9()
    {
        SelectLevel = 9;
        if (PlayerPrefs.GetInt("passLVL") >= 8)
        {
            

            PlayerPrefs.SetInt("selLVL", SelectLevel);

            isLevels = true;

            loadGame.SetActive(true);
            levels.SetActive(false);
            backButton.SetActive(false);

            StartCoroutine(Load());
        }
        else
        {
            BuyLevelsPanel.SetActive(true);

            backButton.GetComponent<Button>().enabled = false;

            for (int i = 0; i < LevelsButtons.Length; i++)
            {
                LevelsButtons[i].GetComponent<Button>().enabled = false;
            }

            if (CostText != null) CostText.text = PriceCalculation(SelectLevel).ToString() + " coins";
        }
    }

    public void loadLevel10()
    {
        SelectLevel = 10;
        if (PlayerPrefs.GetInt("passLVL") >= 9)
        {
            

            PlayerPrefs.SetInt("selLVL", SelectLevel);

            isLevels = true;

            loadGame.SetActive(true);
            levels.SetActive(false);
            backButton.SetActive(false);

            StartCoroutine(Load());
        }
        else
        {
            BuyLevelsPanel.SetActive(true);

            backButton.GetComponent<Button>().enabled = false;

            for (int i = 0; i < LevelsButtons.Length; i++)
            {
                LevelsButtons[i].GetComponent<Button>().enabled = false;
            }

            if (CostText != null) CostText.text = PriceCalculation(SelectLevel).ToString() + " coins";
        }
    }

    public void loadLevel11()
    {
        SelectLevel = 11;
        if (PlayerPrefs.GetInt("passLVL") >= 10)
        {
            

            PlayerPrefs.SetInt("selLVL", SelectLevel);

            isLevels = true;

            loadGame.SetActive(true);
            levels.SetActive(false);
            backButton.SetActive(false);

            StartCoroutine(Load());
        }
        else
        {
            BuyLevelsPanel.SetActive(true);

            backButton.GetComponent<Button>().enabled = false;

            for (int i = 0; i < LevelsButtons.Length; i++)
            {
                LevelsButtons[i].GetComponent<Button>().enabled = false;
            }

            if (CostText != null) CostText.text = PriceCalculation(SelectLevel).ToString() + " coins";
        }
    }

    public void loadLevel12()
    {
        SelectLevel = 12;
        if (PlayerPrefs.GetInt("passLVL") >= 11)
        {
            

            PlayerPrefs.SetInt("selLVL", SelectLevel);

            isLevels = true;

            loadGame.SetActive(true);
            levels.SetActive(false);
            backButton.SetActive(false);

            StartCoroutine(Load());
        }
        else
        {
            BuyLevelsPanel.SetActive(true);

            backButton.GetComponent<Button>().enabled = false;

            for (int i = 0; i < LevelsButtons.Length; i++)
            {
                LevelsButtons[i].GetComponent<Button>().enabled = false;
            }

            if (CostText != null) CostText.text = PriceCalculation(SelectLevel).ToString() + " coins";
        }
    }

    public void loadLevel13()
    {
        SelectLevel = 13;
        if (PlayerPrefs.GetInt("passLVL") >= 12)
        {
            

            PlayerPrefs.SetInt("selLVL", SelectLevel);

            isLevels = true;

            loadGame.SetActive(true);
            levels.SetActive(false);
            backButton.SetActive(false);

            StartCoroutine(Load());
        }
        else
        {
            BuyLevelsPanel.SetActive(true);

            backButton.GetComponent<Button>().enabled = false;

            for (int i = 0; i < LevelsButtons.Length; i++)
            {
                LevelsButtons[i].GetComponent<Button>().enabled = false;
            }

            if (CostText != null) CostText.text = PriceCalculation(SelectLevel).ToString() + " coins";
        }
    }

    public void loadLevel14()
    {
        SelectLevel = 14;
        if (PlayerPrefs.GetInt("passLVL") >= 13)
        {
            

            PlayerPrefs.SetInt("selLVL", SelectLevel);

            isLevels = true;

            loadGame.SetActive(true);
            levels.SetActive(false);
            backButton.SetActive(false);

            StartCoroutine(Load());
        }
        else
        {
            BuyLevelsPanel.SetActive(true);

            backButton.GetComponent<Button>().enabled = false;

            for (int i = 0; i < LevelsButtons.Length; i++)
            {
                LevelsButtons[i].GetComponent<Button>().enabled = false;
            }

            if (CostText != null) CostText.text = PriceCalculation(SelectLevel).ToString() + " coins";
        }
    }

    public void loadLevel15()
    {
        SelectLevel = 15;
        if (PlayerPrefs.GetInt("passLVL") >= 14)
        {
            

            PlayerPrefs.SetInt("selLVL", SelectLevel);

            isLevels = true;

            loadGame.SetActive(true);
            levels.SetActive(false);
            backButton.SetActive(false);

            StartCoroutine(Load());
        }
        else
        {
            BuyLevelsPanel.SetActive(true);

            backButton.GetComponent<Button>().enabled = false;

            for (int i = 0; i < LevelsButtons.Length; i++)
            {
                LevelsButtons[i].GetComponent<Button>().enabled = false;
            }

            if (CostText != null) CostText.text = PriceCalculation(SelectLevel).ToString() + " coins";
        }
    }

    public void BuyLevels()
    {
        if (PriceCalculation(SelectLevel) >= PlayerPrefs.GetInt("Coins"))
        {
            for (int i = 0; i < LevelsButtons.Length; i++)
            {
                LevelsButtons[i].GetComponent<Button>().enabled = true;
            }

            mainText.text = "Buy coins";

            CoinsValue.SetActive(true);
            CoinsImg.SetActive(true);
            CoinsValueText.text = PlayerPrefs.GetInt("Coins").ToString();

            backButton.GetComponent<Button>().enabled = true;

            BuyLevelsPanel.SetActive(false);

            levels.SetActive(false);

            IAP_Store.SetActive(true);

            if (PlayerPrefs.GetString("NoAds").Equals("True"))
                noAds.SetActive(false);
            else noAds.SetActive(true);

        } else
        {
            coins = PlayerPrefs.GetInt("Coins");

            coins -= (int) PriceCalculation(SelectLevel);

            PlayerPrefs.SetInt("Coins", coins);

            PlayerPrefs.SetInt("passLVL", SelectLevel);

            backButton.GetComponent<Button>().enabled = true;

            for (int i = 0; i < LevelsButtons.Length; i++)
            {
                LevelsButtons[i].GetComponent<Image>().sprite = Activity[i];
                if (i == SelectLevel) break;
            }

            BuyLevelsPanel.SetActive(false);

            for (int i = 0; i < LevelsButtons.Length; i++)
            {
                LevelsButtons[i].GetComponent<Button>().enabled = true;
            }

        }
    }

    public void Cancel()
    {
        BuyLevelsPanel.SetActive(false);

        backButton.GetComponent<Button>().enabled = true;

        for (int i = 0; i < LevelsButtons.Length; i++)
        {
            LevelsButtons[i].GetComponent<Button>().enabled = true;
        }
    }

    IEnumerator Load()
    {
        isLoadLevels = true;

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(1);

        while (!asyncLoad.isDone)
        {
            loadSlider.value = asyncLoad.progress;

            yield return null;
        }
    }

    private double PriceCalculation(int selectLevel)
    {
        double price;
        PassLevels = PlayerPrefs.GetInt("passLVL");
        deltaLevel = selectLevel - PassLevels;

        price = deltaLevel * cost - 10;

        return Math.Round(price);
    }
}
