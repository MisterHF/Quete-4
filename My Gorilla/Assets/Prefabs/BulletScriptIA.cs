using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScriptIA : MonoBehaviour
{


    private void OnCollisionEnter2D(Collision2D Collision)
    {

        if (Collision.gameObject.CompareTag("Player"))
        {
            Destroy(Collision.gameObject);
        }

        if (Collision.gameObject.CompareTag("Map"))
        {
            Destroy(gameObject);
        }


    }
}
