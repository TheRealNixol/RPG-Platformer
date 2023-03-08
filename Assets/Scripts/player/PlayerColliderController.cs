using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliderController : MonoBehaviour
{
    public GameObject player;
    public Player player_script;
    public PlayerAttack player_attack_script;
    public PlayerController controller_script;
    // Start is called before the first frame update
    void Start()
    {
        player_script = player.GetComponent<Player>();
        controller_script = player.GetComponent<PlayerController>();
        player_attack_script = player.GetComponent<PlayerAttack>();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D _colInfo)
    {
        Enemy _enemy = _colInfo.GetComponent<Enemy>();
        EnemyController _controller = _colInfo.GetComponent<EnemyController>();

        Boss _boss = _colInfo.GetComponent<Boss>();
        BossController _boss_controller = _colInfo.GetComponent<BossController>();
        if (_enemy != null)
        {
            player_attack_script.inAttackRange = true;

            if (player.transform.position.x < _enemy.transform.position.x)
            {
                player_attack_script.enemy_target_right = _enemy;
            }
            else
            {
                player_attack_script.enemy_target_left = _enemy;
            }
        }
        else if(_boss != null) 
        {
            player_attack_script.inAttackRange = true;

            player_attack_script.boss = _boss;
        }
    }
    void OnTriggerExit2D(Collider2D _colInfo)
    {
        Enemy _enemy = _colInfo.GetComponent<Enemy>();
        Boss _boss = _colInfo.GetComponent<Boss>();
        if (_enemy != null)
        {
            player_attack_script.inAttackRange = false;
            if (player.transform.position.x < _enemy.transform.position.x)
            {
                player_attack_script.enemy_target_right = null;
            } 
            else
            {
                player_attack_script.enemy_target_left = null;
            }
        }
        else if (_boss != null)
        {
            player_attack_script.inAttackRange = true;

            player_attack_script.boss = null;
        }
    }
}
