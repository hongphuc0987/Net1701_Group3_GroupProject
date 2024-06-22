using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private UnityEngine.Vector2 respawnPoint;

    void Start()
    {
        // Thiết lập điểm hồi sinh mặc định
        respawnPoint = transform.position;
    }

    // Hàm để thiết lập điểm hồi sinh mới
    public void SetRespawnPoint(UnityEngine.Vector2 newRespawnPoint)
    {
        respawnPoint = newRespawnPoint;
    }

    // Hàm để hồi sinh
    public void Respawn()
    {
        transform.position = respawnPoint;
    }

    // Giả sử bạn có hàm này để xử lý việc chết của Player
    public void Die()
    {
        // Gọi hàm Respawn khi chết
        Respawn();
    }

    // Ví dụ: Khi Player va chạm với vật thể gây chết
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Respawn"))
        {
            Die();
        }
    }
}
