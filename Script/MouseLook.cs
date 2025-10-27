using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100.0f; // Độ nhạy của chuột
    public Transform playerBody;            // Thân của Player (chính là "Player")
    public Transform playerCamera;          // Camera (con của "Player")

    private float xRotation = 0.0f; // Góc xoay lên/xuống

    void Start()
    {
        // Gán tự động nếu bạn chưa kéo thả
        if (playerBody == null)
            playerBody = this.transform;
        
        if (playerCamera == null)
            playerCamera = Camera.main.transform;

        // Khóa chuột vào giữa màn hình
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Lấy input từ chuột
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // 1. Xoay ngang (Trái/Phải)
        // Chúng ta xoay cả thân Player (playerBody) quanh trục Y
        playerBody.Rotate(Vector3.up * mouseX);

        // 2. Xoay dọc (Lên/Xuống)
        // Tính toán góc xoay mới
        xRotation -= mouseY; 
        // Kẹp góc xoay lại để không bị "lộn cổ" (ví dụ: từ -90 đến 90 độ)
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Áp dụng góc xoay dọc cho Camera
        // Dùng localRotation để nó xoay đúng trong hệ tọa độ của Player
        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}