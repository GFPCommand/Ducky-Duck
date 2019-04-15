using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class buyEL : MonoBehaviour {

    public int ExtraLife;

    public int help;
    public int help2;

    public AudioClip click;

    public GameObject err;

    public Text coinText;
    public Text countEL;

    private void OnMouseDown()
    {
        help = PlayerPrefs.GetInt("mainScore");
        ExtraLife = PlayerPrefs.GetInt("ExtraLife");

        transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);

        if(PlayerPrefs.GetInt("sound") == 1)
        {
            StartCoroutine(Click());
        }
    }

    private void OnMouseUp()
    {
        transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);

        coinText.text = "" + PlayerPrefs.GetInt("mainScore");
        countEL.text = "" + PlayerPrefs.GetInt("ExtraLife");
    }

    private void OnMouseUpAsButton()
    {
        if (PlayerPrefs.GetInt("mainScore") >= 25)
        {
            ExtraLife++;
            help2 = help - 25;
            PlayerPrefs.SetInt("ExtraLife", ExtraLife);
            PlayerPrefs.SetInt("mainScore", help2);
        } else
        {
            StartCoroutine(error());
        }
    }

    IEnumerator Click()
    {
        AudioSource.PlayClipAtPoint(click, transform.position);
        yield return new WaitForSeconds(0.5f);
    }

    IEnumerator error()
    {
        err.SetActive(true);
        yield return new WaitForSeconds(1f);
        err.SetActive(false);
    }
}
