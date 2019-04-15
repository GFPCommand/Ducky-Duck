using System.Collections;
using UnityEngine;

public class musicOn : MonoBehaviour {

    public GameObject musicon;
    public GameObject musicoff;

    public static int music = 1;

    public AudioClip click;

    private void OnMouseDown()
    {
        transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);

        music = 0;

        PlayerPrefs.SetInt("music", music);

        if (PlayerPrefs.GetInt("sound") == 1)
        {
            StartCoroutine(Click());
        }
    }

    private void OnMouseUp()
    {
        transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);

        musicon.SetActive(false);
        musicoff.SetActive(true);
    }

    IEnumerator Click()
    {
        AudioSource.PlayClipAtPoint(click, transform.position);
        yield return new WaitForSeconds(0.5f);
    }
}
