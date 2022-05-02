using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _bgName;
    public void StartGame()
    {
        SceneManager.LoadScene("fortey");
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            _bgName.SetActive(false);
        }
    }
}
