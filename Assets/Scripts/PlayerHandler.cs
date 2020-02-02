using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHandler : MonoBehaviour
{
    public static bool isDead = false;
    public float curHealth, maxHealth;
    public float curStamina, maxStamina;
    public Slider healthBar;
    public Slider staminaBar;
    public GameObject hand;
    public GameManager manage;
    
    private void Start()
    {
        maxHealth = 100f;
        maxStamina = 10f;
        curHealth = maxHealth;
        curStamina = maxStamina;
        
        healthBar.value = Mathf.Clamp01(curHealth / maxHealth);
        staminaBar.value = Mathf.Clamp01(curStamina / maxStamina);


    }

    // Update is called once per frame
    void Update()
    {
        if (curHealth/maxHealth != healthBar.value)
        {
            healthBar.value = Mathf.Clamp01(curHealth / maxHealth);
        }
        if (curStamina / maxStamina != staminaBar.value)
        {
            staminaBar.value = Mathf.Clamp01(curStamina / maxStamina);
        }



        if (Input.GetKey(KeyCode.X))
        {

            hand.SetActive(true);
        }
        else 
        {
            hand.SetActive(false);
        }
        if (curHealth <= 0)
        {
            Death();
        }




        
    }
    private void OnTriggerStay(Collider other)
    {

       


        if (other.tag == "Spike")
        {

            curHealth -= 2 * Time.deltaTime;
            
        }





    }
    void LoseHealth()
    {
        curHealth = Mathf.Clamp(curHealth, 0, maxHealth);
        healthBar.value = Mathf.Clamp01(curHealth / maxHealth);

    }


    void Death()
    {

        isDead = true;
       


        
    }

    void Revive()
    {
        isDead = false;
        
        

    }
    

  
   
    

    
}
