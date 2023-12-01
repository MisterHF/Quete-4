using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ShootIA : MonoBehaviour
{
    [Range(-10, 10)] public float WindForce;
     public float Gravity = 0.98665f;

    public GameObject SpeedGizmo;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 vel = SpeedGizmo.transform.position - transform.position;
     

        Vector3 pCur = transform.position;

        for (int i = 0; i < 1000; i++) 
        {
            if (pCur.y < 0.0f)
                break;

            vel += (WindForce * Vector3.right + Gravity * Vector3.down) * Time.fixedDeltaTime;
            Vector3 pNext = pCur + vel * Time.fixedDeltaTime;


            Debug.DrawLine(pCur, pNext);

            pCur = pNext;   
        }


    }
}
