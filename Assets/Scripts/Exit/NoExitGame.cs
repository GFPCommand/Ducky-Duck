using System.Collections;
using UnityEngine;

public class NoExitGame : MonoBehaviour {

    public AudioClip click;

    public GameObject start;
    public GameObject store;
    public GameObject settings;
    public GameObject exit;
    public GameObject mainText;

    public GameObject exitText;
    public GameObject noExit;
    public GameObject yesExit;

    private void OnMouseDown()
    {
        transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
        if (PlayerPrefs.GetInt("sound") == 1)
        {
            StartCoroutine(Click());
        }
    }

    private void OnMouseUp()
    {
        transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);

        exitText.SetActive(false);
        noExit.SetActive(false);
        yesExit.SetActive(false);

        start.SetActive(true);
        store.SetActive(true);
        settings.SetActive(true);
        exit.SetActive(true);
        mainText.SetActive(true);
    }

    IEnumerator Click()
    {
        AudioSource.PlayClipAtPoint(click, transform.position);
        yield return new WaitForSeconds(0.5f);
    }
}
