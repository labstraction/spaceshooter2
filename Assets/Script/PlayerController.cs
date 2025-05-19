using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 8f;

    private Vector2 screenBounds;
    private SpriteRenderer spriteRenderer;

    public Transform gun;
    public Ammo ammo;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalPos = Input.GetAxisRaw("Horizontal");
        float verticalPos = Input.GetAxisRaw("Vertical");

        Vector2 newPos = new Vector2(horizontalPos, verticalPos);

        transform.Translate(newPos * speed * Time.deltaTime);

        float boundX = spriteRenderer.bounds.extents.x;
        float boundY = spriteRenderer.bounds.extents.y;

        float clampX = Mathf.Clamp(transform.position.x, -screenBounds.x + boundX, screenBounds.x - boundX);
        float clampY = Mathf.Clamp(transform.position.y, -screenBounds.y + boundX, screenBounds.y - boundY);

        transform.position = new Vector2(clampX, clampY);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(ammo, gun.position, Quaternion.identity);
        }
    }

}
