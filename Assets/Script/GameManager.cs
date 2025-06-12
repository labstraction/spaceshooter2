using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;

    private UIManager UImanager;

    private int playerScore = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindFirstObjectByType<PlayerController>().gameObject;
        UImanager = FindFirstObjectByType<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        UImanager.getScore(playerScore);
        ScoreManager scoreManager = FindFirstObjectByType<ScoreManager>();
        scoreManager.score = playerScore;
    }

    public void getHPPerc(float maxHP, float currentHP)
    {
        float perc = currentHP / maxHP;
        UImanager.updateHPBar(perc);
    }

    public void startGameOver()
    {
        SceneManager.LoadScene(1);
    }
}
