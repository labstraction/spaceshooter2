using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 4f;
    public float hitPoints = 1f;

    public SpriteRenderer spriteRenderer;
    
    private GameManager manager;

    public Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        manager = FindFirstObjectByType<GameManager>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    protected void Update()
    {
        Vector2 moveDirection = Vector2.MoveTowards(transform.position, manager.player.transform.position , speed * Time.deltaTime);
        Vector2 distance = manager.player.transform.position - transform.position;
        float angle = Mathf.Atan2(distance.x, distance.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, -angle);
        transform.position = moveDirection;

        if (hitPoints <= 0)
        {
            OnDeath();
        }
    }

    public void getDamage(float damage)
    {
        hitPoints -= damage;
    }

    public void OnDeath()
    {
        manager.addScore(100);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerStats ps = collision.gameObject.GetComponent<PlayerStats>();
            ps.takeDamage(5f);
            Destroy(gameObject);
        }
    }
}
