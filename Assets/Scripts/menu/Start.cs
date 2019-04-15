using System.Collections;
using UnityEngine;

public class Start : MonoBehaviour {

    public GameObject start;
    public GameObject store;
    public GameObject settings;
    public GameObject exit;
    public GameObject back;

    public GameObject arcade;
    public GameObject LVLs;

    public GameObject mainText;
    public GameObject selgameText;

    public AudioClip click;

	void OnMouseDown ()
    {
        transform.localScale += new Vector3 (0.1f, 0.1f, 0.1f);

        if (PlayerPrefs.GetInt("sound") == 1)
        {
            StartCoroutine(Click());
        }
    }

    private void OnMouseUp()
    {
        transform.localScale -= new Vector3 (0.1f, 0.1f, 0.1f);

        start.SetActive(false);
        store.SetActive(false);
        settings.SetActive(false);
        exit.SetActive(false);

        arcade.SetActive(true);
        LVLs.SetActive(true);
        back.SetActive(true);

        mainText.SetActive(false);
        selgameText.SetActive(true);
    }

    IEnumerator Click()
    {
        AudioSource.PlayClipAtPoint(click, transform.position);
        yield return new WaitForSeconds(0.5f);
    }
}
