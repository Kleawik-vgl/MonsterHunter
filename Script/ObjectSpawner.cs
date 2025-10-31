using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject cubePrefab; // Vật thể để "sinh" ra
    public int amountToSpawn = 100; // Số lượng cần sinh

    void Start()
    {
        // Bắt đầu đếm thời gian
        float startTime = Time.realtimeSinceStartup;

        for (int i = 0; i < amountToSpawn; i++)
        {
            // Vị trí ngẫu nhiên
            Vector3 randomPos = new Vector3(
                Random.Range(-20f, 20f), 
                Random.Range(5f, 15f), 
                Random.Range(-20f, 20f)
            );

            // Sinh ra vật thể
            Instantiate(cubePrefab, randomPos, Quaternion.identity);
        }

        // Kết thúc đếm thời gian
        float endTime = Time.realtimeSinceStartup;
        Debug.Log("Da tao " + amountToSpawn + " vat the. Thoi gian: " + (endTime - startTime) + " giay.");
    }
}