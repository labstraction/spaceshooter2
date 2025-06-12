using Unity.Mathematics;
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

        transform.Translate(newPos * speed * Time.deltaTime, Space.World);

        if (horizontalPos != 0 || verticalPos != 0)
        {
            float angle = Mathf.Atan2(newPos.x, newPos.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, -angle);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(ammo, gun.position, transform.rotation);
        }
    }

}
