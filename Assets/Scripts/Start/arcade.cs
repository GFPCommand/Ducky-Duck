using System.Collections;
using UnityEngine;

public class arcade : MonoBehaviour
{
    public AudioClip click;

    public GameObject eButton;
    public GameObject mButton;
    public GameObject hButton;

    public GameObject backSelect;
    public GameObject BackButton;
    public GameObject Arcade;
    public GameObject lvls;
    public GameObject selgameText;
    public GameObject startText;

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

        eButton.SetActive(true);
        mButton.SetActive(true);
        hButton.SetActive(true);
        startText.SetActive(true);

        backSelect.SetActive(true);
        BackButton.SetActive(false);
        Arcade.SetActive(false);
        lvls.SetActive(false);
        selgameText.SetActive(false);
    }

    IEnumerator Click()
    {
        AudioSource.PlayClipAtPoint(click, transform.position);

        yield return new WaitForSeconds(0.5f);
    }
}
