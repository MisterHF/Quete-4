using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class MovePlayer : MonoBehaviour
{
    public enum STATE
    {
        WALKING,
        MOD_AIM,
        MOD_SHOOT,
    }

    public STATE state = STATE.WALKING;
    public int side = 1;

    public Rigidbody2D Player;

    public float movespeed = 1f;
    float horizontalmove;

    public float jumpmove = 10f;

    public bool grounded = false;
    public int AutorizedShoot = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Player.velocity = new Vector2(horizontalmove * movespeed * Time.deltaTime, Player.velocity.y);
    }

    public void Move (InputAction.CallbackContext context)
    {
        if (state == STATE.WALKING)
        {
            horizontalmove = context.ReadValue<Vector2>().x;
            if (horizontalmove != 0) side = (int)horizontalmove; 
        }
    }
    
    public void Jump (InputAction.CallbackContext context) 
    {
        if (state == STATE.WALKING)
        {
            if (grounded)
            {
                if (context.performed)
                {
                    //Hold down jump button = full height
                    Player.velocity = new Vector2(Player.velocity.x, jumpmove);

                }
            }
        }
    }

    private void OnTriggerStay2D() 
    {
        grounded = true;
    }
    private void OnTriggerExit2D()
    {
        grounded = false;

    }
}
