using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth = 100f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            GameManager manager = FindFirstObjectByType<GameManager>();
            manager.startGameOver();
        }
    }

    public void takeDamage(float damage)
    {
        currentHealth -= damage;
        GameManager manager = FindFirstObjectByType<GameManager>();
        manager.getHPPerc(maxHealth, currentHealth);
    }
}
