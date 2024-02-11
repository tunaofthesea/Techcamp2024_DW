using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public Image mainmenu;
    public Image optionsmenu;
    public GameObject room;
    public float rotationSpeed;

    private void Update()
    {
        //room.transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

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
