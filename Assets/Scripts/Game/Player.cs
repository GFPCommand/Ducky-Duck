using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using System.Collections;

public class Player : MonoBehaviour
{
    public AudioClip getCoin, explosion;

    public static int score = 0;
    public static int CheckLose = 0; // counter for ads
    public static bool lose, isExplose;
    private int coins, countHits, countDownDoubleCoins;

    public GameObject music, PauseMenu, PauseButton, ELMenu, shieldObj, player, GameScores, ScoreObj, HighScoreObj, ScorePanelObj, HighScorePanelObj, highScoreMenuText, ScoreMenuTextObj;
    public GameObject[] MenuButtons;

    public CircleCollider2D  cc;
    public PolygonCollider2D pc;

    public Text ScoreText, HighScoreText, MenuText, ExtraLifeText, EndGameScore, EndGameHighScore;
    public Sprite[] DeadBirds = new Sprite[4];

    protected void Awake()
    {
        lose = false;
        isExplose = false;

        score = 0;

        countHits = 0;
        countDownDoubleCoins = 0;

        coins = PlayerPrefs.GetInt("Coins");
    }

    protected void Start()
    {
        ScoreText.text = "Score: " + score.ToString();
        HighScoreText.text = "HighScore: " + PlayerPrefs.GetInt("HighScore");

        if (PlayerPrefs.GetInt("Music") == 1)
            music.SetActive(true);
        else
            music.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bomb") && InitializeGame.ExtraLifes < 1 && InitializeGame.Shields < 1)
        {
            if (!LoadLevels.isLevels)
            {
                lose = true;
                Destroy(collision.gameObject);
                PlayerLose();

                if (InitializeGame.isSound) StartCoroutine(ExplosionPlayerSound());

                countDownDoubleCoins++;
                if (countDownDoubleCoins == 1 && InitializeGame.DoubleCoins > 0) PlayerPrefs.SetInt("DoubleCoin", --InitializeGame.DoubleCoins);
            }
        } else if (collision.gameObject.CompareTag("Bomb") && InitializeGame.ExtraLifes >= 1 && InitializeGame.Shields < 1)
        {
            if (!LoadLevels.isLevels)
            {
                Destroy(collision.gameObject);

                if (InitializeGame.isSound) StartCoroutine(ExplosionPlayerSound());

                ExtraLifeMenu();
                if (InitializeGame.DoubleCoins > 0) PlayerPrefs.SetInt("DoubleCoin", --InitializeGame.DoubleCoins);
            }
        } else if (collision.gameObject.CompareTag("Bomb") && InitializeGame.ExtraLifes < 1 && InitializeGame.Shields >= 1)
        {
            if (LoadLevels.isLevels)
            {
                Destroy(collision.gameObject);

                if (InitializeGame.isSound) StartCoroutine(ExplosionPlayerSound());

                countHits++;

                if (countHits == 2)
                {
                    countHits = 0;
                    PlayerPrefs.SetInt("Shield", --InitializeGame.Shields);

                    if (InitializeGame.Shields < 1)
                    {
                        shieldObj.SetActive(false);

                        pc.GetComponent<PolygonCollider2D>().enabled = true;
                        cc.GetComponent<CircleCollider2D>().enabled = false;
                    }
                }

                if (InitializeGame.DoubleCoins > 0) PlayerPrefs.SetInt("DoubleCoin", --InitializeGame.DoubleCoins);
            }
        } else if (collision.gameObject.CompareTag("Bomb") && InitializeGame.ExtraLifes >= 1 && InitializeGame.Shields >= 1)
        {
            if (!LoadLevels.isLevels)
            {
                Destroy(collision.gameObject);

                if (InitializeGame.isSound) StartCoroutine(ExplosionPlayerSound());

                countHits++;

                if (countHits == 2)
                {
                    countHits = 0;
                    PlayerPrefs.SetInt("Shield", --InitializeGame.Shields);

                    if (InitializeGame.Shields < 1)
                    {
                        shieldObj.SetActive(false);

                        pc.GetComponent<PolygonCollider2D>().enabled = true;
                        cc.GetComponent<CircleCollider2D>().enabled = false;
                    }
                }
                if (InitializeGame.DoubleCoins > 0) PlayerPrefs.SetInt("DoubleCoin", --InitializeGame.DoubleCoins);
            }
        }

        if (collision.gameObject.CompareTag("Coin") && InitializeGame.DoubleCoins < 1 && !lose)
        {
            Destroy(collision.gameObject);
            score++;
            ScoreText.text = "Score: " + score.ToString();
            PlayerPrefs.SetInt("Coins", ++coins);

            if (InitializeGame.isSound) StartCoroutine(GetCoinSound());

            if (score > PlayerPrefs.GetInt("HighScore"))
            {
                HighScoreText.text = "HighScore: " + score.ToString();
                PlayerPrefs.SetInt("HighScore", score);
            }
            else HighScoreText.text = "HighScore: " + PlayerPrefs.GetInt("HighScore").ToString();
        } else if (collision.gameObject.CompareTag("Coin") && InitializeGame.DoubleCoins >= 1 && !lose)
        {
            Destroy(collision.gameObject);
            score += 2;
            ScoreText.text = "Score: " + score.ToString();
            PlayerPrefs.SetInt("Coins", coins += 2);

            if (InitializeGame.isSound) StartCoroutine(GetCoinSound());

            if (score > PlayerPrefs.GetInt("HighScore"))
            {
                HighScoreText.text = "HighScore: " + score.ToString();
                PlayerPrefs.SetInt("HighScore", score);
            }
            else HighScoreText.text = "HighScore: " + PlayerPrefs.GetInt("HighScore").ToString();
        }
    }

    private void PlayerLose()
    {
        PauseMenu.SetActive(true);
        GameScores.SetActive(true);

        MenuButtons[0].SetActive(false);
        PauseButton.SetActive(false);
        ELMenu.SetActive(false);
        ScoreObj.SetActive(false);
        HighScoreObj.SetActive(false);
        ScorePanelObj.SetActive(false);
        HighScorePanelObj.SetActive(false);

        switch (PlayerPrefs.GetInt("BirdActive"))
        {
            case 1:
                player.GetComponent<SpriteRenderer>().sprite = DeadBirds[0];
                break;
            case 2:
                player.GetComponent<SpriteRenderer>().sprite = DeadBirds[1];
                break;
            case 3:
                player.GetComponent<SpriteRenderer>().sprite = DeadBirds[2];
                break;
            case 4:
                player.GetComponent<SpriteRenderer>().sprite = DeadBirds[3];
                break;
        }

        for (int i = 1; i < MenuButtons.Length; i++)
        {
            MenuButtons[i].SetActive(true);
        }

        CheckLose++;

        if (Advertisement.IsReady("video") && CheckLose % 5 == 0 && !PlayerPrefs.GetString("NoAds").Equals("True") && !InitializeGame.adsIsShowed)
        {
            InitializeGame.adsIsShowed = true;
            music.SetActive(false);
            Advertisement.Show("video");
        }

        MenuText.text = "You lose";

        if (!LoadLevels.isLevels) highScoreMenuText.SetActive(true);
        else highScoreMenuText.SetActive(false);

        ScoreMenuTextObj.SetActive(true);

        EndGameScore.text = "Score: " + score.ToString();
        EndGameHighScore.text = "HighScore: " + PlayerPrefs.GetInt("HighScore").ToString();
    }

    private void ExtraLifeMenu()
    {
        ScoreObj.SetActive(false);
        HighScoreObj.SetActive(false);
        HighScorePanelObj.SetActive(false);
        ScoreMenuTextObj.SetActive(false);

        PauseMenu.SetActive(true);
        ELMenu.SetActive(true);

        lose = true;

        for (int i = 0; i < MenuButtons.Length; i++)
        {
            MenuButtons[i].SetActive(false);
        }

        ExtraLifeText.text = "You have " + InitializeGame.ExtraLifes.ToString() + " extra lifes.\nWould you like to continue?";

        Time.timeScale = 0;
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