using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{

    [SerializeField] Canvas reticleRef;
    [SerializeField] Canvas gameOverScreenRef;

    
    public void GameOver()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
        reticleRef.gameObject.SetActive(false);
        gameOverScreenRef.gameObject.SetActive(true);
    }

    public void ReloadScene()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        reticleRef.gameObject.SetActive(true);
        gameOverScreenRef.gameObject.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
