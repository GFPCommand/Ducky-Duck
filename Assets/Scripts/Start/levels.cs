using System.Collections;
using UnityEngine;

public class levels : MonoBehaviour
{
    public AudioClip click;

    public GameObject BackButtton;
    public GameObject backSelect;
    public GameObject oneLvl;
    public GameObject twoLvl;
    public GameObject threeLvl;
    public GameObject fourLvl;
    public GameObject fiveLvl;
    public GameObject arcade;
    public GameObject LVLs;
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

    private void OnMouseDown()
    {
        transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);

        if(PlayerPrefs.GetInt("sound") == 1)
        {
            StartCoroutine(Click());
        }
    }

    private void OnMouseUp()
    {
        transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);

        arcade.SetActive(false);
        LVLs.SetActive(false);
        BackButtton.SetActive(false);
        selgameText.SetActive(false);

        backSelect.SetActive(true);
        oneLvl.SetActive(true);
        twoLvl.SetActive(true);
        threeLvl.SetActive(true);
        fourLvl.SetActive(true);
        fiveLvl.SetActive(true);
        sixLVL.SetActive(true);
        sevenLVL.SetActive(true);
        eightLVL.SetActive(true);
        nineLVL.SetActive(true);
        tenLVL.SetActive(true);
        elevenLVL.SetActive(true);
        twelwLVL.SetActive(true);
        thirteenLVL.SetActive(true);
        fourteenLVL.SetActive(true);
        fifteenLVL.SetActive(true);
        rArrow.SetActive(true);
        lArrow.SetActive(true);
        lvlText.SetActive(true);
    }

    IEnumerator Click()
    {
        AudioSource.PlayClipAtPoint(click, transform.position);

        yield return new WaitForSeconds(0.5f);
    }
}
