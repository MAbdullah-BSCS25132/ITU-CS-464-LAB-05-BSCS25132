using UnityEngine;
using System.Collections;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public int coinCount = 20;
    public float spawnDelay = 1.5f; // seconds between each coin
    public float areaX = 9f;
    public float areaZ = 9f;

    void Start()
    {
        StartCoroutine(SpawnCoins());
    }

    IEnumerator SpawnCoins()
    {
        for (int i = 0; i < coinCount; i++)
        {
            Vector3 pos = new Vector3(
                Random.Range(-areaX, areaX),
                0.5f,
                Random.Range(-areaZ, areaZ)
            );

            Instantiate(coinPrefab, pos, coinPrefab.transform.rotation);

            yield return new WaitForSeconds(spawnDelay); // wait, then continue
        }
    }
}