using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager1 : MonoBehaviour
{
    public static Manager1 mg;
    public GameObject pauseMenu;
    public GameObject gameOver; 
    public GameObject endGame; 
    public Text coinsText;
    public int coins;
    public string cena;
    private bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            PauseScreen();
        }
    }
    void PauseScreen(){
        if (isPaused)
        {
            Time.timeScale = 1f;
            isPaused = false;
            pauseMenu.SetActive(false);
        }
        else{
            Time.timeScale = 0f;
            isPaused = true;
            pauseMenu.SetActive(true);
        }

    }
    
    public void QuitGame()
    {
        //Editor Unity
        //UnityEditor.EditorApplication.isPlaying = false;
        //Jogo Compilado
        Application.Quit();
    }

    public void ReturnMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
        
    }

    public void LoadScenes(string cena)
    {
        SceneManager.LoadScene(cena);
        
    }
    
    public void GameOver()
    {
        pauseMenu.SetActive(true);
    }

    public void EndGame()
    {
        endGame.SetActive(true);
    }

    void Awake() 
    {
        if (mg == null)
        {
            mg = this;
        }   
        else if (mg != this)
        {
            Destroy(gameObject);
        }
    }

}
