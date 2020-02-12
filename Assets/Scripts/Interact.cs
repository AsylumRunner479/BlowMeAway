using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interact : MonoBehaviour
{
    public static float material;
    public Slider money;
    public Camera cam;
    public WallManager[] wall;
    public float curHealth, maxHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        material = 300;
        money.value = Score.CurWalls/Score.MaxWalls;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (money.value != Score.CurWalls / Score.MaxWalls)
        {
            money.value = Score.CurWalls / Score.MaxWalls;
        }
        if (Input.GetButton("Interact"))
        {
           
            Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
                switch (hit.collider.tag)
                {
                    case "foundation":

                        Salvage salvage = hit.transform.GetComponent<Salvage>();
                        if (salvage != null)
                        {
                            if (salvage.loot == true)
                            {
                                salvage.Scavenge();
                                
                            }
                            
                            else if (material >= 0 && salvage.wallManager.maxHealth >= salvage.wallManager.curHealth)
                            {
                                salvage.wallManager.curHealth += 100*Time.deltaTime;
                                
                                
                                
                            }
                            else
                            {

                            }
                            
                        }


                        break;
                }

            else
                print("I'm looking at nothing!");
        }





    }
}
