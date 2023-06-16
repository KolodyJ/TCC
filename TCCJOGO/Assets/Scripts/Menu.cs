using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Menu : MonoBehaviour
{
    
    public string cena;

    public GameObject optionsPanel;
    public GameObject menuPanel;
    public GameObject selectionPanel;
    // Start is called before the first frame update
    void Start()
    {
          
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        selectionPanel.SetActive(true);
        optionsPanel.SetActive(false);
        menuPanel.SetActive(false);
    }

    public void LevelOne()
    {
        SceneManager.LoadScene("Fase 1");
        MusicManager.mManager.PlaySound(1);
    }

    public void QuitGame()
    {
        //Editor Unity
        //UnityEditor.EditorApplication.isPlaying = false;
        //Jogo Compilado
        Application.Quit();
    }

    public void ShowOptions()
    {
        optionsPanel.SetActive(true);
        menuPanel.SetActive(false);
        selectionPanel.SetActive(false);
    }

    public void BackToMenu()
    {
        optionsPanel.SetActive(false);
        menuPanel.SetActive(true);
        selectionPanel.SetActive(false);
    }

    List<int> widths = new List<int>() {640, 1024, 1280, 1366, 1600, 1920};
    List<int> heights = new List<int>() {450, 768, 720, 768, 900, 1080};

    public void SetScreenSize (int index)
    {
        bool fullScreen = Screen.fullScreen;
        int width = widths[index];
        int height = heights[index];
        Screen.SetResolution(width, height, fullScreen);
    }
}
