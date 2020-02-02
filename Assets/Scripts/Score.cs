using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Score : MonoBehaviour
{
    public float Timer, MaxWalls, CurWalls, GoalWalls;
    public GameManager manager;
    public GameObject _scoreMenu, _restart, _nextLevel;
    // Start is called before the first frame update
    void Start()
    {
        CurWalls = MaxWalls;
            
    }

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer <= 0)

        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None; // lock the mouse cursor
            Cursor.visible = true;
            _scoreMenu.SetActive(true);
        }
        if (CurWalls <= GoalWalls && Timer <= 0)
        {
            _restart.SetActive(true);
        }
        else if (CurWalls >= GoalWalls)
                {
            _nextLevel.SetActive(true);
        }

    }
}
