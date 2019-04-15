using System.Collections;
using UnityEngine;

public class Resume : MonoBehaviour {

    public GameObject restart;
    public GameObject resume;
    public GameObject exit;
    public GameObject pause;

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
        transform.localScale -= new Vector3 (0.1f, 0.1f, 0.1f);

        if (Pause.pause == true)
        {
            Pause.pause = false;
            restart.SetActive(false);
            resume.SetActive(false);
            exit.SetActive(false);
            Time.timeScale = 1;
        }
    }

    IEnumerator Click()
    {
        AudioSource.PlayClipAtPoint(click, transform.position);

        yield return new WaitForSeconds(0.3f);
    }
}
