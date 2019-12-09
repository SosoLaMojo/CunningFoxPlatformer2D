using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject panelMenuPause;
    [SerializeField] GameObject panelGameOver;
    [SerializeField] GameObject panelWin;
    [SerializeField] GameObject panelCredits;
    [SerializeField] GameObject panelMenuStartGame;
    [SerializeField] PlayerController playerController;

    [SerializeField] int maxEggs = 25;

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

        int playerDeath = playerController.GetPlayerLife();

        if (playerDeath <= 0.1f)
        {
            panelGameOver.gameObject.SetActive(true);
            Time.timeScale = 0;
        }

        if (playerController.GetEggScore() > maxEggs)
        {
            panelWin.gameObject.SetActive(true);
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
        Time.timeScale = 0;
    }
    public void DesactivatePanelCredits()
    {
        panelCredits.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void ActivatePanelMenuStartGame()
    {
        panelMenuStartGame.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    public void DesactivatePanelMenuStartGame()
    {
        panelMenuStartGame.gameObject.SetActive(false);
        Time.timeScale = 1;
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
