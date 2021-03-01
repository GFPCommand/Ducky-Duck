using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
using System.Collections;

public class Menu : MonoBehaviour
{
    private int checkCondition;
    private bool isNoAds;

    public static bool isLoad = false;

    public Text firstText, secondText, thirdText, fourthText, coinsText, firstNum, secondNum, MainText, BuyOrGetButtonText, firstTextDescription, secondTextDescription;
    public Sprite[] ButtonsSprites;
    public Slider loading;
    public Sprite[] LevelsButtonsImages, productSprites;
    public GameObject[] LevelsButtons, products;
    public Button[] ButtonsForBuyingBirds = new Button[4];
    public Text[] TextOnButtons = new Text[4];

    public GameObject FirstButton, SecondButton, ThirdButton, FourthButton, BackButton, LoadingScreen, BoostersShop, IAPStore, coinsValue, coinsImage, LevelsMenu, SkinsShopObj, ConfirmResetMenu, Plus, go;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("BirdActive"))
            PlayerPrefs.SetInt("BirdActive", 1);

        if (Advertisement.isSupported)
        { 
            Advertisement.Initialize("3861549", false);
            Debug.Log("Initializing...");
        }
        else Debug.Log("Platform is not supported");

        firstText.text = "Start";
        secondText.text = "Store";
        thirdText.text = "Settings";
        fourthText.text = "Exit";

        checkCondition = 0;

        FirstButton.SetActive(true);
        SecondButton.SetActive(true);
        ThirdButton.SetActive(true);
        FourthButton.SetActive(true);

        BackButton.SetActive(false);
        LoadingScreen.SetActive(false);
        ConfirmResetMenu.SetActive(false);

        if (!PlayerPrefs.HasKey("Sound") || !PlayerPrefs.HasKey("Music"))
        {
            PlayerPrefs.SetInt("Sound", 1);
            PlayerPrefs.SetInt("Music", 1);
        }

        if (PlayerPrefs.GetInt("Sound") == 0)
            go.GetComponent<AudioSource>().enabled = false;
        else
            go.GetComponent<AudioSource>().enabled = true;
    }

    public void FirstMenuButton()
    {
        switch (checkCondition)
        {
            case 0:
                firstText.text  = "Arcade";
                secondText.text = "Levels";

                MainText.text = "Select game mode";

                ThirdButton.SetActive(false);
                FourthButton.SetActive(false);

                BackButton.SetActive(true);

                checkCondition = 1;
                break;
            case 1:
                BackButton.SetActive(false);
                LoadingScreen.SetActive(true);
                StartCoroutine(Load());
                break;
            case 2:
                BoostersShop.SetActive(true);

                Plus.SetActive(true);

                Shop.isShop = true;

                coinsImage.SetActive(true);
                coinsValue.SetActive(true);

                MainText.text = "Boosters";

                if (Shop.CheckShop == 0)
                {                    
                    products[0].GetComponent<Image>().sprite = productSprites[0];
                    products[1].GetComponent<Image>().sprite = productSprites[1];

                    firstNum.text = "x" + PlayerPrefs.GetInt("ExtraLife").ToString();
                    secondNum.text = "x" + PlayerPrefs.GetInt("Shield").ToString();

                    BuyOrGetButtonText.text = "Buy";

                    firstTextDescription.text = "Extra Life\nGive you chance in the game\n50 coins";
                    secondTextDescription.text = "Shield\nTakes all the punches\n75 coins";
                } else
                {
                    products[0].GetComponent<Image>().sprite = productSprites[2];
                    products[1].GetComponent<Image>().sprite = productSprites[3];

                    firstNum.text = "x" + PlayerPrefs.GetInt("DoubleCoin").ToString();
                    secondNum.text = "x" + PlayerPrefs.GetInt("Present").ToString();

                    BuyOrGetButtonText.text = "Get";

                    firstTextDescription.text = "Double coin\nDuplicates your coins\n100 coins";
                    secondTextDescription.text = "Present\nGive present\nClick on present for opening";
                }

                coinsText.text = PlayerPrefs.GetInt("Coins").ToString();

                FirstButton.SetActive(false);
                SecondButton.SetActive(false);
                ThirdButton.SetActive(false);
                FourthButton.SetActive(false);
                break;
            case 3:

                if (PlayerPrefs.GetInt("Sound") == 1)
                {
                    PlayerPrefs.SetInt("Sound", 0);
                    FirstButton.GetComponent<Image>().sprite = ButtonsSprites[1];
                    firstText.text = "Sound: off";
                    firstText.fontSize = 38;

                    go.GetComponent<AudioSource>().enabled = false;
                } else if (PlayerPrefs.GetInt("Sound") == 0)
                {
                    PlayerPrefs.SetInt("Sound", 1);
                    FirstButton.GetComponent<Image>().sprite = ButtonsSprites[0];
                    firstText.text = "Sound: on";
                    firstText.fontSize = 40;

                    go.GetComponent<AudioSource>().enabled = true;
                }
                break;
        }
    }

    public void SecondMenuButton()
    {
        switch (checkCondition) {
            case 0:
                firstText.text = "Boosters";
                secondText.text = "Skins";

                MainText.text = "Select store";

                ThirdButton.SetActive(false);
                FourthButton.SetActive(false);

                BackButton.SetActive(true);

                checkCondition = 2;
                break;
            case 1:
                SetImages();

                LevelsMenu.SetActive(true);

                FirstButton.SetActive(false);
                SecondButton.SetActive(false);                

                MainText.text = "Select level";
                break;
            case 2:
                MainText.text = "Select skin";

                FirstButton.SetActive(false);
                SecondButton.SetActive(false);
                ThirdButton.SetActive(false);
                FourthButton.SetActive(false);

                SkinsShopObj.SetActive(true);

                coinsImage.SetActive(true);
                coinsValue.SetActive(true);

                coinsText.text = PlayerPrefs.GetInt("Coins").ToString();

                Plus.SetActive(true);

                SkinsShop.isSkinsShop = true;

                for (int i = 1; i < 4; i++)
                {
                    if (PlayerPrefs.GetString("BirdsBuy").Contains((i + 1).ToString()))
                        TextOnButtons[i].text = "Use";
                    else TextOnButtons[i].text = "Buy";
                }

                for (int i = 1; i <= 4; i++)
                {
                    if (i == PlayerPrefs.GetInt("BirdActive"))
                        ButtonsForBuyingBirds[i-1].interactable = false;
                    else
                        ButtonsForBuyingBirds[i-1].interactable = true;
                }
                break;
            case 3:
                if (PlayerPrefs.GetInt("Music") == 1)
                {
                    PlayerPrefs.SetInt("Music", 0);
                    SecondButton.GetComponent<Image>().sprite = ButtonsSprites[1];
                    secondText.text = "Music: off";
                    secondText.fontSize = 38;
                }
                else if (PlayerPrefs.GetInt("Music") == 0)
                {
                    PlayerPrefs.SetInt("Music", 1);
                    SecondButton.GetComponent<Image>().sprite = ButtonsSprites[0];
                    secondText.text = "Music: on";
                    secondText.fontSize = 40;
                }
                break;
        }
    }

    public void ThirdMenuButton()
    {
        if (checkCondition == 0)
        {
            MainText.text = "Settings";

            if (PlayerPrefs.GetInt("Sound") == 1)
            {
                firstText.text = "Sound: On";
                FirstButton.GetComponent<Image>().sprite = ButtonsSprites[0];
            } else
            {
                firstText.text = "Sound: Off";
                FirstButton.GetComponent<Image>().sprite = ButtonsSprites[1];
                firstText.fontSize = 38;
            }
            
            if (PlayerPrefs.GetInt("Music") == 1)
            {
                secondText.text = "Music: On";
                SecondButton.GetComponent<Image>().sprite = ButtonsSprites[0];
            } else
            {
                secondText.text = "Music: Off";
                SecondButton.GetComponent<Image>().sprite = ButtonsSprites[1];
                secondText.fontSize = 38;
            }

            ThirdButton.GetComponent<Image>().sprite = ButtonsSprites[2];
            thirdText.text = "Reset";

            FourthButton.SetActive(false);

            BackButton.SetActive(true);

            checkCondition = 3;
        } else if (checkCondition == 3)
        {
            ConfirmResetMenu.SetActive(true);
        }
    }

    public void FourthMenuButton()
    {
        if (checkCondition == 0)
        {
            Application.Quit();
        }
    }

    private void SetImages()
    {
        int passLevel = PlayerPrefs.GetInt("passLVL");

        for (int i = 0; i < passLevel; i++)
        {
            LevelsButtons[i].GetComponent<Image>().sprite = LevelsButtonsImages[i];
        }
    }
    public void Back()
    {
        checkCondition = 0;

        FirstButton.SetActive(true);
        SecondButton.SetActive(true);
        ThirdButton.SetActive(true);
        FourthButton.SetActive(true);

        BackButton.SetActive(false);
        BoostersShop.SetActive(false);
        IAPStore.SetActive(false);
        coinsValue.SetActive(false);
        coinsImage.SetActive(false);
        LevelsMenu.SetActive(false);
        SkinsShopObj.SetActive(false);
        Plus.SetActive(false);

        firstText.text = "Start";
        secondText.text = "Store";
        thirdText.text = "Settings";
        fourthText.text = "Exit";

        MainText.text = "Ducky Duck";

        FirstButton.GetComponent<Image>().sprite = ButtonsSprites[0];
        SecondButton.GetComponent<Image>().sprite = ButtonsSprites[0];
        ThirdButton.GetComponent<Image>().sprite = ButtonsSprites[0];
    }

    public void Confirm()
    {
        if (PlayerPrefs.GetString("NoAds").Equals("True")) isNoAds = true;
        else isNoAds = false;

        PlayerPrefs.DeleteAll();

        PlayerPrefs.SetInt("Sound", 1);
        PlayerPrefs.SetInt("Music", 1);

        PlayerPrefs.SetString("NoAds", isNoAds.ToString());

        PlayerPrefs.SetInt("BirdActive", 1);
        PlayerPrefs.SetInt("passLVL", 0);

        firstText.text = "Sound: On";
        FirstButton.GetComponent<Image>().sprite = ButtonsSprites[0];

        secondText.text = "Music: On";
        SecondButton.GetComponent<Image>().sprite = ButtonsSprites[0];

        ConfirmResetMenu.SetActive(false);
    }

    public void Cancel()
    {
        ConfirmResetMenu.SetActive(false);
    }

    IEnumerator Load()
    {
        isLoad = true;

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(1);

        while (!asyncLoad.isDone)
        {
            loading.value = asyncLoad.progress;

            yield return null;
        }
    }
}