using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int health;
    public int current_hp;
    public int mana;
    public int current_mana;
    public int xp;
    public int current_xp;
    public int level;

    public int damage;
    public int spelldamage;

    public GameObject health_bar;
    public GameObject mana_bar;
    public GameObject experience_bar;
    public Health health_script;
    public Mana mana_script;
    public Experience exp_script;
    public GameObject level_obj;
    public Text level_text;

    private int attack;
    private int defense;
    private int endurance;
    private int intelect;
    private int magic;

    private PlayerController controller;
    public Transform InfoPopup;

    void Start()
    {
        //Health
        health = 100;
        current_hp = 100;
        health_bar = GameObject.FindGameObjectWithTag("Health");
        health_script = health_bar.GetComponent<Health>();
        health_script.minimum = 0;
        health_script.maximum = 100;
        health_script.current = current_hp;
        //Mana
        mana = 100;
        current_mana = 25;
        mana_bar = GameObject.FindGameObjectWithTag("Mana");
        mana_script = mana_bar.GetComponent<Mana>();
        mana_script.minimum = 0;
        mana_script.maximum = 100;
        mana_script.current = current_mana;
        //Experience
        xp = 50;
        current_xp = 0;
        experience_bar = GameObject.FindGameObjectWithTag("Experience");
        exp_script = experience_bar.GetComponent<Experience>();
        exp_script.minimum = 0;
        exp_script.maximum = 50;
        exp_script.current = current_xp;
        //Nivel
        level = 1;
        level_obj = GameObject.FindGameObjectWithTag("Level");
        level_text = level_obj.GetComponent<Text>();
        level_text.text = "Nivel " + level;


        //Variaveis de atributos do player
        attack = 0;
        defense = 0;
        endurance = 0;
        intelect = 0;
        magic = 0;

        damage = 15;
        spelldamage = 25;

        controller = GetComponent<PlayerController>();
    }
    void UpInformation()
    {
        health_script.current = current_hp;
        mana_script.current = current_mana;
        exp_script.current = current_xp;
        level_text.text = "Nivel " + level;
    }
    public void DamagePlayer(int damage) 
    {
        if (GetComponent<PlayerController>().blocking) 
        {
            Vector3 current_pos = transform.position;
            Vector3 target_pos = new Vector3(current_pos.x + 9.10f, current_pos.y - 1.5f, 0);
            InfoPopup info_popup = Create(target_pos, InfoPopup);
            info_popup.GetComponent<InfoPopup>().Setup("Parried!", "Golden");
        }
        else 
        {
            current_hp = current_hp - damage;
            if (current_hp <= 0)
            {
                controller.walking = false;
                controller.spellcasting = false;
                controller.jumping = false;
                controller.attacking = false;
                controller.blocking = false;
                controller.dead = true;
                controller.anim.SetBool("walking", false);
                controller.anim.SetBool("spellcasting", false);
                controller.anim.SetBool("jumping", false);
                controller.anim.SetBool("attacking", false);
                controller.anim.SetBool("blocking", false);
                controller.anim.SetBool("dead", true);
            }
            Vector3 current_pos = transform.position;
            Vector3 target_pos = new Vector3(current_pos.x+9.10f, current_pos.y-1.5f, 0);
            InfoPopup info_popup = Create(target_pos, InfoPopup);
            info_popup.GetComponent<InfoPopup>().Setup("-" + damage + " Health", "Red");
        }
        
    }
    public void EarnXp(int exp)
    {
        current_xp = current_xp + exp;
        Vector3 current_pos = transform.position;
        Vector3 target_pos = new Vector3(current_pos.x + 9.10f, current_pos.y - 1.5f, 0);
        InfoPopup info_popup = Create(target_pos, InfoPopup);
        info_popup.GetComponent<InfoPopup>().Setup("+" + exp + " XP", "Purple");
        if (current_xp >= xp) 
        {   
            //aumenta xp
            current_xp = xp - current_xp;
            xp = xp * 2;
            exp_script.maximum = xp;
            level = level + 1;
            //aumenta a mana 
            mana = mana + 25;
            mana_script.maximum = mana_script.maximum + 25;
            current_mana = current_mana + 25;
            //aumenta a vida
            health = health + 25;
            health_script.maximum = health_script.maximum + 25;
            current_hp = current_hp + 25;

            //aumenta ataque
            damage = damage + 5;
            spelldamage = spelldamage + 5;
            Vector3 target_pos2 = new Vector3(current_pos.x + 9.10f, current_pos.y - 1f, 0);
            InfoPopup info_popup2 = Create(target_pos2, InfoPopup);
            info_popup2.GetComponent<InfoPopup>().Setup("Level Up", "Golden");
        }
        

    }
    public InfoPopup Create(Vector3 position, Transform InfoPopup_obj)
    {
        Transform info_popup_transform = Instantiate(InfoPopup_obj, position, Quaternion.identity);
        InfoPopup info_popup = info_popup_transform.GetComponent<InfoPopup>();
        return info_popup;
    }
    void Update() 
    {
        UpInformation();
    }
}
