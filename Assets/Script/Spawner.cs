using UnityEngine;

public class Spawner : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public Enemy enemy;

    public float generalSpawnCD = 1f;
    private float spawnCoolDown = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float maxWidth = spriteRenderer.bounds.extents.x;
        float minWidth = -maxWidth;

        float randomX = Random.Range(minWidth, maxWidth);

        spawnCoolDown -= Time.deltaTime;
        if (spawnCoolDown <= 0)
        {
            Instantiate(enemy, new Vector2(randomX, transform.position.y), Quaternion.identity);
            spawnCoolDown = generalSpawnCD;
        }
    }
}
