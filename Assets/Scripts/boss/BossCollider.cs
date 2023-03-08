using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCollider : MonoBehaviour
{
    public GameObject boss;
    public Boss boss_script;
    public BossController controller_script;
    void Start()
    {
        boss_script = boss.GetComponent<Boss>();
        controller_script = boss.GetComponent<BossController>();
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
                boss.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
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
            boss.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            controller_script.combat = false;
        }
    }
}
