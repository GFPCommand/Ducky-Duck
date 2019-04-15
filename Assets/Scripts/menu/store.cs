using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class store : MonoBehaviour {

    public GameObject start;
    public GameObject Store;
    public GameObject settings;
    public GameObject exit;
    public GameObject back;
    public GameObject extraLife;
    public GameObject shield;
    public GameObject buy1;
    public GameObject buy2;
    public GameObject mainCoin;
    public GameObject rArrow;
    public GameObject lArrow;

    public GameObject storeText;
    public GameObject mainText;
    public GameObject ELText;
    public GameObject shieldText;
    public GameObject CoinText;
    public GameObject CountEL;
    public GameObject CountSC;

    public Text coinText;
    public Text countEL;
    public Text countSC;

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

        start.SetActive(false);
        Store.SetActive(false);
        settings.SetActive(false);
        exit.SetActive(false);

        extraLife.SetActive(true);
        shield.SetActive(true);
        buy1.SetActive(true);
        buy2.SetActive(true);
        mainCoin.SetActive(true);
        rArrow.SetActive(true);
        lArrow.SetActive(true);

        mainText.SetActive(false);
        storeText.SetActive(true);
        ELText.SetActive(true);
        shieldText.SetActive(true);
        CoinText.SetActive(true);
        CountEL.SetActive(true);
        CountSC.SetActive(true);

        back.SetActive(true);

        coinText.text = "" + PlayerPrefs.GetInt("mainScore");
        countEL.text = "" + PlayerPrefs.GetInt("ExtraLife");
        countSC.text = "" + PlayerPrefs.GetInt("Shield");
    }

    IEnumerator Click()
    {
        AudioSource.PlayClipAtPoint(click, transform.position);
        yield return new WaitForSeconds(0.5f);
    }
}