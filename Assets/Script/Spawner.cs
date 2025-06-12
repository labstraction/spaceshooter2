using UnityEngine;

public class Spawner : MonoBehaviour
{
    //private SpriteRenderer spriteRenderer;

    public Enemy enemy;
    public Enemy asteroid;

    public float generalSpawnCD = 1f;
    private float spawnCoolDown = 1f;

    public float generalAsteroidSpawnCD = 3f;
    private float asteroidSpawnCoolDown = 3f;

    Vector2 upRight = Vector2.zero;
    Vector2 downLeft = Vector2.zero;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        upRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.nearClipPlane));
        downLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));

        spawnCoolDown -= Time.deltaTime;
        asteroidSpawnCoolDown -= Time.deltaTime;
        if (spawnCoolDown <= 0)
        {
            spawnEnemy(enemy, "NormalEnemy");
        }
        if (asteroidSpawnCoolDown <= 0)
        {
            spawnEnemy(asteroid, "Asteroid");
        }
    }

    void spawnEnemy(Enemy enemyToSpawn, string CDType)
    {
        int randomDirection = Random.Range(1, 5);
        Vector2 randomPos = Vector2.zero;

        SpriteRenderer enemySprite = enemy.gameObject.GetComponent<SpriteRenderer>();
        float enemyMaxWidth = enemySprite.bounds.extents.x;
        float enemyMaxHeight = enemySprite.bounds.extents.y;
        float randX = Random.Range(downLeft.x - enemyMaxWidth, upRight.x + enemyMaxWidth);
        float randY = Random.Range(downLeft.y - enemyMaxHeight, upRight.y + enemyMaxHeight);

        if (randomDirection == 1)
        {
            float fixdY = upRight.y + enemyMaxHeight;
            randomPos = new Vector2(randX, fixdY);
        }
        if (randomDirection == 2)
        {
            float fixdX = upRight.x + enemyMaxWidth;
            randomPos = new Vector2(fixdX, randY);
        }
        if (randomDirection == 3)
        {
            float fixdY = downLeft.y - enemyMaxHeight;
            randomPos = new Vector2(randX, fixdY + enemyMaxHeight);
        }
        if (randomDirection == 4)
        {
            float fixdX = downLeft.x - enemyMaxWidth;
            randomPos = new Vector2(fixdX, randY);
        }

        Instantiate(enemyToSpawn, randomPos, Quaternion.identity);

        switch (CDType)
        {
            case "NormalEnemy":
                spawnCoolDown = generalSpawnCD;
                break;
            case "Asteroid":
                asteroidSpawnCoolDown = generalAsteroidSpawnCD;
                break;
            default:
                break;
        }
    }
}
