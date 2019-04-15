using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class hardButton : MonoBehaviour {

    private int diff = 3;

    public AudioClip click;

    private void OnMouseDown()
    {
        transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);

        if (PlayerPrefs.GetInt("sound") == 1)
        {
            StartCoroutine(Click());
        }
        PlayerPrefs.GetInt("difficult");
        PlayerPrefs.SetInt("difficult", diff);
    }

    private void OnMouseUp()
    {
        transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);

        SceneManager.LoadScene(1);
    }

    IEnumerator Click()
    {
        AudioSource.PlayClipAtPoint(click, transform.position);
        yield return new WaitForSeconds(0.5f);
    }
}
