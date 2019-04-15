using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class openPresent : MonoBehaviour
{
    public AudioClip click;

    public int rand, Present, Shield, ExtraLife, DoubleCoin, Coins, Coins2;

    public Text coinText, countPresent, countDC, countEL, countSC;

    private void OnMouseDown()
    {
        transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);

        Present = PlayerPrefs.GetInt("Present");
        Shield = PlayerPrefs.GetInt("Shield");
        ExtraLife = PlayerPrefs.GetInt("ExtraLife");
        DoubleCoin = PlayerPrefs.GetInt("doubleCoin");
        Coins = PlayerPrefs.GetInt("mainScore");

        if (PlayerPrefs.GetInt("sound") == 1)
        {
            StartCoroutine(Click());
        }
    }

    private void OnMouseUp()
    {
        transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);

        coinText.text = "" + PlayerPrefs.GetInt("mainScore");
        countPresent.text = "" + PlayerPrefs.GetInt("Present");
        countDC.text = "" + PlayerPrefs.GetInt("doubleCoin");
        countEL.text = "" + PlayerPrefs.GetInt("ExtraLife");
        countSC.text = "" + PlayerPrefs.GetInt("Shield");
    }

    private void OnMouseUpAsButton()
    {
        if (PlayerPrefs.GetInt("Present") >= 1)
        {
            Present--;

            PlayerPrefs.SetInt("Present", Present);

            rand = Random.Range(1, 11);

            if (rand == 1)
            {
                Shield++;

                PlayerPrefs.SetInt("Shield", Shield);
            }
            else if (rand == 2)
            {
                ExtraLife++;

                PlayerPrefs.SetInt("ExtraLife", ExtraLife);
            }
            else if (rand == 3)
            {
                DoubleCoin++;

                PlayerPrefs.SetInt("doubleCoin", DoubleCoin);
            }
            else if (rand == 4)
            {
                Coins2 = Coins + 25;

                PlayerPrefs.SetInt("mainScore", Coins2);
            } else if (rand == 5)
            {
                Present++;

                PlayerPrefs.SetInt("Present", Present);
            } else if (rand == 6)
            {
                Shield++;
                Shield++;

                PlayerPrefs.SetInt("Shield", Shield);
            } else if (rand == 7)
            {
                ExtraLife++;
                ExtraLife++;

                PlayerPrefs.SetInt("ExtraLife", ExtraLife);
            } else if (rand == 8)
            {
                DoubleCoin++;
                DoubleCoin++;

                PlayerPrefs.SetInt("doubleCoin", DoubleCoin);
            } else if (rand == 9)
            {
                Coins2 = Coins + 75;

                PlayerPrefs.SetInt("mainScore", Coins2);
            } else if (rand == 10)
            {
                Present++;
                Present++;

                PlayerPrefs.SetInt("Present", Present);
            }
        }
    }

    IEnumerator Click()
    {
        AudioSource.PlayClipAtPoint(click, transform.position);
        yield return new WaitForSeconds(0.5f);
    }
}
