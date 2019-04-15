using System.Collections;
using UnityEngine;

public class Quit : MonoBehaviour {

    public AudioClip click;

    public GameObject yes;
    public GameObject no;
    public GameObject exitText;

    public GameObject mainText;
    public GameObject start;
    public GameObject store;
    public GameObject settings;
    public GameObject exit;

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

        yes.SetActive(true);
        no.SetActive(true);
        exitText.SetActive(true);

        mainText.SetActive(false);
        start.SetActive(false);
        store.SetActive(false);
        settings.SetActive(false);
        exit.SetActive(false);
    }

    IEnumerator Click()
    {
        AudioSource.PlayClipAtPoint(click, transform.position);
        yield return new WaitForSeconds(0.5f);
    }
}
