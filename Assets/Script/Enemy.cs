using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 4f;
    public float hitPoints = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        if (hitPoints <= 0)
        {
            OnDeath();
        }
    }

    public void getDamage(float damage)
    {
        hitPoints -= damage;
    }

    void OnDeath()
    {
        Destroy(gameObject);
    }
}
