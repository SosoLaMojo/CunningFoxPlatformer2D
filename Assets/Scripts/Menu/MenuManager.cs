using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject panelMenuPause;
    [SerializeField] GameObject panelGameOver;
    [SerializeField] GameObject panelCredits;
    [SerializeField] PlayerController playerController;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (panelMenuPause.activeSelf)
            {
                DesactivateMenuPause();
            }
            else
            {
                ActivateMenuPause();
            }
        }

        if (playerController.GetPlayerLife() <= 0)
        {
            panelGameOver.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void DesactivateMenuPause()
    {
        panelMenuPause.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void ActivateMenuPause()
    {
        panelMenuPause.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void ActivatePanelCredits()
    {
        panelCredits.gameObject.SetActive(true);
    }
    public void DesactivatePanelCredits()
    {
        panelCredits.gameObject.SetActive(false);
    }

    public void LoadScene (string sceneName)
    {   
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
