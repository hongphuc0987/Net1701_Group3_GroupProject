using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 3f; // Tốc độ di chuyển của kẻ thù
    public float moveRange = 5f; // Khoảng cách tối đa kẻ thù có thể di chuyển

    private Vector3 startPosition;
    private float leftBoundary; // Biên trái của phạm vi di chuyển
    private float rightBoundary; // Biên phải của phạm vi di chuyển
    private bool movingRight = true;

    void Start()
    {
        startPosition = transform.position;
        leftBoundary = startPosition.x - moveRange / 2f;
        rightBoundary = startPosition.x + moveRange / 2f;
    }

    void Update()
    {
        // Di chuyển qua lại giữa hai biên của phạm vi
        if (transform.position.x >= rightBoundary)
        {
            movingRight = false;
        }
        else if (transform.position.x <= leftBoundary)
        {
            movingRight = true;
        }

        // Xác định hướng di chuyển
        Vector3 movementDirection = (movingRight ? Vector3.right : Vector3.left);

        // Áp dụng di chuyển
        transform.Translate(movementDirection * speed * Time.deltaTime);

        // Giữ kẻ thù ở cùng một vị trí trên trục Y
        transform.position = new Vector3(transform.position.x, startPosition.y, transform.position.z);
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Cập nhật vị trí của enemy bằng vị trí của player
            transform.position = collision.transform.position;
        }
    }
}
