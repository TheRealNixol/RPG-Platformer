using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementInputDirection;
    public Transform groundCheck;
    private Rigidbody2D rb;
    public bool jumping = false;
    public bool walking = false;
    public bool attacking = false;
    public bool blocking = false;
    public bool spellcasting = false;
    public bool dead = false;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public bool grounded;
    public bool canJump;
    public bool canAttack;
    public bool canBlock;
    public bool canSpellCast;
    public bool finishedAttack = false;
    public bool finishedBlock = false;

    public GameObject collider;
    public GameObject self;
    public GameObject pause;
    private PauseMenu pause_script;
    public GameObject victory;
    private Victory victory_script;
    public GameObject lose;
    private Lose lose_script;

    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        pause_script = pause.GetComponent<PauseMenu>();
        victory_script = victory.GetComponent<Victory>();
        lose_script = lose.GetComponent<Lose>();

    }
    private void CheckInput()
    {
        if (pause_script.GameIsPaused == false && victory_script.victory == false && lose_script.lose == false) 
        {
            if (!dead)
            {
                movementInputDirection = Input.GetAxisRaw("Horizontal");
                if (Input.GetButtonDown("Jump") && attacking == false && blocking == false)
                {
                    if (canJump)
                    {
                        jumping = true;
                    }
                }
                if (Input.GetButtonDown("Fire1") && grounded == true)
                {
                    if (canAttack)
                    {
                        attacking = true;
                    }
                }
                if (Input.GetButtonDown("Fire2") && grounded == true)
                {
                    if (canBlock)
                    {
                        blocking = true;
                    }
                }
                if (Input.GetButtonDown("Fire3") && grounded == true)
                {
                    if (canSpellCast)
                    {
                        spellcasting = true;
                    }
                }
            }
        }  
    }
    private void CheckSurroundings()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }
    private void UpdateAnimations()
    {
        if (pause_script.GameIsPaused == false && victory_script.victory == false && lose_script.lose == false)
        {
            if (!dead)
            {
                if (Input.GetAxisRaw("Horizontal") != 0 && grounded && !attacking && !blocking && !spellcasting)
                {
                    walking = true;
                    anim.SetBool("walking", walking);
                }
                else { walking = false; anim.SetBool("walking", walking); }

                if (grounded == false && attacking == false)
                {
                    anim.SetBool("jumping", true);
                }
                else { anim.SetBool("jumping", false); }

                if (attacking == true)
                {
                    anim.SetBool("attacking", true);
                }
                else { anim.SetBool("attacking", false); }

                if (blocking == true)
                {
                    anim.SetBool("blocking", true);
                }
                else { anim.SetBool("blocking", false); }

                if (spellcasting == true)
                {
                    anim.SetBool("spellcasting", true);
                }
                else { anim.SetBool("spellcasting", false); }

                if (dead == true)
                {
                    anim.SetBool("dead", true);
                }
                else { anim.SetBool("dead", false); }
            }
        }
        
    }
    private void CheckIfCanBlock()
    {
        if (blocking)
        {
            canBlock = false;
        }
        else
        {
            canBlock = true;
        }
    }
    private void CheckIfCanAttack()
    {
        if (attacking)
        {
            canAttack = false;
        }
        else
        {
            canAttack = true;
        }
    }
    private void CheckIfCanJump()
    {
        if (grounded)
        {
            canJump = true;
            GetComponent<PlayerMovement>().pushed = false;
        }
        else
        {
            canJump = false;
        }
    }
    private void CheckIfCanCastSpell()
    {
        if (spellcasting)
        {
            canSpellCast = false;
        }
        else
        {
            canSpellCast = true;
        }
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
        lose_script.lose = true;
    }
    // Update is called once per frame
    void Update()
    {
        CheckInput();
        UpdateAnimations();
        CheckIfCanJump();
        CheckIfCanAttack();
        CheckIfCanBlock();
        CheckIfCanCastSpell();
    }
    private void FixedUpdate()
    {
        CheckSurroundings();
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
