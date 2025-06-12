using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float speed = 0.125f;
    public Vector3 offset = new Vector3(0, 0, -10);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (player != null)
        {
            Vector3 destination = player.position + offset;
            Vector3 cameraMove = Vector3.Lerp(transform.position, destination, speed);
            transform.position = cameraMove;    
        }
    }
}
