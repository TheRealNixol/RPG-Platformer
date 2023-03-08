using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerController controller;
    public PlayerMovement movement;
    private SpriteRenderer sprite_render;
    private Player player;
    private bool damageAlready;



    public bool inAttackRange;
    public Enemy enemy_target_right;
    public Enemy enemy_target_left;
    public Boss boss;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        controller = GetComponent<PlayerController>();
        movement = GetComponent<PlayerMovement>();
        sprite_render = GetComponent<SpriteRenderer>();
        player = GetComponent<Player>();
        damageAlready = false;
    }
    public void Finished_Attack_Animation()
    {
        controller.finishedAttack = true;
        controller.attacking = false;
        damageAlready = false;
    }

    public void Attack()
    {
        if (controller.attacking && damageAlready == false) 
        {
            if (enemy_target_right) 
            {
                if (movement.isFacingRight == true)
                {
                    damageAlready = true;
                    enemy_target_right.GetComponent<Enemy>().DamageEnemy(player.damage, player);
                }
            }

            if (enemy_target_left) 
            {
                if (movement.isFacingRight == false)
                {
                    damageAlready = true;
                    enemy_target_left.GetComponent<Enemy>().DamageEnemy(player.damage, player);
                }
            }
            if (boss) 
            {
                if (player.transform.position.x < boss.transform.position.x && movement.isFacingRight) 
                {
                    damageAlready = true;
                    boss.GetComponent<Boss>().DamageEnemy(player.damage, player);
                }
                else if (player.transform.position.x > boss.transform.position.x && movement.isFacingRight == false)
                {
                    damageAlready = true;
                    boss.GetComponent<Boss>().DamageEnemy(player.damage, player);
                }
            }
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
