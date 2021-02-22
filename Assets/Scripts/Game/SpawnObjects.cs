using UnityEngine;
using System.Collections;

public class SpawnObjects : MonoBehaviour
{
    public GameObject coin, bomb;

    private float SpawnBombSpeed = 1f, SpawnCoinSpeed = 1f, delta;

    private Vector2 RandBombX, RandCoinX, randVector;

    private void Start()
    {
        if (!LoadLevels.isLevels)
        {
            StartCoroutine(SpawnForArcade());
        }
        else
        {
            StartCoroutine(SpawnForLevels());
        }
    }

    IEnumerator SpawnForArcade()
    {
        while (!Player.lose && !Pause.isPause)
        {
            RandBombX = new Vector2(Random.Range(-2.3f, 2.3f), 5.9f);

            RandCoinX = new Vector2(Random.Range(-2.3f, 2.3f), 5.9f);

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

            if (RandBombX == RandCoinX || delta <= 0.3f)
            {
                randVector = new Vector2(Random.Range(-2.3f, 2.3f), 5.9f);

                Instantiate(bomb, randVector, Quaternion.identity);

                if (delta <= 0.3f)
                {
                    randVector = new Vector2(Random.Range(-2.3f, 2.3f), 5.9f);

                    Instantiate(coin, randVector, Quaternion.identity);
                }
            }
            else
            {
                Instantiate(bomb, RandBombX, Quaternion.identity);

                Instantiate(coin, RandCoinX, Quaternion.identity);
            }

            yield return new WaitForSeconds(SpawnBombSpeed);
        }
    }

    IEnumerator SpawnForLevels()
    {
        while (!PlayerLVL.lose && !Pause.isPause)
        {
            RandBombX = new Vector2(Random.Range(-2.3f, 2.3f), 5.9f);

            RandCoinX = new Vector2(Random.Range(-2.3f, 2.3f), 5.9f);

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

            if (RandBombX == RandCoinX || delta <= 0.3f)
            {
                randVector = new Vector2(Random.Range(-2.3f, 2.3f), 5.9f);

                Instantiate(bomb, randVector, Quaternion.identity);

                if (delta <= 0.3f)
                {
                    randVector = new Vector2(Random.Range(-2.3f, 2.3f), 5.9f);

                    Instantiate(coin, randVector, Quaternion.identity);
                }
            }
            else
            {
                Instantiate(bomb, RandBombX, Quaternion.identity);

                Instantiate(coin, RandCoinX, Quaternion.identity);
            }

            

            yield return new WaitForSeconds(SpawnBombSpeed);
        }
    }
}