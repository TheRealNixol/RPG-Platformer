using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    public Player player;
    //public object air_platforms; 
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 4.5f);
    }

    public void Travel(Animator animator) 
    {
        animator.SetBool("traveling", true);
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        Boss boss = hitInfo.GetComponent<Boss>();
        if (hitInfo.name == "Tilemap_air" || hitInfo.name == "Tilemap_base") {
            Destroy(gameObject);
        } 
        else if(enemy != null)
        {
            enemy.DamageEnemy(player.spelldamage, player);
            Destroy(gameObject);
        }
        else if (boss != null)
        {
            boss.DamageEnemy(player.spelldamage, player);
            Destroy(gameObject);
        }
    }
}
