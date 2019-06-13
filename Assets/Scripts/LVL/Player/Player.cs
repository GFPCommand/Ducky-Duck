/* Разработка игры началась 10.10.2018*/
/* Приложение появилось в Google Play 22.12.2018*/

using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class Player : MonoBehaviour
{
    public static int count;
    private int help, help2, ShieldHelp, ShieldHelp2, doubleCoinHelp, doubleCoinHelp2;

    public GameObject music;

    public Text countText, highScoreText, NoYesText;

    public GameObject restart, pause, exit;

    public GameObject exp1, exp2, exp3, exp4;

    public AudioClip explose, getCoin;

    public GameObject yes, no, YesOrNo;

    public GameObject playerShield, player;

    public Sprite[] sprites = new Sprite[2];

    public CircleCollider2D cc;
    public PolygonCollider2D pc;

    public static bool lose = false;

    private void Awake()
    {
        Time.timeScale = 1;
        lose = false;
        pause.SetActive(true);
    }

    void Start()
    {
        count = 0;

        

        if (PlayerPrefs.GetInt("Shield") >= 1)
        {
            playerShield.SetActive(true);

            pc.GetComponent<PolygonCollider2D>().enabled = false;
            cc.GetComponent<CircleCollider2D>().enabled = true;
        } else
        {
            pc.GetComponent<PolygonCollider2D>().enabled = true;
            cc.GetComponent<CircleCollider2D>().enabled = false;
        }

        if (PlayerPrefs.GetInt("music") == 1)
        {
            music.SetActive(true);
        } else
        {
            music.SetActive(false);
        }

        HighScore();
        ShieldHelp = PlayerPrefs.GetInt("Shield");
        doubleCoinHelp = PlayerPrefs.GetInt("doubleCoin");
        help = PlayerPrefs.GetInt("mainScore");
    }

    void Update()
    {
        if (count > PlayerPrefs.GetInt("score"))
        {
            PlayerPrefs.SetInt("score", count);
        }
        HighScore();
        SetCount();
    }

    private void FixedUpdate()
    {
        StartCoroutine(flap());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "Bomb" && PlayerPrefs.GetInt("ExtraLife") < 1 && ShieldHelp < 1)
        {
            lose = true;

            Destroy(other.gameObject);

            if (PlayerPrefs.GetInt("sound") == 1)
            {
                StartCoroutine(MakeExplosionSound());
                StartCoroutine(Explose());
            }
            else if (PlayerPrefs.GetInt("sound") == 0)
            {
                StartCoroutine(Explose());
            }

            if (doubleCoinHelp >= 1)
            {
                doubleCoinHelp2 = --doubleCoinHelp;
                PlayerPrefs.SetInt("doubleCoin", doubleCoinHelp2);
            }
        } else if (other.gameObject.tag == "Bomb" && PlayerPrefs.GetInt("ExtraLife") >= 1 && ShieldHelp >= 1)
        {
            Destroy(other.gameObject);

            if (ShieldHelp >= 1)
            {
                ShieldHelp2 = --ShieldHelp;

                PlayerPrefs.SetInt("Shield", ShieldHelp2);
            }

            if (ShieldHelp < 1)
            {
                pc.GetComponent<PolygonCollider2D>().enabled = true;
                cc.GetComponent<CircleCollider2D>().enabled = false;

                playerShield.SetActive(false);
            }

            if (PlayerPrefs.GetInt("sound") == 1)
            {
                StartCoroutine(MakeExplosionSound());
            }

            if (doubleCoinHelp >= 1)
            {
                doubleCoinHelp2 = --doubleCoinHelp;
                PlayerPrefs.SetInt("doubleCoin", doubleCoinHelp2);
            }
        } else if (other.gameObject.tag == "Bomb" && PlayerPrefs.GetInt("ExtraLife") >= 1 && ShieldHelp < 1)
        {
            Destroy(other.gameObject);
            YesOrNo.SetActive(true);
            yes.SetActive(true);
            no.SetActive(true);
            pause.SetActive(false);
            Time.timeScale = 0;
            NoYesText.text = "You have " + PlayerPrefs.GetInt("ExtraLife") + " lifes. Continue?";
            if (PlayerPrefs.GetInt("sound") == 1)
            {
                StartCoroutine(MakeExplosionSound());
            }

            if (doubleCoinHelp >= 1)
            {
                doubleCoinHelp2 = --doubleCoinHelp;
                PlayerPrefs.SetInt("doubleCoin", doubleCoinHelp2);
            }
        } else if (other.gameObject.tag == "Bomb" && PlayerPrefs.GetInt("ExtraLife") < 1 && ShieldHelp >= 1)
        {
            Destroy(other.gameObject);
            ShieldHelp2 = --ShieldHelp;

            if (ShieldHelp2 < 1)
            {
                playerShield.SetActive(false);

                pc.GetComponent<PolygonCollider2D>().enabled = true;
                cc.GetComponent<CircleCollider2D>().enabled = false;
            }

            PlayerPrefs.SetInt("Shield", ShieldHelp2);

            if (PlayerPrefs.GetInt("sound") == 1)
            {
                StartCoroutine(MakeExplosionSound());
            }

            if (doubleCoinHelp >= 1)
            {
                doubleCoinHelp2 = --doubleCoinHelp;
                PlayerPrefs.SetInt("doubleCoin", doubleCoinHelp2);
            }
        }

        if (other.gameObject.tag == "Coin" && doubleCoinHelp < 1)
        {
            count++;
            help2 = ++help;

            PlayerPrefs.SetInt("mainScore", help2);

            if (PlayerPrefs.GetInt("sound") == 1)
            {
                StartCoroutine(sound());
            }
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Coin" && doubleCoinHelp >= 1)
        {
            count += 2;
            help2 = ++help;
            help2 = ++help;

            PlayerPrefs.SetInt("mainScore", help2);

            if (PlayerPrefs.GetInt("sound") == 1)
            {
                StartCoroutine(sound());
            }
            Destroy(other.gameObject);
        }
    }

    void SetCount()
    {
        countText.text = "Score: " + count.ToString();
    }

    void HighScore()
    {
        highScoreText.text = "Highscore: " + PlayerPrefs.GetInt("score");
    }

    IEnumerator MakeExplosionSound()
    {
        AudioSource.PlayClipAtPoint(explose, transform.position);
        yield return new WaitForSeconds(3f);
        if (lose)
        {
            SceneManager.LoadScene(3);
        }
    }

    IEnumerator Explose()
    {
        exp1.SetActive(true);
        yield return new WaitForSeconds(0.7f);
        exp1.SetActive(false);
        exp2.SetActive(true);
        yield return new WaitForSeconds(0.7f);
        exp2.SetActive(false);
        exp3.SetActive(true);
        yield return new WaitForSeconds(0.7f);
        exp3.SetActive(false);
        exp4.SetActive(true);
        yield return new WaitForSeconds(0.7f);
        exp4.SetActive(false);
        if (lose)
        {
            SceneManager.LoadScene(3);
        }
    }

    IEnumerator sound()
    {
        AudioSource.PlayClipAtPoint(getCoin, transform.position);

        yield return new WaitForSeconds(0.3f);
    }

    IEnumerator flap()
    {
        yield return new WaitForSeconds(5f);

        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[1];

        yield return new WaitForSeconds(5f);

        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[0];

        //yield return new WaitForSeconds(2f);
    }
}