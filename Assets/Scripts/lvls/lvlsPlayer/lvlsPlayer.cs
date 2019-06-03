using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class lvlsPlayer : MonoBehaviour
{
    public static int count;
    private int help, help2, ShieldHelp, ShieldHelp2, doubleCoinHelp, doubleCoinHelp2, lvls, countScore, countLVLs;

    public GameObject music;

    public Text countText, noyesText;

    public GameObject restart, pause, exit;

    public GameObject exp1, exp2, exp3, exp4;

    public AudioClip explose, getCoin;

    public GameObject yes, no, yesORno;

    public GameObject playerShield, player;

    public Sprite[] sprites = new Sprite[2];

    public CircleCollider2D cc;
    public PolygonCollider2D pc;

    public static bool lose = false;
    public static bool win = false;

    private void Awake()
    {
        countLVLs = PlayerPrefs.GetInt("selLVLs");

        Time.timeScale = 1;
        lose = false;
        win = false;
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
        }
        else
        {
            pc.GetComponent<PolygonCollider2D>().enabled = true;
            cc.GetComponent<CircleCollider2D>().enabled = false;
        }

        if (PlayerPrefs.GetInt("music") == 1)
        {
            music.SetActive(true);
        }
        else
        {
            music.SetActive(false);
        }

        SetCount();
        ShieldHelp = PlayerPrefs.GetInt("Shield");
        doubleCoinHelp = PlayerPrefs.GetInt("doubleCoin");
        help = PlayerPrefs.GetInt("mainScore");

        countScore = doubleCoinHelp >= 1 ? -2 : -1;
    }

    void Update()
    {

        if (count > PlayerPrefs.GetInt("score"))
        {
            PlayerPrefs.GetInt("score");
            PlayerPrefs.SetInt("score", count);
        }
        SetCount();

        StartCoroutine(flap());

        if (PlayerPrefs.GetInt("lvlsDiff") == 1 && count >= 20)
        {
            win = true;
            SceneManager.LoadScene(4);

            lvls = 1;

            if (countLVLs > lvls)
                PlayerPrefs.SetInt("selLVLs", countLVLs);
            else
                PlayerPrefs.SetInt("selLVLs", lvls);
        }
        else if (PlayerPrefs.GetInt("lvlsDiff") == 2 && count >= 40)
        {
            win = true;
            SceneManager.LoadScene(4);
            lvls = 2;
            if (countLVLs > lvls)
                PlayerPrefs.SetInt("selLVLs", countLVLs);
            else
                PlayerPrefs.SetInt("selLVLs", lvls);
        }
        else if (PlayerPrefs.GetInt("lvlsDiff") == 3 && count >= 60)
        {
            win = true;
            SceneManager.LoadScene(4);
            lvls = 3;
            if (countLVLs > lvls)
                PlayerPrefs.SetInt("selLVLs", countLVLs);
            else
                PlayerPrefs.SetInt("selLVLs", lvls);
        }
        else if (PlayerPrefs.GetInt("lvlsDiff") == 4 && count >= 80)
        {
            win = true;
            SceneManager.LoadScene(4);
            lvls = 4;
            if (countLVLs > lvls)
                PlayerPrefs.SetInt("selLVLs", countLVLs);
            else
                PlayerPrefs.SetInt("selLVLs", lvls);
        }
        else if (PlayerPrefs.GetInt("lvlsDiff") == 5 && count >= 100)
        {
            win = true;
            SceneManager.LoadScene(4);
            lvls = 5;
            if (countLVLs > lvls)
                PlayerPrefs.SetInt("selLVLs", countLVLs);
            else
                PlayerPrefs.SetInt("selLVLs", lvls);
        }
        else if (PlayerPrefs.GetInt("lvlsDiff") == 6 && count >= 120)
        {
            win = true;
            SceneManager.LoadScene(4);
            lvls = 6;
            if (countLVLs > lvls)
                PlayerPrefs.SetInt("selLVLs", countLVLs);
            else
                PlayerPrefs.SetInt("selLVLs", lvls);
        }
        else if (PlayerPrefs.GetInt("lvlsDiff") == 7 && count >= 140)
        {
            win = true;
            SceneManager.LoadScene(4);
            lvls = 7;
            if (countLVLs > lvls)
                PlayerPrefs.SetInt("selLVLs", countLVLs);
            else
                PlayerPrefs.SetInt("selLVLs", lvls);
        }
        else if (PlayerPrefs.GetInt("lvlsDiff") == 8 && count >= 160)
        {
            win = true;
            SceneManager.LoadScene(4);
            lvls = 8;
            if (countLVLs > lvls)
                PlayerPrefs.SetInt("selLVLs", countLVLs);
            else
                PlayerPrefs.SetInt("selLVLs", lvls);
        }
        else if (PlayerPrefs.GetInt("lvlsDiff") == 9 && count >= 180)
        {
            win = true;
            SceneManager.LoadScene(4);
            lvls = 9;
            if (countLVLs > lvls)
                PlayerPrefs.SetInt("selLVLs", countLVLs);
            else
                PlayerPrefs.SetInt("selLVLs", lvls);
        }
        else if (PlayerPrefs.GetInt("lvlsDiff") == 10 && count >= 200)
        {
            win = true;
            SceneManager.LoadScene(4);
            lvls = 10;
            if (countLVLs > lvls)
                PlayerPrefs.SetInt("selLVLs", countLVLs);
            else
                PlayerPrefs.SetInt("selLVLs", lvls);
        }
        else if (PlayerPrefs.GetInt("lvlsDiff") == 11 && count >= 220)
        {
            win = true;
            SceneManager.LoadScene(4);
            lvls = 11;
            if (countLVLs > lvls)
                PlayerPrefs.SetInt("selLVLs", countLVLs);
            else
                PlayerPrefs.SetInt("selLVLs", lvls);
        }
        else if (PlayerPrefs.GetInt("lvlsDiff") == 12 && count >= 240)
        {
            win = true;
            SceneManager.LoadScene(4);
            lvls = 12;
            if (countLVLs > lvls)
                PlayerPrefs.SetInt("selLVLs", countLVLs);
            else
                PlayerPrefs.SetInt("selLVLs", lvls);
        }
        else if (PlayerPrefs.GetInt("lvlsDiff") == 13 && count >= 260)
        {
            win = true;
            SceneManager.LoadScene(4);
            lvls = 13;
            if (countLVLs > lvls)
                PlayerPrefs.SetInt("selLVLs", countLVLs);
            else
                PlayerPrefs.SetInt("selLVLs", lvls);
        }
        else if (PlayerPrefs.GetInt("lvlsDiff") == 14 && count >= 280)
        {
            win = true;
            SceneManager.LoadScene(4);
            lvls = 14;
            if (countLVLs > lvls)
                PlayerPrefs.SetInt("selLVLs", countLVLs);
            else
                PlayerPrefs.SetInt("selLVLs", lvls);
        }
        else if (PlayerPrefs.GetInt("lvlsDiff") == 15 && count >= 300)
        {
            win = true;
            SceneManager.LoadScene(4);
            lvls = 15;
            if (countLVLs > lvls)
                PlayerPrefs.SetInt("selLVLs", countLVLs);
            else
                PlayerPrefs.SetInt("selLVLs", lvls);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bomb")
        {
            if (PlayerPrefs.GetInt("Extralife") < 1 && PlayerPrefs.GetInt("Shield") < 1)
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
            }
            else if (PlayerPrefs.GetInt("ExtraLife") >= 1 && PlayerPrefs.GetInt("Shield") >= 1)
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

            }
            else if (PlayerPrefs.GetInt("ExtraLife") >= 1 && PlayerPrefs.GetInt("Shield") < 1)
            {
                Destroy(other.gameObject);
                yesORno.SetActive(true);
                yes.SetActive(true);
                no.SetActive(true);
                pause.SetActive(false);
                Time.timeScale = 0;
                noyesText.text = "You have " + PlayerPrefs.GetInt("ExtraLife") + " lifes. Continue?";
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
            else if (PlayerPrefs.GetInt("ExtraLife") < 1 && PlayerPrefs.GetInt("Shield") >= 1)
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
        }

        if (other.gameObject.tag == "Coin" && PlayerPrefs.GetInt("doubleCoin") < 1)
        {
            count++;
            countScore++;
            SetCount();

            if (count > (countScore + 1))
                count = 0;

            help2 = ++help;

            PlayerPrefs.SetInt("mainScore", help2);

            if (PlayerPrefs.GetInt("sound") == 1)
            {
                StartCoroutine(sound());
            }
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Coin" && PlayerPrefs.GetInt("doubleCoin") >= 1)
        {
            count += 2;
            countScore += 2;
            SetCount();

            if (count > (countScore + 2))
                count = 0;

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
        if (PlayerPrefs.GetInt("lvlsDiff") == 1)
            countText.text = "Score: " + count.ToString() + " / 20";
        else if (PlayerPrefs.GetInt("lvlsDiff") == 2)
            countText.text = "Score: " + count.ToString() + " / 40";
        else if (PlayerPrefs.GetInt("lvlsDiff") == 3)
            countText.text = "Score: " + count.ToString() + " / 60";
        else if (PlayerPrefs.GetInt("lvlsDiff") == 4)
            countText.text = "Score: " + count.ToString() + " / 80";
        else if (PlayerPrefs.GetInt("lvlsDiff") == 5)
            countText.text = "Score: " + count.ToString() + " / 100";
        else if (PlayerPrefs.GetInt("lvlsDiff") == 6)
            countText.text = "Score: " + count.ToString() + " / 120";
        else if (PlayerPrefs.GetInt("lvlsDiff") == 7)
            countText.text = "Score: " + count.ToString() + " / 140";
        else if (PlayerPrefs.GetInt("lvlsDiff") == 8)
            countText.text = "Score: " + count.ToString() + " / 160";
        else if (PlayerPrefs.GetInt("lvlsDiff") == 9)
            countText.text = "Score: " + count.ToString() + " / 180";
        else if (PlayerPrefs.GetInt("lvlsDiff") == 10)
            countText.text = "Score: " + count.ToString() + " / 200";
        else if (PlayerPrefs.GetInt("lvlsDiff") == 11)
            countText.text = "Score: " + count.ToString() + " / 220";
        else if (PlayerPrefs.GetInt("lvlsDiff") == 12)
            countText.text = "Score: " + count.ToString() + " / 240";
        else if (PlayerPrefs.GetInt("lvlsDiff") == 13)
            countText.text = "Score: " + count.ToString() + " / 260";
        else if (PlayerPrefs.GetInt("lvlsDiff") == 14)
            countText.text = "Score: " + count.ToString() + " / 280";
        else if (PlayerPrefs.GetInt("lvlsDiff") == 15)
            countText.text = "Score: " + count.ToString() + " / 300";
    }

    IEnumerator MakeExplosionSound()
    {
        AudioSource.PlayClipAtPoint(explose, transform.position);
        yield return new WaitForSeconds(3f);
        if (lose)
        {
            SceneManager.LoadScene(4);
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
            SceneManager.LoadScene(4);
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