using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    

    private void OnCollisionEnter2D(Collision2D Collision)
    { 

        if (Collision.gameObject.CompareTag("IA"))
        {
            Destroy(Collision.gameObject);
        }
        
        if (Collision.gameObject.CompareTag("Map")) 
        {
            Destroy(gameObject);
        }

        
    }
}
