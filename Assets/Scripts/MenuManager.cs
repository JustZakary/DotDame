using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public GameObject MainMenu;
    public GameObject SettingsMenu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }

    public void OpenSettings()
    {
        MainMenu.SetActive(false);
        SettingsMenu.SetActive(true);
    }

    public void CloseSettings()
    {
        MainMenu.SetActive(true);
        SettingsMenu.SetActive(false);
    }
}
