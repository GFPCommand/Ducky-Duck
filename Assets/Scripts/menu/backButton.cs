using System.Collections;
using UnityEngine;

public class backButton : MonoBehaviour {

    public GameObject start;
    public GameObject store;
    public GameObject settings;
    public GameObject exit;
    public GameObject back;
    public GameObject arcade;
    public GameObject LVLs;
    public GameObject musicon;
    public GameObject musicoff;
    public GameObject soundon;
    public GameObject soundoff;
    public GameObject buyButton1;
    public GameObject buyButton2;
    public GameObject RArrow;
    public GameObject LArrow;

    public GameObject EL;
    public GameObject shield;
    public GameObject coin;

    public GameObject mainText;
    public GameObject startText;
    public GameObject storeText;
    public GameObject settingText;
    public GameObject coinText;
    public GameObject elText;
    public GameObject shieldText;
    public GameObject countEL;
    public GameObject countSC;
    public GameObject doubleCoin;
    public GameObject countDoubleCoin;
    public GameObject buy3;
    public GameObject buy4;
    public GameObject PresentText;
    public GameObject Present;
    public GameObject countPresent;
    public GameObject doubleCoinText;
    public GameObject buttonPlus;
    public GameObject reset;
    public GameObject selgameText;

    public AudioClip click;

    private void OnMouseDown()
    {
        transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
        if (PlayerPrefs.GetInt("sound") == 1) {
            StartCoroutine(Click());
        }
    }

    private void OnMouseUp()
    {
        transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);

        start.SetActive(true);
        store.SetActive(true);
        settings.SetActive(true);
        exit.SetActive(true);

        back.SetActive(false);
        arcade.SetActive(false);
        LVLs.SetActive(false);
        musicon.SetActive(false);
        musicoff.SetActive(false);
        soundon.SetActive(false);
        soundoff.SetActive(false);

        buyButton1.SetActive(false);
        buyButton2.SetActive(false);
        RArrow.SetActive(false);
        LArrow.SetActive(false);

        EL.SetActive(false);
        shield.SetActive(false);
        coin.SetActive(false);
        Present.SetActive(false);

        mainText.SetActive(true);
        storeText.SetActive(false);
        settingText.SetActive(false);
        startText.SetActive(false);
        coinText.SetActive(false);
        elText.SetActive(false);
        shieldText.SetActive(false);
        countEL.SetActive(false);
        countSC.SetActive(false);
        countPresent.SetActive(false);

        doubleCoin.SetActive(false);
        countDoubleCoin.SetActive(false);
        buy3.SetActive(false);
        buy4.SetActive(false);
        doubleCoinText.SetActive(false);
        PresentText.SetActive(false);
        buttonPlus.SetActive(false);
        reset.SetActive(false);
        selgameText.SetActive(false);
    }

    IEnumerator Click ()
    {
        AudioSource.PlayClipAtPoint(click, transform.position);
        yield return new WaitForSeconds(0.5f);
    }
}
