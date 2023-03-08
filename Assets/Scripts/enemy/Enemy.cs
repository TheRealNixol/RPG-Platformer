using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public int current_health;
    public int reward_xp;

    private int attack;
    private int defense;
    private int endurance;

    public int damage;
    public int armor;

    public int nivel;

    public Transform InfoPopup;
    private EnemyController controller;
    void Start()
    {
        //Variaveis de estado do enemy
        health = 100 + ((nivel-1) * 25);
        current_health = health;
        reward_xp = 25 * nivel;

        //Variaveis de atributos do enemy
        attack = 1;
        defense = 2;
        endurance = 2;

        damage = 25 * nivel;
        controller = GetComponent<EnemyController>();
    }
    public void DamageEnemy(int damage, Player player)
    {
        current_health = current_health - damage;
        if (current_health < 0)
        {
            player.EarnXp(reward_xp);
            controller.moving = false;
            controller.chasing = false;
            controller.attack = false;
            controller.hit = false;
            controller.dead = true;
            controller.anim.SetBool("walking", false);
            controller.anim.SetBool("run", false);
            controller.anim.SetBool("attack", false);
            controller.anim.SetBool("hit", false);
            controller.anim.SetBool("dead", true);
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
