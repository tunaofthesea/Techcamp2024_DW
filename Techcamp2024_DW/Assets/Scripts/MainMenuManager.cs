using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public Image mainmenu;
    public Image optionsmenu;

    public void StartGame()
    {
        SceneManager.LoadScene("Simulator");
    }

    public void Options()
    {
        mainmenu.gameObject.SetActive(!mainmenu.gameObject.activeSelf);
        optionsmenu.gameObject.SetActive(!optionsmenu.gameObject.activeSelf);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
