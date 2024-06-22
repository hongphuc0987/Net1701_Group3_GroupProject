using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f; // Dừng thời gian khi tạm dừng game
    }

    public void Home()
    {
        Time.timeScale = 1f; // Đảm bảo thời gian trở lại bình thường trước khi load cảnh mới
        SceneManager.LoadScene(0); // Load cảnh với index 0 (màn hình chính hoặc màn hình menu)
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f; // Đảm bảo thời gian trở lại bình thường khi tiếp tục chơi
    }

    public void Restart()
    {
        Time.timeScale = 1f; // Đảm bảo thời gian trở lại bình thường trước khi load lại cảnh
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
