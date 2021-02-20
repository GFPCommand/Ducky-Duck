using UnityEngine;

public class InitializeGame : MonoBehaviour
{
    public GameObject HighScoreObj, HighScorePanelObj, HighScoreMenuText, player, shieldObj, go;

    public CircleCollider2D cc;
    public PolygonCollider2D pc;

    public static int ExtraLifes, Shields, DoubleCoins;

    public static bool adsIsShowed, isSound;

    public Sprite[] birds = new Sprite[4];

    private void Awake()
    {
        if (LoadLevels.isLevels)
        {
            HighScoreObj.SetActive(false);
            HighScorePanelObj.SetActive(false);
            HighScoreMenuText.SetActive(false);

            player.GetComponent<Player>().enabled = false;
            player.GetComponent<PlayerLVL>().enabled = true;
        }
        else
        {
            HighScoreObj.SetActive(true);
            HighScorePanelObj.SetActive(true);
            HighScoreMenuText.SetActive(true);

            player.GetComponent<Player>().enabled = true;
            player.GetComponent<PlayerLVL>().enabled = false;
        }

        Time.timeScale = 1;

        adsIsShowed = false;

        ExtraLifes = PlayerPrefs.GetInt("ExtraLife");
        Shields = PlayerPrefs.GetInt("Shield");
        DoubleCoins = PlayerPrefs.GetInt("DoubleCoin");

        if (PlayerPrefs.GetInt("Sound") == 1) isSound = true;
        else isSound = false;

        switch (PlayerPrefs.GetInt("BirdActive"))
        {
            case 1:
                player.GetComponent<SpriteRenderer>().sprite = birds[0];
                break;
            case 2:
                player.GetComponent<SpriteRenderer>().sprite = birds[1];
                break;
            case 3:
                player.GetComponent<SpriteRenderer>().sprite = birds[2];
                break;
            case 4:
                player.GetComponent<SpriteRenderer>().sprite = birds[3];
                break;
        }
    }

    private void Start()
    {
        if (Shields > 0)
        {
            shieldObj.SetActive(true);

            cc.GetComponent<CircleCollider2D>().enabled = true;
            pc.GetComponent<PolygonCollider2D>().enabled = false;
        }

        if (isSound)
            go.GetComponent<AudioSource>().enabled = true;
        else
            go.GetComponent<AudioSource>().enabled = false;
    }
}