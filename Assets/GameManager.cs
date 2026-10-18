using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject restartPanel;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI liveScoreText;
    public int coinsToWin = 20;
    public GameObject redCoinPrefab;
    public GameObject blueCoinPrefab;
    public int blueCoinCount = 50;
    public float blueSpawnRadius = 6f; // how far from the ball coins can appear
    public TextMeshProUGUI bonusText;
    int bonusCollected = 0;
    public float areaX = 9f;
    public float areaZ = 9f;

    int redCoinScore;          // the score at which red coin appears
    bool redCoinSpawned = false; // makes sure it spawns only once
    void Awake()
    {
        instance = this;
        restartPanel.SetActive(false); // hide panel at start
        redCoinScore = Random.Range(1, 11); // gives a number from 1 to 10
    }

    public void CoinCollected(int score)
    {
        Debug.Log("Score: " + score);
        liveScoreText.text = "Score: " + score;
        if (!redCoinSpawned && score == redCoinScore)
        {
            SpawnRedCoin();
        }
        if (score >= coinsToWin)
        {
            scoreText.text = "Total Score: " + score;
            restartPanel.SetActive(true); // show panel
            Time.timeScale = 0f;          // pause the game
        }
    }
    void SpawnRedCoin()
    {
        redCoinSpawned = true;

        Vector3 pos = new Vector3(
            Random.Range(-areaX, areaX),
            0.5f,
            Random.Range(-areaZ, areaZ)
        );

        Instantiate(redCoinPrefab, pos, redCoinPrefab.transform.rotation);
        Debug.Log("Red coin spawned at score " + redCoinScore);
    }
    public void SpawnBlueCoins(Vector3 center)
    {
        bonusCollected = 0;
        bonusText.gameObject.SetActive(true); // show the hidden text
        bonusText.text = "BonusCoins: 0/" + blueCoinCount;
        for (int i = 0; i < blueCoinCount; i++)
        {
            // pick a random direction on a circle, and a random distance from the ball
            Vector2 dir = Random.insideUnitCircle.normalized;
            float distance = Random.Range(2f, blueSpawnRadius);

            float x = Mathf.Clamp(center.x + dir.x * distance, -areaX, areaX);
            float z = Mathf.Clamp(center.z + dir.y * distance, -areaZ, areaZ);

            Vector3 pos = new Vector3(x, 0.5f, z);
            Instantiate(blueCoinPrefab, pos, blueCoinPrefab.transform.rotation);
        }
    }
    public void BlueCoinCollected()
    {
        bonusCollected++;
        bonusText.text = "BonusCoins: " + bonusCollected + "/" + blueCoinCount;
    }
    public void RestartGame()
    {
        Time.timeScale = 1f; // un-pause the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}