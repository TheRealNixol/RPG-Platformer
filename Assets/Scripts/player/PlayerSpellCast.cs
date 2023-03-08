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
    public Transform InfoPopup;

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
                if (GetComponent<Player>().current_mana >= 25)
                {

                    //freeze player on current position
                    rb.constraints = RigidbodyConstraints2D.FreezePositionX;
                    //instanciate particle
                    current_fireball = Instantiate(FireBall_Prefab, FirePoint.position, FirePoint.rotation);
                    current_fireball.GetComponent<FireBall>().player = GetComponent<Player>();
                    current_fireball.GetComponent<CircleCollider2D>().enabled = false;
                    FireBall_Prefab.SetActive(true);
                    instanciated = true;
                    GetComponent<Player>().current_mana = GetComponent<Player>().current_mana - 25;

                }
                else
                {
                    rb.constraints = RigidbodyConstraints2D.None;
                    rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                    instanciated = false;
                    Vector3 current_pos = transform.position;
                    Vector3 target_pos = new Vector3(current_pos.x + 9.10f, current_pos.y - 1.5f, 0);
                    InfoPopup info_popup = Create(target_pos, InfoPopup);
                    info_popup.GetComponent<InfoPopup>().Setup("No Mana", "Blue");
                    controller.spellcasting = false;
                }
            }
        }
    }
    public InfoPopup Create(Vector3 position, Transform InfoPopup_obj)
    {
        Transform info_popup_transform = Instantiate(InfoPopup_obj, position, Quaternion.identity);
        InfoPopup info_popup = info_popup_transform.GetComponent<InfoPopup>();
        return info_popup;
    }
    public void SpellCast() 
    {
        //return the movement to the player
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        instanciated = false;

        fireball_animator = current_fireball.GetComponent<Animator>();
        current_fireball.GetComponent<FireBall>().Travel(fireball_animator);
        current_fireball.GetComponent<CircleCollider2D>().enabled = true;
        controller.spellcasting = false;
        instanciated = false;
    } 
}
