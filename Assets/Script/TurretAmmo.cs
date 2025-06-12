using UnityEngine;

public class TurretAmmo : Ammo
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    new void Start()
    {
        
    }

    // Update is called once per frame
    new void Update()
    {
        lifespan -= Time.deltaTime;
        if (lifespan <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void pushToPlayer(Vector2 dir)
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(dir * speed, ForceMode2D.Impulse);
    }

    new void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerStats ps = collision.gameObject.GetComponent<PlayerStats>();
            ps.takeDamage(damage);
            Destroy(gameObject);
        }
    }
}
