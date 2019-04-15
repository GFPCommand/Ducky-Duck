using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class buyDoubleCoin : MonoBehaviour {

    public int DoubleCoin;

    public int help;
    public int help2;

    public AudioClip click;

    public GameObject err;

    public Text coinText;
    public Text countDC;

    private void OnMouseDown()
    {
        help = PlayerPrefs.GetInt("mainScore");
        DoubleCoin = PlayerPrefs.GetInt("doubleCoin");

        transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);

        if (PlayerPrefs.GetInt("sound") == 1)
        {
            StartCoroutine(Click());
        }
    }

    private void OnMouseUp()
    {
        transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);

        coinText.text = "" + PlayerPrefs.GetInt("mainScore");
        countDC.text = "" + PlayerPrefs.GetInt("doubleCoin");
    }

    private void OnMouseUpAsButton()
    {
        if (PlayerPrefs.GetInt("mainScore") >= 75)
        {
            DoubleCoin++;
            help2 = help - 75;
            PlayerPrefs.SetInt("doubleCoin", DoubleCoin);
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
