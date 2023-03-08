using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderController : MonoBehaviour
{
    public GameObject enemy;
    public Enemy enemy_script;
    public EnemyController controller_script;
    void Start() 
    {
        enemy_script = enemy.GetComponent<Enemy>();
        controller_script = enemy.GetComponent<EnemyController>();
    }
    void OnTriggerEnter2D(Collider2D _colInfo)
    {
        Player _player = _colInfo.GetComponent<Player>();
        PlayerController _controller = _colInfo.GetComponent<PlayerController>();
        PlayerMovement _movement = _colInfo.GetComponent<PlayerMovement>();
        if (_player != null)
        {
            if (_controller.grounded)
            {
                enemy.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                controller_script.combat = true;
            }
            else 
            {
                _movement.PushPlayer(_colInfo.GetComponent<Rigidbody2D>().velocity);          
            }
        }
    }
    void OnTriggerExit2D(Collider2D _colInfo)
    {
        Player _player = _colInfo.GetComponent<Player>();
        if (_player != null)
        {
            enemy.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            controller_script.combat = false;
        }
    }
}
