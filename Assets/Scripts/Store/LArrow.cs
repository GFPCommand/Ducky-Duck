using System.Collections;
using UnityEngine;

public class LArrow : MonoBehaviour {

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

        doubleCoin.SetActive(false);
        countDoubleCoin.SetActive(false);
        buy3.SetActive(false);
        doubleCoinText.SetActive(false);
        PresentText.SetActive(false);
        Present.SetActive(false);
        countPresent.SetActive(false);
        buy4.SetActive(false);
        buttonPlus.SetActive(false);

        countEL.SetActive(true);
        countSC.SetActive(true);
        ExtraLife.SetActive(true);
        Shield.SetActive(true);
        buy1.SetActive(true);
        buy2.SetActive(true);
        SCText.SetActive(true);
        ELText.SetActive(true);
    }

    IEnumerator Click()
    {
        AudioSource.PlayClipAtPoint(click, transform.position);
        yield return new WaitForSeconds(0.5f);
    }
}
