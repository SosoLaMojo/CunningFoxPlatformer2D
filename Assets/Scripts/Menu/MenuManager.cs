using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject panelMenuPause;
    [SerializeField] private GameObject panelGameOver;
    [SerializeField] private GameObject panelWin;
    [SerializeField] private GameObject panelCredits;
    [SerializeField] private GameObject panelMenuStartGame;
    [SerializeField] private PlayerController playerController;

    [SerializeField] private int maxEggs = 25;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
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

        if (playerDeath <= 0.1f) //TODO float comparaison with an int
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
