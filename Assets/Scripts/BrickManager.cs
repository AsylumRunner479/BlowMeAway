using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickManager : MonoBehaviour
{
    public Rigidbody rigid;
    public WallManager wall;
    public bool intact = true;
    Vector3 oldPos;
    public Quaternion originalRotationValue;
    
    // Start is called before the first frame update
    void Start()
    {
        oldPos = transform.position;
        originalRotationValue = gameObject.transform.rotation;
        
    }
    public void Collapse()
    {
        
        transform.Translate(0, 1, 0);
        rigid.constraints = RigidbodyConstraints.None;
        intact = false;
        
    }
    private void OnTriggerStay(Collider other)
    {




        if (other.tag == "Spike" && wall.collapse == false)
        {

            wall.curHealth -= 3*Time.deltaTime/4;

        }





    }
    // Update is called once per frame
    void Update()
    {
        if (wall.collapse == true && intact == true)
        {
            Collapse();
        }
        if (wall.collapse == false && intact == false)
        {
            intact = true;
            transform.rotation = originalRotationValue;
            transform.position = oldPos;
            rigid.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;

        }
    }
}
