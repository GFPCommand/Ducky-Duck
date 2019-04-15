using System.Collections;
using UnityEngine;

public class settings : MonoBehaviour {

    public GameObject start;
    public GameObject store;
    public GameObject Settings;
    public GameObject exit;
    public GameObject back;

    public GameObject musicon;
    public GameObject musicoff;
    public GameObject soundon;
    public GameObject soundoff;
    public GameObject reset;

    public GameObject settingText;
    public GameObject mainText;

    public AudioClip click;

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

        start.SetActive(false);
        store.SetActive(false);
        Settings.SetActive(false);
        exit.SetActive(false);

        if (PlayerPrefs.GetInt("sound") == 0) {
            soundon.SetActive(false);
            soundoff.SetActive(true);
        } else if (PlayerPrefs.GetInt("sound") == 1) {
            soundon.SetActive(true);
            soundoff.SetActive(false);
        }

        if (PlayerPrefs.GetInt("music") == 0) {
            musicon.SetActive(false);
            musicoff.SetActive(true);
        } else if (PlayerPrefs.GetInt("music") == 1) {
            musicon.SetActive(true);
            musicoff.SetActive(false);
        }

        back.SetActive(true);
        reset.SetActive(true);

        settingText.SetActive(true);
        mainText.SetActive(false);
    }

    IEnumerator Click()
    {
        AudioSource.PlayClipAtPoint(click, transform.position);
        yield return new WaitForSeconds(0.5f);
    }
}
