using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Advertisements;
using System.Collections;

class PlayerLVL : MonoBehaviour
{
    public AudioClip getCoin, explosion;

    public static bool win, lose;
    public static int scoreLVL = 0, CheckLose = 0;
    private int lvls, countLVL;
    private int coins, countHits, countDownDoubleCoins;

    public GameObject shieldLVLObj, PlayerLevelsObj, ScoreLevelTextObj, PanelScoreLevelTextObj, PauseMenu, music, pauseButton, ContinueButton, ScoreMenuTextObj, HighScoreMenuTextObj, GameScores, PauseButton;

    public CircleCollider2D cc;
    public PolygonCollider2D pc;

    public Text ScoreLevelText, scoreMenuText, PauseText;
    public Sprite[] DeadBirds = new Sprite[4];

    private void Awake()
    {
        lose = false;
        win  = false;

        scoreLVL = 0;
    }

    private void Start()
    {
        coins = PlayerPrefs.GetInt("Coins");

        countLVL = PlayerPrefs.GetInt("passLVL");
    }

    private void Update()
    {
        CheckGame();
        SetLevelCount();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bomb") && InitializeGame.Shields < 1)
        {
            lose = true;
            Destroy(collision.gameObject);
            LosePlayer();

            if (InitializeGame.isSound) StartCoroutine(ExplosionPlayerSound());

            countDownDoubleCoins++;
            if (countDownDoubleCoins == 1 && InitializeGame.DoubleCoins > 0) PlayerPrefs.SetInt("DoubleCoin", --InitializeGame.DoubleCoins);
        } else if (collision.gameObject.CompareTag("Bomb") && InitializeGame.Shields >= 1)
        {
            Destroy(collision.gameObject);

            if (InitializeGame.isSound) StartCoroutine(ExplosionPlayerSound());

            countHits++;

            if (countHits == 2)
            {
                Debug.Log("Count of hits " + countHits.ToString());

                countHits = 0;
                PlayerPrefs.SetInt("Shield", --InitializeGame.Shields);

                if (InitializeGame.Shields < 1)
                {
                    shieldLVLObj.SetActive(false);

                    pc.GetComponent<PolygonCollider2D>().enabled = true;
                    cc.GetComponent<CircleCollider2D>().enabled = false;
                }
            }
            if (InitializeGame.DoubleCoins > 0) PlayerPrefs.SetInt("DoubleCoin", --InitializeGame.DoubleCoins);
        }

        if (collision.gameObject.CompareTag("Coin") && InitializeGame.DoubleCoins < 1 && !lose)
        {
            Destroy(collision.gameObject);
            scoreLVL++;
            PlayerPrefs.SetInt("Coins", ++coins);

            if (InitializeGame.isSound) StartCoroutine(GetCoinSound());

            if (PlayerPrefs.GetInt("Sound") == 1) StartCoroutine(GetCoinSound());
        } else if (collision.gameObject.CompareTag("Coin") && InitializeGame.DoubleCoins >= 1 && !lose)
        {
            Destroy(collision.gameObject);
            scoreLVL += 2;
            PlayerPrefs.SetInt("Coins", coins += 2);

            if (InitializeGame.isSound) StartCoroutine(GetCoinSound());

            if (PlayerPrefs.GetInt("Sound") == 1) StartCoroutine(GetCoinSound());
        }
    }

    private void LosePlayer()
    {
        switch (PlayerPrefs.GetInt("BirdActive"))
        {
            case 1:
                PlayerLevelsObj.GetComponent<SpriteRenderer>().sprite = DeadBirds[0];
                break;
            case 2:
                PlayerLevelsObj.GetComponent<SpriteRenderer>().sprite = DeadBirds[1];
                break;
            case 3:
                PlayerLevelsObj.GetComponent<SpriteRenderer>().sprite = DeadBirds[2];
                break;
            case 4:
                PlayerLevelsObj.GetComponent<SpriteRenderer>().sprite = DeadBirds[3];
                break;
        }
        CheckLose++;

        if (Advertisement.IsReady("video") && CheckLose % 5 == 0 && !PlayerPrefs.GetString("NoAds").Equals("True") && !InitializeGame.adsIsShowed)
        {
            InitializeGame.adsIsShowed = true;
            music.SetActive(false);
            Advertisement.Show("video");
        }

        PauseText.text = "You lose";

        PauseMenu.SetActive(true);
        ScoreLevelTextObj.SetActive(true);
        GameScores.SetActive(true);

        ScoreLevelTextObj.SetActive(false);
        HighScoreMenuTextObj.SetActive(false);
        PanelScoreLevelTextObj.SetActive(false);
        ContinueButton.SetActive(false);
        PauseButton.SetActive(false);
        
        SetLevelCount();
    }

    private void CheckGame()
    {
        if (PlayerPrefs.GetInt("selLVL") == 1 && scoreLVL >= 20)
        {
            Time.timeScale = 0;

            win = true;

            lvls = 1;

            if (countLVL > lvls)
                PlayerPrefs.SetInt("passLVL", countLVL);
            else
                PlayerPrefs.SetInt("passLVL", lvls);

            PauseMenu.SetActive(true);
            PauseText.text = "You win";

            pauseButton.SetActive(false);
            
        }
        else if (PlayerPrefs.GetInt("selLVL") == 2 && scoreLVL >= 40)
        {
            Time.timeScale = 0;

            win = true;

            lvls = 2;

            if (countLVL > lvls)
                PlayerPrefs.SetInt("passLVL", countLVL);
            else
                PlayerPrefs.SetInt("passLVL", lvls);

            PauseMenu.SetActive(true);
            PauseText.text = "You win";

            pauseButton.SetActive(false);

        }
        else if (PlayerPrefs.GetInt("selLVL") == 3 && scoreLVL >= 60)
        {
            Time.timeScale = 0;

            win = true;

            lvls = 3;

            if (countLVL > lvls)
                PlayerPrefs.SetInt("passLVL", countLVL);
            else
                PlayerPrefs.SetInt("passLVL", lvls);

            PauseMenu.SetActive(true);
            PauseText.text = "You win";

            pauseButton.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("selLVL") == 4 && scoreLVL >= 80)
        {
            Time.timeScale = 0;

            win = true;

            lvls = 4;

            if (countLVL > lvls)
                PlayerPrefs.SetInt("passLVL", countLVL);
            else
                PlayerPrefs.SetInt("passLVL", lvls);

            PauseMenu.SetActive(true);
            PauseText.text = "You win";

            pauseButton.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("selLVL") == 5 && scoreLVL >= 100)
        {
            Time.timeScale = 0;

            win = true;

            lvls = 5;

            if (countLVL > lvls)
                PlayerPrefs.SetInt("passLVL", countLVL);
            else
                PlayerPrefs.SetInt("passLVL", lvls);

            PauseMenu.SetActive(true);
            PauseText.text = "You win";

            pauseButton.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("selLVL") == 6 && scoreLVL >= 120)
        {
            Time.timeScale = 0;

            win = true;

            lvls = 6;

            if (countLVL > lvls)
                PlayerPrefs.SetInt("passLVL", countLVL);
            else
                PlayerPrefs.SetInt("passLVL", lvls);

            PauseMenu.SetActive(true);
            PauseText.text = "You win";

            pauseButton.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("selLVL") == 7 && scoreLVL >= 140)
        {
            Time.timeScale = 0;

            win = true;

            lvls = 7;

            if (countLVL > lvls)
                PlayerPrefs.SetInt("passLVL", countLVL);
            else
                PlayerPrefs.SetInt("passLVL", lvls);

            PauseMenu.SetActive(true);
            PauseText.text = "You win";

            pauseButton.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("selLVL") == 8 && scoreLVL >= 160)
        {
            Time.timeScale = 0;

            win = true;

            lvls = 8;

            if (countLVL > lvls)
                PlayerPrefs.SetInt("passLVL", countLVL);
            else
                PlayerPrefs.SetInt("passLVL", lvls);

            PauseMenu.SetActive(true);
            PauseText.text = "You win";

            pauseButton.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("selLVL") == 9 && scoreLVL >= 180)
        {
            Time.timeScale = 0;

            win = true;

            lvls = 9;

            if (countLVL > lvls)
                PlayerPrefs.SetInt("passLVL", countLVL);
            else
                PlayerPrefs.SetInt("passLVL", lvls);

            PauseMenu.SetActive(true);
            PauseText.text = "You win";

            pauseButton.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("selLVL") == 10 && scoreLVL >= 200)
        {
            Time.timeScale = 0;

            win = true;

            lvls = 10;

            if (countLVL > lvls)
                PlayerPrefs.SetInt("passLVL", countLVL);
            else
                PlayerPrefs.SetInt("passLVL", lvls);

            PauseMenu.SetActive(true);
            PauseText.text = "You win";

            pauseButton.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("selLVL") == 11 && scoreLVL >= 220)
        {
            Time.timeScale = 0;

            win = true;

            lvls = 11;

            if (countLVL > lvls)
                PlayerPrefs.SetInt("passLVL", countLVL);
            else
                PlayerPrefs.SetInt("passLVL", lvls);

            PauseMenu.SetActive(true);
            PauseText.text = "You win";

            pauseButton.SetActive(false);
        } 
        else if (PlayerPrefs.GetInt("selLVL") == 12 && scoreLVL >= 240)
        {
            Time.timeScale = 0;

            win = true;

            lvls = 12;

            if (countLVL > lvls)
                PlayerPrefs.SetInt("passLVL", countLVL);
            else
                PlayerPrefs.SetInt("passLVL", lvls);

            PauseMenu.SetActive(true);
            PauseText.text = "You win";

            pauseButton.SetActive(false);
        } 
        else if (PlayerPrefs.GetInt("selLVL") == 13 && scoreLVL >= 260)
        {
            Time.timeScale = 0;

            win = true;

            lvls = 13;

            if (countLVL > lvls)
                PlayerPrefs.SetInt("passLVL", countLVL);
            else
                PlayerPrefs.SetInt("passLVL", lvls);

            PauseMenu.SetActive(true);
            PauseText.text = "You win";

            pauseButton.SetActive(false);
        } 
        else if (PlayerPrefs.GetInt("selLVL") == 14 && scoreLVL >= 280)
        {
            Time.timeScale = 0;

            win = true;

            lvls = 14;

            if (countLVL > lvls)
                PlayerPrefs.SetInt("passLVL", countLVL);
            else
                PlayerPrefs.SetInt("passLVL", lvls);

            PauseMenu.SetActive(true);
            PauseText.text = "You win";

            pauseButton.SetActive(false);
        } 
        else if (PlayerPrefs.GetInt("selLVL") == 15 && scoreLVL >= 300)
        {
            Time.timeScale = 0;

            win = true;

            lvls = 15;

            if (countLVL > lvls)
                PlayerPrefs.SetInt("passLVL", countLVL);
            else
                PlayerPrefs.SetInt("passLVL", lvls);

            PauseMenu.SetActive(true);
            PauseText.text = "You win";

            pauseButton.SetActive(false);
        }
    }

    private void SetLevelCount()
    {
        if (LoadLevels.isLevels)
        {
            switch (PlayerPrefs.GetInt("selLVL"))
            {
                case 1:
                    ScoreLevelText.text = "Score: " + scoreLVL.ToString() + " / 20";
                    scoreMenuText.text = "Score: " + scoreLVL.ToString() + " / 20";
                    break;
                case 2:
                    ScoreLevelText.text = "Score: " + scoreLVL.ToString() + " / 40";
                    scoreMenuText.text = "Score: " + scoreLVL.ToString() + " / 40";
                    break;
                case 3:
                    ScoreLevelText.text = "Score: " + scoreLVL.ToString() + " / 60";
                    scoreMenuText.text = "Score: " + scoreLVL.ToString() + " / 60";
                    break;
                case 4:
                    ScoreLevelText.text = "Score: " + scoreLVL.ToString() + " / 80";
                    scoreMenuText.text = "Score: " + scoreLVL.ToString() + " / 80";
                    break;
                case 5:
                    ScoreLevelText.text = "Score: " + scoreLVL.ToString() + " / 100";
                    scoreMenuText.text = "Score: " + scoreLVL.ToString() + " / 100";
                    break;
                case 6:
                    ScoreLevelText.text = "Score: " + scoreLVL.ToString() + " / 120";
                    scoreMenuText.text = "Score: " + scoreLVL.ToString() + " / 120";
                    break;
                case 7:
                    ScoreLevelText.text = "Score: " + scoreLVL.ToString() + " / 140";
                    scoreMenuText.text = "Score: " + scoreLVL.ToString() + " / 140";
                    break;
                case 8:
                    ScoreLevelText.text = "Score: " + scoreLVL.ToString() + " / 160";
                    scoreMenuText.text = "Score: " + scoreLVL.ToString() + " / 160";
                    break;
                case 9:
                    ScoreLevelText.text = "Score: " + scoreLVL.ToString() + " / 180";
                    scoreMenuText.text = "Score: " + scoreLVL.ToString() + " / 180";
                    break;
                case 10:
                    ScoreLevelText.text = "Score: " + scoreLVL.ToString() + " / 200";
                    scoreMenuText.text = "Score: " + scoreLVL.ToString() + " / 200";
                    break;
                case 11:
                    ScoreLevelText.text = "Score: " + scoreLVL.ToString() + " / 220";
                    scoreMenuText.text = "Score: " + scoreLVL.ToString() + " / 220";
                    break;
                case 12:
                    ScoreLevelText.text = "Score: " + scoreLVL.ToString() + " / 240";
                    scoreMenuText.text = "Score: " + scoreLVL.ToString() + " / 240";
                    break;
                case 13:
                    ScoreLevelText.text = "Score: " + scoreLVL.ToString() + " / 260";
                    scoreMenuText.text = "Score: " + scoreLVL.ToString() + " / 260";
                    break;
                case 14:
                    ScoreLevelText.text = "Score: " + scoreLVL.ToString() + " / 280";
                    scoreMenuText.text = "Score: " + scoreLVL.ToString() + " / 280";
                    break;
                case 15:
                    ScoreLevelText.text = "Score: " + scoreLVL.ToString() + " / 300";
                    scoreMenuText.text = "Score: " + scoreLVL.ToString() + " / 300";
                    break;
            }
        }
    }

    IEnumerator GetCoinSound()
    {
        AudioSource.PlayClipAtPoint(getCoin, transform.position);

        yield return new WaitForSeconds(0.3f);
    }

    IEnumerator ExplosionPlayerSound()
    {
        AudioSource.PlayClipAtPoint(explosion, transform.position);

        yield return new WaitForSeconds(3f);
    }
}