using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    public Animator anim;

    private float timer_attack;

    public bool combat;
    public bool attack;
    public bool chasing;
    public bool dead;
    public bool hit;
    public float movementSpeed = 1f;

    private bool movingRight;
    private bool facingRight;
    private bool rotated;

    public Transform target;
    public int minRange;
    public int maxRange;
    public bool follow;

    public GameObject collider;
    public GameObject self;

    public Player player;
    public Boss boss;
    public GameObject victory;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        timer_attack = 0.5f;
        chasing = false;
        combat = false;
        attack = false;
        hit = false;
        dead = false;
        movingRight = true;
        facingRight = true;
        rotated = true;
        maxRange = 2;
        minRange = 10;

    }
    public void Chase()
    {
        if (!dead)
        {
            if (Vector3.Distance(transform.position, target.position) < minRange)
            {
                if (attack == false && hit == false)
                {
                    chasing = true;
                    if (!combat)
                    {
                        this.anim.SetBool("move", true);
                    }

                    if (transform.position.x < target.position.x)
                    {
                        if (!facingRight)
                        {
                            transform.Rotate(0f, 180f, 0f);
                            facingRight = true;
                        }

                        if (!combat)
                        {
                            rb.velocity = new Vector2(movementSpeed / 5, rb.velocity.y);
                        }
                    }
                    else
                    {
                        if (facingRight)
                        {
                            transform.Rotate(0f, 180f, 0f);
                            facingRight = false;
                        }
                        if (!combat)
                        {
                            rb.velocity = new Vector2(-movementSpeed / 5, rb.velocity.y);
                        }
                    }

                    if (combat)
                    {
                        this.anim.SetBool("move", false);
                    }
                }
                else
                {
                    this.anim.SetBool("move", false);
                }
            }
            else
            {
                chasing = false;
                combat = false;
                this.anim.SetBool("move", false);
            }
        }

    }

    public void Attack()
    {
        if (!dead)
        {
            if (combat && attack == false && hit == false)
            {
                timer_attack -= Time.deltaTime;
                if (timer_attack < 0)
                {
                    this.anim.SetBool("basic", true);
                    attack = true;
                    player.DamagePlayer(boss.damage);
                }
            }
            else if (hit == true && attack == true)
            {
                attack = false;
                this.anim.SetBool("basic", false);
                timer_attack = 0.5f;
            }
            else
            {
                timer_attack = 0.5f;
            }
        }
    }
    public void Finished_Attack_Animation()
    {
        attack = false;
        this.anim.SetBool("basic", false);
        timer_attack = 1.5f;
    }
    public void Finished_Hit_Animation()
    {
        hit = false;
        this.anim.SetBool("hit", false);
    }
    public void Dead()
    {
        Destroy(collider);
        Destroy(this.GetComponent<Rigidbody2D>());
        Destroy(this.GetComponent<CapsuleCollider2D>());
    }
    public void SelfDestroy()
    {
        Destroy(self);
        victory.GetComponent<Victory>().victory = true;
    }
    // Update is called once per frame
    void Update()
    {
        Chase();
        Attack();
    }
}
