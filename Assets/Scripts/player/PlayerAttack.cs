using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerController controller;
    private SpriteRenderer sprite_render;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        controller = GetComponent<PlayerController>();
        sprite_render = GetComponent<SpriteRenderer>();
    }
    public void Finished_Attack_Animation()
    {
        controller.finishedAttack = true;
        controller.attacking = false;
    }
    private void Attack() 
    {
        if (controller.attacking)
        {
            //CHECK FOR COLLISION WITH AN ENEMY

            //IF COLLISION -> APPLY DAMAGE
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        Attack();
    }
    void FixedUpdate()
    {
        
    }
}
