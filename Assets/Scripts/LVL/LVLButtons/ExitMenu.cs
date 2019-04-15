using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitMenu : MonoBehaviour {

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

        SceneManager.LoadScene(0);
    }

    IEnumerator Click ()
    {
        AudioSource.PlayClipAtPoint(click, transform.position);

        yield return new WaitForSeconds(0.3f);
    }
}
