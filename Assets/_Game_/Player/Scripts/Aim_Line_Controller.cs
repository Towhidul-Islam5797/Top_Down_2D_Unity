using UnityEngine;

public class AimLineController : MonoBehaviour
{
    // Usefull variables
    public Transform player;
    private LineRenderer lineRenderer;
    private Vector3 mouseWorldPosition;

    void Awake()
    {
        //While awake Line Renderer will Call the Get Component
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        Cache_Mouse_Data();
    }

    void FixedUpdate()
    {
        Rotate_Object();
    }

    private void Rotate_Object()
    {
        Vector3 playerPos2D = player.position;
        playerPos2D.z = 0f;

        // 0 means the starting point which is pointed to player 2d position & 1 mean end point which is connected to the mouse point
        lineRenderer.SetPosition(0, playerPos2D);
        lineRenderer.SetPosition(1, mouseWorldPosition);


        // Calculate direction
        Vector3 direction = mouseWorldPosition - transform.position;

        if (direction.sqrMagnitude > 0.001f)
        {
            // Gets the angle (in degrees) of the direction vector from your object to the mouse
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Makes a rotation that points along that angle, using Z-axis rotation (which is typical for 2D objects)
            Quaternion targetRotation = Quaternion.Euler(0, 0, angle);

            // Smoothly rotates your object toward the target angle, so it doesn't snap instantly. You can change '10f' for faster/slower rotation.
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.fixedDeltaTime * 10f); 
        }
    }

    private void Cache_Mouse_Data()
    {
        // Get mouse position and set Z to 0 to match 2D world plane!
        Vector3 mouseScreenPosition = Input.mousePosition;
        mouseScreenPosition.z = 0f; // Not strictly needed for orthographic cam but good habit

        // Convert to world point
        mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);

        // Force Z = 0 for 2D
        mouseWorldPosition.z = 0f;
    }
}

