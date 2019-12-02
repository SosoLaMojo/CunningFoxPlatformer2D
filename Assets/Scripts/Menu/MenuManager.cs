using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject canvasMenuPause;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (canvasMenuPause.activeSelf)
            {
                DesactivateMenuPause();
            }
            else
            {
                ActivateMenuPause();
            }
        }
    }

    public void DesactivateMenuPause()
    {
        canvasMenuPause.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void ActivateMenuPause()
    {
        canvasMenuPause.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void LoadScene (string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
