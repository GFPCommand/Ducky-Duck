using System.Collections;
using UnityEngine;

public class soundOff : MonoBehaviour {

    public GameObject soundon;
    public GameObject soundoff;

    public AudioClip click;

    private void OnMouseDown()
    {
        transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);

        soundOn.sound = 1;

        PlayerPrefs.SetInt("sound", soundOn.sound);
        if (PlayerPrefs.GetInt("sound") == 1)
        {
            StartCoroutine(Click());
        }
    }

    private void OnMouseUp()
    {
        transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);

        soundon.SetActive(true);
        soundoff.SetActive(false);
    }

    IEnumerator Click()
    {
        AudioSource.PlayClipAtPoint(click, transform.position);
        yield return new WaitForSeconds(0.5f);
    }
}
