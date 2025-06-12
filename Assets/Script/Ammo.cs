using UnityEngine;

public class Ammo : MonoBehaviour
{
    public float speed = 10f;

    public float lifespan = 1f;

    public float damage = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected void Start()
    {
        
    }

    // Update is called once per frame
    protected void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        lifespan -= Time.deltaTime;
        if (lifespan <= 0)
        {
            Destroy(gameObject);
        }
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Hazard")
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.getDamage(damage);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "BossTurret")
        {
            Debug.Log("Colpito");
            BossTurret bt = collision.gameObject.GetComponent<BossTurret>();
            bt.Damage(damage);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "SpaceStation")
        {
            SpaceStationBoss spb = collision.gameObject.GetComponent<SpaceStationBoss>();
            spb.Damage(damage);
            Destroy(gameObject);
        }
    }
}
