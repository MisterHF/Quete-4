using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProjectilePlayer2 : MonoBehaviour
{

    private float shoot_angle = 0;
    private bool switch_side = false;
    public bool switch_force_side = false;



    public Transform PlayerPoint;
    public GameObject ProjectilePrefab;

    public MovePlayer2 ModeShoot;

    public float MaxAngle = 90;
    public float MinAngle = -90;
    public float speed_angle = 1.5f;


    public float shootforce;
    public float forcespeed = 5f;
    public float Minshootforce = 1f;
    public float Maxshootforce = 2000f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (ModeShoot.state)                                     // Toute cette partie du code est effectué grace et avec Gabriel MIMOUNI
        {
            case MovePlayer2.STATE.WALKING:                           // (MovePlayer = ModeShoot script)   Dans le cas où le joueur se déplace
                if (Input.GetKeyDown(KeyCode.S))                     // si il appuie sur E il rentre en mode Aim et ne peut plus se déplacer
                {
                    ModeShoot.state = MovePlayer2.STATE.MOD_AIM;
                    if (ModeShoot.side == 1) shoot_angle = 0;        // Si le personnage regarde vers la droite ou vers la gauche l'angle varie 
                    else shoot_angle = 180;
                    break;
                }
                break;
            case MovePlayer2.STATE.MOD_AIM:                       // dans le cas où on est en mode Aim 
                if (Input.GetKeyDown(KeyCode.R))                     // si on appuie sur A 
                {
                    ModeShoot.state = MovePlayer2.STATE.WALKING;      // on sort du mode Aim pour retourner au mode Walking
                    break;
                }
                if (!switch_side)                                                                                                   // si onreste dans le mode Aim
                {
                    shoot_angle += speed_angle * ModeShoot.side;                                                                    // dans le cas où notre personnage regarde vers la droite
                    if ((shoot_angle >= MaxAngle && ModeShoot.side == 1) || (shoot_angle <= MaxAngle && ModeShoot.side == -1))      // on effectue un balayage allant de 0 vers 90° puis de 90° vers -90° pour la droite
                    {                                                                                                               // pour selectionner notre angle de tir vers la droite
                        switch_side = !switch_side;
                    }
                }
                else
                {
                    shoot_angle -= speed_angle * ModeShoot.side;
                    if ((shoot_angle <= MinAngle && ModeShoot.side == 1) || (shoot_angle >= 270 && ModeShoot.side == -1))           // ou dans le cas où le personnage regarde vers la gauche
                    {                                                                                                               // de 180° à 90° puis de 90° vers 270°
                        switch_side = !switch_side;                                                                                 // pour selectionner notre angle de tir vers la gauche
                    }
                }
                Vector3 anglevector = new Vector3(Mathf.Cos(shoot_angle * Mathf.PI / 180), Mathf.Sin(shoot_angle * Mathf.PI / 180), 0);    // 
                Debug.DrawLine(transform.position, transform.position + anglevector * Maxshootforce, Color.red);                           // permet de voir le tracer du mouvement de l'angle
                if (Input.GetKeyDown(KeyCode.S))
                {                                                                                                                          // si la touche E est présée une deuxième fois
                    shootforce = Minshootforce;                                                                                            // on passe du mode Aim qui gère l'angle du tir
                    ModeShoot.state = MovePlayer2.STATE.MOD_SHOOT;                                                                          // au mode Shoot qui permet de gérer la force du tir
                    break;
                }
                break;
            case MovePlayer2.STATE.MOD_SHOOT:
                Vector3 anglevector2 = new Vector3(Mathf.Cos(shoot_angle * Mathf.PI / 180), Mathf.Sin(shoot_angle * Mathf.PI / 180), 0);
                if (!switch_force_side)
                {
                    shootforce += forcespeed;                       // en mode Shoot, ici, tant que la force est à 0 elle augmente progressivement jusqu'a atteindre le Max-imum de sa puissant
                    if (shootforce >= Maxshootforce)
                    {
                        switch_force_side = !switch_force_side;
                    }
                }
                else
                {
                    shootforce -= forcespeed;                      // sinon ici, une fois la puissance au Max-imum, celle-ci diminue jusqu'à retrouver la valeur de base Min-imum
                    if (shootforce <= Minshootforce)
                    {
                        switch_force_side = !switch_force_side;
                    }
                }
                Debug.DrawLine(transform.position, transform.position + anglevector2 * shootforce, Color.red);   // permet de voir le tracer, de la force / vélocité du tir de notre personnage
                if (Input.GetKeyDown(KeyCode.S))                    // Si la touche E est présée troisième fois.
                {
                    Shoot();                                        // on effectue les conditions dans la fonction Shoot
                    ModeShoot.state = MovePlayer2.STATE.WALKING;     // et le personnage peut remarcher
                    break;
                }
                break;
        }

    }

    void Shoot()
    {
        Vector2 anglevector = new Vector2(Mathf.Cos(shoot_angle * Mathf.PI / 180), Mathf.Sin(shoot_angle * Mathf.PI / 180)); // permet de calculer l'angle de tir
        Vector3 Pos = new Vector3(PlayerPoint.position.x, PlayerPoint.position.y, 0f);
        GameObject Proj = Instantiate(ProjectilePrefab, Pos, PlayerPoint.rotation);
        Proj.GetComponent<Rigidbody2D>().velocity = anglevector * shootforce;

    }
}

