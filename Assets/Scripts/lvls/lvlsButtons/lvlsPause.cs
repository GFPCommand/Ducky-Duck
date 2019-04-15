using System.Collections;
using UnityEngine;

public class lvlsPause : MonoBehaviour
{

    public GameObject restart;
    public GameObject resume;
    public GameObject exit;

    public AudioClip click;

    public static bool pause = false;

    void OnMouseDown()
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
    }

    private void OnMouseUpAsButton()
    {
        if (!pause && !lvlsPlayer.lose)
        {
            Time.timeScale = 0;
            pause = true;
            restart.SetActive(true);
            resume.SetActive(true);
            exit.SetActive(true);
        }
        else if (pause && !lvlsPlayer.lose)
        {
            Time.timeScale = 1;
            pause = false;
            restart.SetActive(false);
            resume.SetActive(false);
            exit.SetActive(false);
        }
        else if (lvlsPlayer.lose)
        {
            Time.timeScale = 1;
            resume.SetActive(false);
            restart.SetActive(true);
        }
    }

    IEnumerator Click()
    {
        AudioSource.PlayClipAtPoint(click, transform.position);

        yield return new WaitForSeconds(0.3f);
    }
}
