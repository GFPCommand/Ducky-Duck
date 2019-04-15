using System.Collections;
using UnityEngine;

public class yesButton : MonoBehaviour {

    public AudioClip click;

    public GameObject yes, no, yesORno;
    public GameObject pause;

    private int ExtraLifeHelp, ExtraLifeHelp2;

    private void OnMouseDown()
    {
        ExtraLifeHelp = PlayerPrefs.GetInt("ExtraLife");

        transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);

        if (PlayerPrefs.GetInt("sound") == 1)
        {
            StartCoroutine(Click());
        }
    }

    private void OnMouseUp()
    {
        transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);

        Player.lose = false;

        yes.SetActive(false);
        no.SetActive(false);
        yesORno.SetActive(false);

        pause.SetActive(true);

        ExtraLifeHelp2 = --ExtraLifeHelp;
        PlayerPrefs.SetInt("ExtraLife", ExtraLifeHelp2);

        Time.timeScale = 1;
    }

    IEnumerator Click()
    {
        AudioSource.PlayClipAtPoint(click, transform.position);
        yield return new WaitForSeconds(0.5f);
    }
}
