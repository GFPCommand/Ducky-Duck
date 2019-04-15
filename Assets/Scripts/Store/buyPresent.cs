using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class buyPresent : MonoBehaviour
{

    public int Present;

    public int help;
    public int help2;

    public AudioClip click;

    public GameObject err;

    public Text coinText;
    public Text countPresent;

    private void OnMouseDown()
    {
        help = PlayerPrefs.GetInt("mainScore");
        Present = PlayerPrefs.GetInt("Present");

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
        countPresent.text = "" + PlayerPrefs.GetInt("Present");
    }

    private void OnMouseUpAsButton()
    {
        if (PlayerPrefs.GetInt("mainScore") >= 50)
        {
            Present++;
            help2 = help - 50;
            PlayerPrefs.SetInt("Present", Present);
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
