using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProjectile : MonoBehaviour
{
    public Transform PlayerPoint;
    public GameObject ProjectilePrefab;

    public MovePlayer ModeShoot;

    public float Velx;
    public float Vely;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (ModeShoot.AutorizedShoot == 1)
            {
                Shoot();
                ModeShoot.AutorizedShoot = 0;
            }
            else
            {
                ModeShoot.AutorizedShoot = 1;
            }
        }
    }

    void Shoot()
    {

        Vector3 Pos = new Vector3 (PlayerPoint.position.x + 0.7f, PlayerPoint.position.y, 0f); 
        GameObject Proj = Instantiate(ProjectilePrefab, Pos, PlayerPoint.rotation);
        Proj.GetComponent<Rigidbody2D>().velocity = new Vector2(Velx, Vely);

    }
}
