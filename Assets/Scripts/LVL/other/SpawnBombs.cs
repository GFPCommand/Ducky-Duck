using System.Collections;
using UnityEngine;

public class SpawnBombs : MonoBehaviour {

    public GameObject bomb;

    private void Start()
    {
        if (PlayerPrefs.GetInt("difficult") == 1)
        {
            StartCoroutine(eSpawn());
        } else if (PlayerPrefs.GetInt("difficult") == 2)
        {
            StartCoroutine(mSpawn());
        } else if (PlayerPrefs.GetInt("difficult") == 3)
        {
            StartCoroutine(hSpawn());
        }
    }

    IEnumerator eSpawn ()
    {
        while (!Player.lose)
        {
            Instantiate(bomb, new Vector2(Random.Range(-2.5f, 2.5f), 5.9f), Quaternion.identity);
            yield return new WaitForSeconds(1.5f);
        }
    }

    IEnumerator mSpawn ()
    {
        while (!Player.lose)
        {
            Instantiate(bomb, new Vector2(Random.Range(-2.5f, 2.5f), 5.9f), Quaternion.identity);
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator hSpawn ()
    {
        while (!Player.lose)
        {
            Instantiate(bomb, new Vector2(Random.Range(-2.5f, 2.5f), 5.9f), Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
