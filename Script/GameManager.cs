using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 1. Biến static để giữ thể hiện (instance) DUY NHẤT
    public static GameManager Instance { get; private set; }

    // 2. Hàm Awake() chạy trước Start()
    private void Awake()
    {
        // 3. Logic của Singleton
        if (Instance == null)
        {
            // Nếu chưa có ai là Instance, thì "tôi" (this) là Instance
            Instance = this;
            DontDestroyOnLoad(gameObject); // Giữ GameManager lại khi chuyển scene
        }
        else
        {
            // Nếu đã có Instance rồi, thì "tôi" là kẻ giả mạo -> tự hủy
            Destroy(gameObject);
        }
    }

    // 4. Các hàm public mà ai cũng có thể gọi
    public void ShowGameOverScreen()
    {
        // Sau này chúng ta sẽ bật UI, giờ chỉ Debug
        Debug.LogWarning("!!! GAME MANAGER: BAT MAN HINH GAME OVER !!!");
    }
}