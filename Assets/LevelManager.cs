using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void Tutorial() {
        SceneManager.LoadScene("Tutorial");
    }
    public void MainMenu() {
        SceneManager.LoadScene("Main_Menu");
    }
 
    public void LoadnextScene() {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    public void Quit() {
        Application.Quit();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            ResetScene();
    }
}
