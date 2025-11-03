using UnityEngine;

// Đây là "bản thiết kế" chung cho mọi nhân vật có máu
public class BaseCharacter : MonoBehaviour
{
    public int maxHP = 100;
    public int currentHP;

    // protected virtual void Start() 
    // "protected": chỉ class này và class con (Player, Enemy) thấy hàm này
    // "virtual": cho phép class con "viết đè" (override) hàm này
    protected virtual void Start()
    {
        currentHP = maxHP;
    }

    // Hàm nhận sát thương
    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        if (currentHP <= 0)
        {
            currentHP = 0;
            Die(); // Gọi hàm Die() khi hết máu
        }
    }

    // Hàm Chết (virtual để con có thể viết đè)
    protected virtual void Die()
    {
        // Hành vi chết MẶC ĐỊNH là tự hủy object
        Debug.Log(gameObject.name + " died.");
        Destroy(gameObject);
    }
}