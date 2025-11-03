using UnityEngine;

public class PlayerHealth : BaseCharacter // Kế thừa từ BaseCharacter
{
    // Chúng ta không cần hàm Start(), vì nó tự động gọi hàm Start() của class cha

    // "override": Báo cho Unity biết chúng ta "viết đè" hàm Die() của cha
    protected override void Die()
{
    Debug.Log("GAME OVER");
    GetComponent<PlayerMovement>().enabled = false;
    GetComponent<MouseLook>().enabled = false;

    // --- DÒNG MỚI ---
    // Vì GameManager là Singleton, chúng ta có thể gọi nó trực tiếp từ bất cứ đâu
    GameManager.Instance.ShowGameOverScreen();
}
}