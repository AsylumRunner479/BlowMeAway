using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salvage : MonoBehaviour
{
    public float cost;
    public bool loot = false;
    public WallManager wallManager;
    public GameObject self;
    // Start is called before the first frame update
    public void Scavenge()
    {
        //Interact.material += cost;
        gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
        loot = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
