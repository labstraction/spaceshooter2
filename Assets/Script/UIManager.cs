using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TMP_Text scoreText;

    public Image CurrentHPBar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText.text = PlayerPrefs.GetInt("MaxScore", 0) + "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void getScore(int newScore)
    {
        scoreText.text = "Score: " + newScore;
        PlayerPrefs.SetInt("MaxScore", newScore);
    }

    public void updateHPBar(float perc)
    {
        CurrentHPBar.fillAmount = perc;

        if (perc <= 0.2f)
        {
            CurrentHPBar.color = Color.red;
        }
        else if (perc <= 0.5f)
        {
            CurrentHPBar.color = Color.yellow;
        }
        else
        {
            CurrentHPBar.color = Color.green;
        }
    }
}
