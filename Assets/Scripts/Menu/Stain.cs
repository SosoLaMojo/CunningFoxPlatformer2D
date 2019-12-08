using UnityEngine;
using UnityEngine.SceneManagement;

public class Stain : MonoBehaviour
{
    [SerializeField] GameObject panelEndGame;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if (panelEndGame.activeSelf)
            {
                DesactivatePanelEndGame();
            }
            else
            {
                ActivatePanelEndGame();
            }
        }
    }

    public void ActivatePanelEndGame()
    {
        panelEndGame.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void DesactivatePanelEndGame()
    {
        panelEndGame.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
