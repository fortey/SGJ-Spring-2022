using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _bgName;
    [SerializeField] private GameObject _credits;

    public void StartGame()
    {
        SceneManager.LoadScene("fortey");
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void credits()
    {
        _credits.SetActive(true);
    }
   
    public void Start()
    {
        _credits.SetActive(false);
    }


    private void Update()
    {
        if (Input.anyKeyDown)
        {
            _credits.SetActive(false);
        }
        if (Input.anyKeyDown)
        {
            _bgName.SetActive(false);
        }


        if (Input.GetKey("escape"))
        {
                Application.Quit();
        }
        
    }
}
