using UnityEngine;
using UnityEngine.UI;


public class Movement : MonoBehaviour
{
    [Header("Speed Vars")]
    //value Variables
    public float moveSpeed;
    public float walkSpeed, runSpeed, crouchSpeed, jumpSpeed;
    public static float _gravity = 20;
    //Struct - Contains Multiple Variables (eg...3 floats)
    private Vector3 _moveDir;
    //Reference Variable
    public PlayerHandler player;
    public CharacterController _charC;

 
    
    private void Start()
    {
        _charC = GetComponent<CharacterController>();
        
        _gravity = 20;
        
       
    }
   
    private void Update()
    {
        Move();
      
    }
   
    private void Move()
    {
        if (_charC.isGrounded && !PlayerHandler.isDead)
        {
            //set speed
            if (Input.GetButton("Crouch"))
            {

                if (player.curStamina <= player.maxStamina && player.curStamina != player.maxStamina)
                {
                    player.curStamina += Time.deltaTime;
                }

                moveSpeed = crouchSpeed;
            }

            else if (Input.GetButton("Sprint") && player.curStamina > 0)
            {

                player.curStamina -= 2 * Time.deltaTime;
                moveSpeed = runSpeed;
                
            }

            else
            {
                if (player.curStamina <= player.maxStamina)
                {
                    player.curStamina += Time.deltaTime;
                }
                moveSpeed = walkSpeed;
               
            }
            if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
            {
                
            }
            else if (!(Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0))
            {
                
            }
            _moveDir = transform.TransformDirection(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * moveSpeed);
            if (Input.GetButton("Jump"))
            {
                
                _moveDir.y = jumpSpeed;
               
            }
        }
        if (PlayerHandler.isDead)
        {
            _moveDir = Vector3.zero;
        }

        _moveDir.y -= _gravity * Time.deltaTime;


        _charC.Move(_moveDir * Time.deltaTime);
    }

}


