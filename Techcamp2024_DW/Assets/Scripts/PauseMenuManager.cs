using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    public GameObject pausemenu;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }
    }

    public void TogglePauseMenu()
    {
        if (pausemenu != null)
        {
            pausemenu.SetActive(!pausemenu.activeSelf);

            Time.timeScale = (pausemenu.activeSelf) ? 0f : 1f;
        }
    }

    public void ExitLevel()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("MainMenu");
    }

}
