using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlocking : MonoBehaviour
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
    public void Finished_Block_Animation()
    {
        controller.finishedBlock = true;
        controller.blocking = false;
    }
    public void Block()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
