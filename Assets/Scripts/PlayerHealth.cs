using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3; // Số hình trái tim tối đa
    private int currentHealth; // Số hình trái tim hiện tại

    public Image[] heartImages; // Mảng để lưu trữ các UI Image của trái tim
    public Sprite heartFullSprite; // Biến để lưu trữ sprite của hình trái tim đầy

    private Vector3 startPosition; // Vị trí bắt đầu của người chơi

    void Start()
    {
        currentHealth = maxHealth; // Khởi tạo số lượng hình trái tim ban đầu
        startPosition = transform.position; // Lưu lại vị trí bắt đầu của người chơi
        UpdateHealthUI(); // Cập nhật giao diện trái tim ban đầu
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(); // Gọi hàm TakeDamage khi va chạm với enemy
        }
    }

    void TakeDamage()
    {
        currentHealth--; // Giảm số hình trái tim
        UpdateHealthUI(); // Cập nhật giao diện trái tim sau khi mất hình trái tim

        if (currentHealth <= 0)
        {
            // Nếu hết hình trái tim, gọi hàm RestartGame để khởi động lại trò chơi
            RestartGame();
        }
        else
        {
            // Nếu còn hình trái tim, đưa người chơi về vị trí bắt đầu
            transform.position = startPosition;
        }
    }

    void UpdateHealthUI()
    {
        // Cập nhật trạng thái hình ảnh trái tim dựa trên số hình trái tim còn lại
        for (int i = 0; i < heartImages.Length; i++)
        {
            if (i < currentHealth)
            {
                // Nếu vị trí i nhỏ hơn số hình trái tim còn lại, hiển thị hình trái tim đầy
                heartImages[i].sprite = heartFullSprite;
                heartImages[i].gameObject.SetActive(true); // Hiển thị UI Image
            }
            else
            {
                // Ngược lại, ẩn UI Image
                heartImages[i].gameObject.SetActive(false);
            }
        }
    }

    void RestartGame()
    {
        // Khởi động lại trò chơi bằng cách load lại cảnh hiện tại
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
