using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    void Awake()
    {
        instance = this;
    }

    public void CoinCollected(int score)
    {
        Debug.Log("Score: " + score);
    }
}