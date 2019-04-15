using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lvlsNButton : MonoBehaviour
{
    public AudioClip click;

    public GameObject NoButton;
    public GameObject YesButton;
    public GameObject YesOrNo;

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
        NoButton.SetActive(false);
        YesButton.SetActive(false);
        YesOrNo.SetActive(false);

        lvlsPlayer.lose = true;

        SceneManager.LoadScene(4);
    }

    IEnumerator Click()
    {
        AudioSource.PlayClipAtPoint(click, transform.position);
        yield return new WaitForSeconds(0.5f);
    }
}
