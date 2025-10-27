using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Tốc độ di chuyển
    private Rigidbody rb;
    private Vector3 moveInput;

    void Start()
    {
        // Lấy component Rigidbody
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // 1. Nhận Input (Input) - nên làm trong Update
        // Lấy input từ phím A/D (trục ngang)
        float horizontalInput = Input.GetAxis("Horizontal"); 
        // Lấy input từ phím W/S (trục dọc)
        float verticalInput = Input.GetAxis("Vertical");

        // Tính toán vector di chuyển
        // transform.forward là vector chỉ hướng "trước mặt" của player
        // transform.right là vector chỉ hướng "bên phải" của player
        moveInput = (transform.forward * verticalInput + transform.right * horizontalInput).normalized;
    }

    void FixedUpdate()
    {
        // 2. Cập nhật Logic/Vật lý (Update) - nên làm trong FixedUpdate
        // Di chuyển Rigidbody.
        // Chúng ta dùng rb.MovePosition để di chuyển mượt mà và đúng vật lý.
        // Time.fixedDeltaTime là thời gian giữa mỗi lần gọi FixedUpdate,
        // đảm bảo tốc độ di chuyển nhất quán trên mọi máy tính.
        rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime);
    }
}