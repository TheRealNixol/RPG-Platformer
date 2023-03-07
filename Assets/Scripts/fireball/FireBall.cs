using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    //public object air_platforms; 
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Travel(Animator animator) 
    {
        animator.SetBool("traveling", true);
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.name == "Tilemap_air" ) {
            Destroy(gameObject);
        }

    }
}
