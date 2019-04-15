using System.Collections;
using UnityEngine;

public class backSelect : MonoBehaviour
{
    public AudioClip click;

    public GameObject BackButton;
    public GameObject BackSelect;
    public GameObject eButton;
    public GameObject mButton;
    public GameObject hButton;
    public GameObject arcade;
    public GameObject LVLs;
    public GameObject oneLVL;
    public GameObject twoLVL;
    public GameObject threeLVL;
    public GameObject fourLVL;
    public GameObject fiveLVL;
    public GameObject sixLVL;
    public GameObject sevenLVL;
    public GameObject eightLVL;
    public GameObject nineLVL;
    public GameObject tenLVL;
    public GameObject elevenLVL;
    public GameObject twelwLVL;
    public GameObject thirteenLVL;
    public GameObject fourteenLVL;
    public GameObject fifteenLVL;
    public GameObject rArrow;
    public GameObject lArrow;
    public GameObject lvlText;
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

        BackButton.SetActive(true);
        arcade.SetActive(true);
        LVLs.SetActive(true);
        selgameText.SetActive(true);

        BackSelect.SetActive(false);
        eButton.SetActive(false);
        mButton.SetActive(false);
        hButton.SetActive(false);
        oneLVL.SetActive(false);
        twoLVL.SetActive(false);
        threeLVL.SetActive(false);
        fourLVL.SetActive(false);
        fiveLVL.SetActive(false);
        sixLVL.SetActive(false);
        sevenLVL.SetActive(false);
        eightLVL.SetActive(false);
        nineLVL.SetActive(false);
        tenLVL.SetActive(false);
        elevenLVL.SetActive(false);
        twelwLVL.SetActive(false);
        thirteenLVL.SetActive(false);
        fourteenLVL.SetActive(false);
        fifteenLVL.SetActive(false);
        rArrow.SetActive(false);
        lArrow.SetActive(false);
        lvlText.SetActive(false);
        startText.SetActive(false);
    }

    IEnumerator Click()
    {
        AudioSource.PlayClipAtPoint(click, transform.position);

        yield return new WaitForSeconds(0.5f);
    }
}
