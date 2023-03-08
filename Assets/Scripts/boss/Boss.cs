using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int health;
    public int current_health;
    public int reward_xp;

    private int attack;
    private int defense;
    private int endurance;

    public int damage;
    public int armor;

    public Transform InfoPopup;
    private BossController controller;
    void Start()
    {
        //Variaveis de estado do enemy
        health = 300;
        current_health = health;
        reward_xp = 150;

        //Variaveis de atributos do enemy
        attack = 1;
        defense = 2;
        endurance = 2;

        damage = 30;
        controller = GetComponent<BossController>();
    }
    public void DamageEnemy(int damage, Player player)
    {
        current_health = current_health - damage;
        if (current_health < 0)
        {
            player.EarnXp(reward_xp);
            controller.chasing = false;
            controller.attack = false;
            controller.hit = false;
            controller.dead = true;
            controller.anim.SetBool("move", false);
            controller.anim.SetBool("basic", false);
            controller.anim.SetBool("hit", false);
            controller.anim.SetBool("die", true);
        }
        else
        {
            controller.hit = true;
            controller.anim.SetBool("hit", true);

        }
        Vector3 current_pos = transform.position;
        Vector3 target_pos = new Vector3(current_pos.x + 9.10f, current_pos.y - 0.5f, 0);
        InfoPopup info_popup = Create(target_pos, InfoPopup);
        info_popup.GetComponent<InfoPopup>().Setup("-" + damage + " Health", "Red");
    }
    public InfoPopup Create(Vector3 position, Transform InfoPopup_obj)
    {
        Transform info_popup_transform = Instantiate(InfoPopup_obj, position, Quaternion.identity);
        InfoPopup info_popup = info_popup_transform.GetComponent<InfoPopup>();
        return info_popup;
    }
}
