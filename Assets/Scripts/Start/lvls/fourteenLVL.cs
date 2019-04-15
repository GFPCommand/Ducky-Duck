﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fourteenLVL : MonoBehaviour
{
    public AudioClip click;

    public int diff = 14;

    public Sprite[] lvls = new Sprite[2];

    private void Update()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = PlayerPrefs.GetInt("selLVLs") < 13 ? lvls[0] : lvls[1];
    }

    private void OnMouseDown()
    {
        transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);

        if (PlayerPrefs.GetInt("sound") == 1)
            StartCoroutine(Click());
    }

    private void OnMouseUp()
    {
        transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);

        if (PlayerPrefs.GetInt("selLVLs") >= 13)
        {
            PlayerPrefs.SetInt("lvlsDiff", diff);

            SceneManager.LoadScene(2);
        }
    }

    IEnumerator Click()
    {
        AudioSource.PlayClipAtPoint(click, transform.position);

        yield return new WaitForSeconds(0.5f);
    }
}