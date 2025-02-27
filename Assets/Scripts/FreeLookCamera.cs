using UnityEngine;

public class FreeLookCamera : MonoBehaviour
{
    public float mouseSensitivity = 100f; // Sensitivity for camera rotation
    public Transform player; // Reference to the player object

    private float xRotation = 0f;

    void Start()
    {
        // Lock and hide the cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Only rotate the camera when the right mouse button is held
        if (Input.GetMouseButton(1)) // Right mouse button
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            // Rotate the player horizontally
            player.Rotate(Vector3.up * mouseX);

            // Rotate the camera vertically
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Limit vertical rotation
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        }
    }
}