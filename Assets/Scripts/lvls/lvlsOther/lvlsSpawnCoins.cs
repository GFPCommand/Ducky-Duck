using System.Collections;
using UnityEngine;

public class lvlsSpawnCoins : MonoBehaviour
{

    public GameObject coin;

    private void Start()
    {
        if (PlayerPrefs.GetInt("lvlsDiff") >= 1 && PlayerPrefs.GetInt("lvlsDiff") <= 5)
        {
            StartCoroutine(eSpawn());
        }
        else if (PlayerPrefs.GetInt("lvlsDiff") >= 6 && PlayerPrefs.GetInt("lvlsDiff") <= 10)
        {
            StartCoroutine(mSpawn());
        }
        else if (PlayerPrefs.GetInt("lvlsDiff") >= 11 && PlayerPrefs.GetInt("lvlsDiff") <= 15)
        {
            StartCoroutine(hSpawn());
        }
    }

    IEnumerator eSpawn()
    {
        while (!Player.lose)
        {
            Instantiate(coin, new Vector2(Random.Range(-2.5f, 2.5f), 5.9f), Quaternion.identity);
            yield return new WaitForSeconds(1.5f);
        }
    }

    IEnumerator mSpawn()
    {
        while (!Player.lose)
        {
            Instantiate(coin, new Vector2(Random.Range(-2.5f, 2.5f), 5.9f), Quaternion.identity);
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator hSpawn()
    {
        while (!Player.lose)
        {
            Instantiate(coin, new Vector2(Random.Range(-2.5f, 2.5f), 5.9f), Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
