using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Present : MonoBehaviour
{

    public Ads ads;

    public int present;
    public int help, help2;

    public AudioClip click;

    public GameObject err;

    public Text coinText;
    public Text countPresent;

    private void OnMouseDown()
    {
        present = PlayerPrefs.GetInt("Present");

        transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);

        if (PlayerPrefs.GetInt("sound") == 1)
        {
            StartCoroutine(Click());
        }
    }

    private void OnMouseUp()
    {
        transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);

        countPresent.text = "" + PlayerPrefs.GetInt("Present");
    }

/*private void OnMouseUpAsButton()
{
    if (Advertisement.IsReady())
    {
        Advertisement.Show();
        //Present++;
        //PlayerPrefs.SetInt("Present", Present);
    }
}*/

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
