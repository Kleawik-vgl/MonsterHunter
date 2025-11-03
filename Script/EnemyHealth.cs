using UnityEngine;

public class EnemyHealth : BaseCharacter // Kế thừa từ BaseCharacter
{
    // Chúng ta không cần viết gì cả!
    // Nó sẽ tự động dùng hàm Start() và Die() của class cha (BaseCharacter)
    // Khi nó Die(), nó sẽ tự Destroy(gameObject)
}