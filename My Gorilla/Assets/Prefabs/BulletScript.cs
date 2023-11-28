using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public Rigidbody2D Bullet;
 
    private void OnCollisionEnter2D(Collision2D CollisionWall)
    {
       if ( CollisionWall.gameObject.CompareTag("Map")) 
        {
            Destroy(gameObject);
        }    
    } 
}
