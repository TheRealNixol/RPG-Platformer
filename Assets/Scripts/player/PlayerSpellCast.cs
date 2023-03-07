using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpellCast : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject FireBall_Prefab;
    private PlayerController controller;
    private Animator fireball_animator;
    private bool instanciated = false;
    private GameObject current_fireball;
    private Rigidbody2D rb;

    private void Start()
    {
        controller = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        CheckForFireBallCast();
    }

    public void CheckForFireBallCast() 
    {
        if (controller.spellcasting) 
        {
            if (!instanciated)
            {
                //freeze player on current position
                rb.constraints = RigidbodyConstraints2D.FreezePositionX;
                //instanciate particle
                current_fireball = Instantiate(FireBall_Prefab, FirePoint.position, FirePoint.rotation);

                FireBall_Prefab.SetActive(true);
                instanciated = true;
            }
        }
    }
    public void SpellCast() 
    {
        //return the movement to the player
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        fireball_animator = current_fireball.GetComponent<Animator>();
        current_fireball.GetComponent<FireBall>().Travel(fireball_animator);
        controller.spellcasting = false;
        instanciated = false;
    } 
}
