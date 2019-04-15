using System.Collections;
using UnityEngine;

public class RArrow : MonoBehaviour {

    public GameObject doubleCoin;
    public GameObject countDoubleCoin;
    public GameObject buy3;
    public GameObject doubleCoinText;
    public GameObject PresentText;
    public GameObject Present;
    public GameObject countPresent;
    public GameObject buy4;
    public GameObject buttonPlus;

    public GameObject countEL;
    public GameObject countSC;
    public GameObject ExtraLife;
    public GameObject Shield;
    public GameObject buy1;
    public GameObject buy2;
    public GameObject SCText;
    public GameObject ELText;

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

        doubleCoin.SetActive(true);
        countDoubleCoin.SetActive(true);
        buy3.SetActive(true);
        doubleCoinText.SetActive(true);
        PresentText.SetActive(true);
        Present.SetActive(true);
        countPresent.SetActive(true);
        buy4.SetActive(true);
        buttonPlus.SetActive(true);

        countEL.SetActive(false);
        countSC.SetActive(false);
        ExtraLife.SetActive(false);
        Shield.SetActive(false);
        buy1.SetActive(false);
        buy2.SetActive(false);
        SCText.SetActive(false);
        ELText.SetActive(false);
    }

    IEnumerator Click()
    {
        AudioSource.PlayClipAtPoint(click, transform.position);
        yield return new WaitForSeconds(0.5f);
    }
}
