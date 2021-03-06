﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{



    public void Start()
    {
        isPaused = true;
        TogglePause();
    }
    public bool gameEnded = false;
    public bool isPaused = false;
    public GameObject _pauseMenu;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
        if (PlayerHandler.isDead == true)
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None; // lock the mouse cursor
            Cursor.visible = true;
            _pauseMenu.SetActive(true);
            isPaused = true;
        }
    }
    public void TogglePause()
    {
        if (isPaused)
        {
            Time.timeScale = 1;
            _pauseMenu.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked; // lock the mouse cursor
            Cursor.visible = false;
            isPaused = false;
            return;

        }
        else
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None; // lock the mouse cursor
            Cursor.visible = true;
            _pauseMenu.SetActive(true);
            isPaused = true;
            return;
        }
    }

    public void GameOver()
    {
        gameEnded = true;
    }

    //Reloads the Current Level
    
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PlayerHandler.isDead = false;
        Time.timeScale = 1;
        _pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.None; // lock the mouse cursor
        Cursor.visible = false;
        isPaused = false;

    }
    //
    //create a function to move to next scene by loading the activeScene +1
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
       
        isPaused = true;
        TogglePause();
    }
    //create a function to move to previous scene by loading the activeScene - 1
    public void PrevLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    //create a function to load a scene by loading the activeScene of the levelID int
    public void SwitchLevel(int levelID)
    {
        SceneManager.LoadScene(levelID);
    }
    //create a function to quite the game by unityEditor isPlaying false and calling a inbuilt function to make the application quit
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
    
   

}