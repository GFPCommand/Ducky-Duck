using System.Collections;
using UnityEngine;

public class restartGame : MonoBehaviour
{
    public AudioClip click;

    public GameObject done;

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

        PlayerPrefs.DeleteAll();

        StartCoroutine(Done());
    }

    IEnumerator Click()
    {
        AudioSource.PlayClipAtPoint(click, transform.position);

        yield return new WaitForSeconds(0.5f);
    }

    IEnumerator Done ()
    {
        done.SetActive(true);

        yield return new WaitForSeconds(1f);

        done.SetActive(false);
    }
}
