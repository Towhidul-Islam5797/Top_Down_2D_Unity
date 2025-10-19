using System;
using UnityEngine;

public class BarrelToMouse : MonoBehaviour
{
    public Transform player; // The object to attach to the player center (pivot)
    public float length = 1.0f; // Distance from character center to barrel/gun end

    private Vector3 mouseWorldPosition; // Where the mouse is pointing

    void Update()
    {
        Get_Cache();
    }

    void FixedUpdate()
    {
        Find_Rotation_Logic();
    }

    private void Find_Rotation_Logic()
    {
        // Always start at player center (pivot)
        transform.position = player.position;

        // Calculate direction vector from player center to mouse pointer
        Vector3 direction = mouseWorldPosition - transform.position;
        if (direction.sqrMagnitude > 0.001f)
        {
            // Find rotation angle
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(0, 0, angle);

            // Smoothly rotate object to face mouse
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.fixedDeltaTime * 10f);

            // To keep the barrel/gun tip at a fixed length:
            Vector3 tipPosition = player.position + direction.normalized * length;
            // You can use tipPosition for a line, spawn position, etc.
            // Example: Draw a debug line (optional)
            Debug.DrawLine(player.position, tipPosition, Color.red);
        }
    }
    private void Get_Cache()
    {
        // Cache mouse position in Update for responsive aiming
        Vector3 mouseScreenPosition = Input.mousePosition;
        mouseScreenPosition.z = -Camera.main.transform.position.z; // Z for 2D, match to camera
        mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
        mouseWorldPosition.z = 0f;
    }
}
