using UnityEngine;

public class DamageTester : MonoBehaviour
{
    public Transform enemyToAttack; // Kéo Enemy vào đây

    void Update()
    {
        // Nhấn F để đánh Enemy
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (enemyToAttack != null)
            {
                // Lấy script EnemyHealth và gọi hàm TakeDamage
                enemyToAttack.GetComponent<EnemyHealth>().TakeDamage(25);
            }
        }

        // Nhấn G để tự sát (test Player die)
        if (Input.GetKeyDown(KeyCode.G))
        {
            // Lấy script PlayerHealth của chính mình và gọi TakeDamage
            GetComponent<PlayerHealth>().TakeDamage(30);
        }
    }
}