using UnityEngine;
using UnityEngine.SceneManagement;

public class FreeCamera : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float lookSpeed = 2f;

    private float yaw = 0f;
    private float pitch = 0f;
    private bool isPaused = false;

    void Update()
    {
        // Toggle pause
        if (Input.GetKeyDown(KeyCode.P))
        {
            isPaused = !isPaused;
            Time.timeScale = isPaused ? 0f : 1f;
        }

        // Reset scene
        if (Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        // Lock/unlock cursor
        if (Input.GetMouseButtonDown(1))
            Cursor.lockState = CursorLockMode.Locked;

        if (Input.GetMouseButtonUp(1))
            Cursor.lockState = CursorLockMode.None;

        // Only move/rotate if right-click is held
        if (Input.GetMouseButton(1))
        {
            // Mouse look
            yaw += lookSpeed * Input.GetAxis("Mouse X");
            pitch -= lookSpeed * Input.GetAxis("Mouse Y");
            pitch = Mathf.Clamp(pitch, -89f, 89f);
            transform.eulerAngles = new Vector3(pitch, yaw, 0);

            // Movement
            Vector3 dir = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            if (Input.GetKey(KeyCode.E)) dir.y += 1f;
            if (Input.GetKey(KeyCode.Q)) dir.y -= 1f;

            transform.Translate(dir * moveSpeed * Time.deltaTime);
        }
    }
}
