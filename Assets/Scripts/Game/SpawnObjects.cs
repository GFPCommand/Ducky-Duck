using System.Collections;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    public GameObject coin, bomb;

    private float SpawnBombSpeed = 1f, SpawnCoinSpeed = 1f;
    float delta;

    private Vector2 RandBombX, RandCoinX, randVector;

    private void Start()
    {
        if (!LoadLevels.isLevels)
        {
            StartCoroutine(SpawnBombs());
            StartCoroutine(SpawnMoney());
        } else
        {
            StartCoroutine(SpawnBombsLVL());
            StartCoroutine(SpawnMoneyLVL());
        }
    }

    private void Update()
    {
        if (RandBombX.x > 0 && RandCoinX.x > 0)
        {
            delta = Mathf.Abs(RandBombX.x - RandCoinX.x);
        }
        else if (RandBombX.x > 0 && RandCoinX.x < 0)
        {
            delta = Mathf.Abs(RandBombX.x + RandCoinX.x);
        }
        else if (RandBombX.x < 0 && RandCoinX.x > 0)
        {
            delta = Mathf.Abs(RandBombX.x + RandCoinX.x);
        }
        else
        {
            delta = Mathf.Abs(RandBombX.x - RandCoinX.x);
        }
    }

    IEnumerator SpawnBombs()
    {
        while (!Player.lose && !Pause.isPause)
        {
            RandBombX = new Vector2(Random.Range(-2.3f, 2.3f), 5.9f);

            if (RandBombX == RandCoinX || delta <= 0.25f)
            {
                randVector = new Vector2(Random.Range(-2.3f, 2.3f), 5.9f);
                Instantiate(bomb, randVector, Quaternion.identity);
            } else
            {
                Instantiate(bomb, RandBombX, Quaternion.identity);
            }
            
            if (!LoadLevels.isLevels) SpawnBombSpeed -= 0.0005f;
            else
            {
                if (PlayerPrefs.GetInt("selLVL") >= 10)
                    SpawnBombSpeed -= (0.0001f * PlayerPrefs.GetInt("selLVL"));
                else SpawnBombSpeed -= (0.001f * PlayerPrefs.GetInt("selLVL"));
            }
            yield return new WaitForSeconds(SpawnBombSpeed);
        }
    }

    IEnumerator SpawnBombsLVL()
    {
        while (!PlayerLVL.lose && !Pause.isPause)
        {
            RandBombX = new Vector2(Random.Range(-2.3f, 2.3f), 5.9f);

            if (RandBombX == RandCoinX || delta <= 0.25f)
            {
                randVector = new Vector2(Random.Range(-2.3f, 2.3f), 5.9f);
                Instantiate(bomb, randVector, Quaternion.identity);
            }
            else
            {
                Instantiate(bomb, RandBombX, Quaternion.identity);
            }

            if (PlayerPrefs.GetInt("selLVL") >= 10)
                SpawnBombSpeed -= (0.0001f * PlayerPrefs.GetInt("selLVL"));
            else SpawnBombSpeed -= (0.001f * PlayerPrefs.GetInt("selLVL"));
            yield return new WaitForSeconds(SpawnBombSpeed);
        }
    }

    IEnumerator SpawnMoney()
    {
        while (!Player.lose || !PlayerLVL.lose && !Pause.isPause)
        {
            RandCoinX = new Vector2(Random.Range(-2.3f, 2.3f), 5.9f);

            Instantiate(coin, RandCoinX, Quaternion.identity);
            SpawnCoinSpeed -= 0.0001f;
            yield return new WaitForSeconds(SpawnCoinSpeed);
        }
    }

    IEnumerator SpawnMoneyLVL()
    {
        while (!PlayerLVL.lose && !Pause.isPause)
        {
            RandCoinX = new Vector2(Random.Range(-2.3f, 2.3f), 5.9f);

            Instantiate(coin, RandCoinX, Quaternion.identity);
            SpawnCoinSpeed -= 0.0001f;
            yield return new WaitForSeconds(SpawnCoinSpeed);
        }
    }
}
