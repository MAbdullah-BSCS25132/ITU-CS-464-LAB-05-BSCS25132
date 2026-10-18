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
    public float areaX = 9f;
    public float areaZ = 9f;

    int redCoinScore;          // the score at which red coin appears
    bool redCoinSpawned = false; // makes sure it spawns only once
    void Awake()
    {
        instance = this;
        restartPanel.SetActive(false); // hide panel at start
    }

    public void CoinCollected(int score)
    {
        Debug.Log("Score: " + score);
        liveScoreText.text = "Score: " + score;

        if (score >= coinsToWin)
        {
            scoreText.text = "Total Score: " + score;
            restartPanel.SetActive(true); // show panel
            Time.timeScale = 0f;          // pause the game
        }
    }
    public void RestartGame()
    {
        Time.timeScale = 1f; // un-pause the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}