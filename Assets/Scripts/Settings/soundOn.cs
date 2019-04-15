using System.Collections;
using UnityEngine;

public class soundOn : MonoBehaviour {

    public GameObject soundon;
    public GameObject soundoff;

    public static int sound = 1;

    public AudioClip click;

    private void OnMouseDown()
    {
        transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);

        sound = 0;

        PlayerPrefs.SetInt("sound", sound);

        if (PlayerPrefs.GetInt("sound") == 1)
        {
            StartCoroutine(Click());
        }
    }

    private void OnMouseUp()
    {
        transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);

        soundon.SetActive(false);
        soundoff.SetActive(true);
    }

    IEnumerator Click()
    {
        AudioSource.PlayClipAtPoint(click, transform.position);
        yield return new WaitForSeconds(0.5f);
    }
}
