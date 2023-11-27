using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class MovePlayer : MonoBehaviour
{
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
        if (AutorizedShoot == 0)
        {
            horizontalmove = context.ReadValue<Vector2>().x;
        }
    }
    
    public void Jump (InputAction.CallbackContext context) 
    {
        if (AutorizedShoot == 0)
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

    private void OnTriggerEnter2D() 
    {
        grounded = true;
    }
    private void OnTriggerExit2D()
    {
        grounded = false;

        print("ropvfjpz");
    }
}
