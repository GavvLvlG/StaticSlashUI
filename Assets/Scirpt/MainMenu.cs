using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject creditsMenu;

    // Start is called before the first frame update
    void Start()
    {
        MainMenuButton();
    }

    public void PlayNowButton()
    {
        // Play Now Button has been pressed, here you can initialize your game (For example Load a Scene called GameLevel etc.)
        SceneManager.LoadScene("GamePlayUI");
    }

    public void CreditsButton()
    {
        // Show Credits Menu
        if (mainMenu == null || creditsMenu == null)
        {
            Debug.LogWarning("MainMenu or CreditsMenu references are not assigned in the inspector.");
            return;
        }

        mainMenu.SetActive(false);
        creditsMenu.SetActive(true);
    }

    public void MainMenuButton()
    {
        // Show Main Menu
        if (mainMenu == null || creditsMenu == null)
        {
            Debug.LogWarning("MainMenu or CreditsMenu references are not assigned in the inspector.");
            return;
        }

        mainMenu.SetActive(true);
        creditsMenu.SetActive(false);
    }

    public void QuitButton()
    {
        // Quit Game. In the editor stop play mode.
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
