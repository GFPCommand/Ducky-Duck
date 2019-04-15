using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {

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
    }

    private void OnMouseUpAsButton()
    {
        SceneManager.LoadScene(1);
    }

    IEnumerator Click()
    {
        AudioSource.PlayClipAtPoint(click, transform.position);

        yield return new WaitForSeconds(0.3f);
    }
}
