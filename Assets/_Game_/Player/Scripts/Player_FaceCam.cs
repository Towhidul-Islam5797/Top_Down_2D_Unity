using UnityEngine;

public class FaceMouse : MonoBehaviour
{
    public float rotationSpeed = 10f;
    private Vector3 cachedMousePosition;
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        // Cache mouse position each frame
        cachedMousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        cachedMousePosition.z = 0;
    }

    void FixedUpdate()
    {
        // Compute target direction
        Vector3 direction = (cachedMousePosition - transform.position).normalized;
        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(0, 0, targetAngle);

        // Smoothly interpolate rotation
        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            targetRotation,
            rotationSpeed * Time.fixedDeltaTime
        );
    }
}
