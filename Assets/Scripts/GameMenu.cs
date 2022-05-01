using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private GameObject _WinLosePanel;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ShowClosePanel(!_panel.activeSelf);
        }
    }

    public void ShowClosePanel(bool show)
    {
        _panel.SetActive(show);

        Time.timeScale = show ? 0f : 1f;
    }


    public void Restart()
    {
        ShowClosePanel(false);
        SceneManager.LoadScene("fortey");
    }

    public void MainMenu()
    {
        ShowClosePanel(false);
        SceneManager.LoadScene("Main menu");
    }

    public void ShowWinLose()
    {
        _WinLosePanel.SetActive(true);
        Time.timeScale = 0f;
    }
}
