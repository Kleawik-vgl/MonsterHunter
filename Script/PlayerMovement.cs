using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // --- Biến Di chuyển ---
    public float moveSpeed = 5.0f;
    private Rigidbody rb;
    private Vector3 moveInput;

    // --- Biến Nhảy ---
    public float jumpForce = 5.0f; // Lực nhảy
    private bool isGrounded = false; // Biến kiểm tra xem có đang chạm đất không

    void Start()
    {
        // Lấy component Rigidbody
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // --- INPUT DI CHUYỂN ---
        // Lấy input từ phím W/S/A/D
        float horizontal = Input.GetAxis("Horizontal"); // A/D
        float vertical = Input.GetAxis("Vertical");   // W/S

        // Tính toán hướng di chuyển
        moveInput = (transform.forward * vertical + transform.right * horizontal).normalized;

        // --- INPUT NHẢY ---
        // Nếu nhấn phím Space
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TryJump(); // Gọi hàm nhảy
        }
    }

    void FixedUpdate()
    {
        // --- UPDATE VẬT LÝ (Di chuyển) ---
        // Di chuyển cơ thể (Rigidbody)
        rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime);
    }

    // --- HÀM PUBLIC CHO NHẢY (Để Button có thể gọi) ---
    public void TryJump()
    {
        // Chỉ nhảy nếu đang trên mặt đất
        if (isGrounded)
        {
            // Thêm một lực đẩy lên (trục Y)
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    // --- KIỂM TRA CHẠM ĐẤT ---

    // Hàm này được Unity tự động gọi LIÊN TỤC khi Rigidbody đang va chạm
    // với một Collider (vật cản) khác.
    void OnCollisionStay(Collision collisionInfo)
    {
        // Khi đang chạm, chúng ta coi là "trên mặt đất"
        isGrounded = true;
    }

    // Hàm này được gọi khi Rigidbody VỪA MỚI NGỪNG va chạm
    void OnCollisionExit(Collision collisionInfo)
    {
        // Khi không còn chạm, chúng ta coi là "không trên mặt đất"
        isGrounded = false;
    }
}