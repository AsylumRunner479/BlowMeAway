using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallManager : MonoBehaviour
{
    public float maxHealth, curHealth, repair, material;
    
    public GameObject self;
    public bool collapse = false;
    public Salvage rubbish;
    public Slider HealthBar;
    public Score score;
    public AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 300;
        curHealth = maxHealth;
        repair = 0;

    }

    
    // Update is called once per frame
    void Update()
    {
        
        if (HealthBar.value != curHealth/maxHealth)
        {
            HealthBar.value = curHealth;
            Score.CurWalls += curHealth;
            Score.MaxWalls += curHealth;
        }
        if(curHealth <= 0f && rubbish.cost == 0f)
        {

            audio.Play();
            collapse = true;
            
            rubbish.cost = maxHealth;
            rubbish.loot = true;

        }
        
        if(curHealth >= maxHealth)
        {
            collapse = false;
            material -= 300;
            

        }

    }
}
