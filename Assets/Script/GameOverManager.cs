using TMPro;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TMP_Text scoreText;
    private ScoreManager sm;
    void Start()
    {
        sm = FindFirstObjectByType<ScoreManager>();
        scoreText.text = "Score: " + sm.score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
