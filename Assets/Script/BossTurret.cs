using UnityEngine;

public class BossTurret : MonoBehaviour
{
    public GameObject gun;
    public TurretAmmo ammo;

    public float health = 1f;

    public bool isActive = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire(Vector2 dir)
    {
        TurretAmmo newAmmo = Instantiate(ammo, gun.transform.position, transform.rotation);
        newAmmo.pushToPlayer(dir);
    }

    public void Damage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            sr.color = Color.gray;
            isActive = false;
        }
    }
}
