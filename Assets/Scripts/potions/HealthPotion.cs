using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    public GameObject self;

    void OnTriggerEnter2D(Collider2D _colInfo)
    {
        Player _player = _colInfo.GetComponent<Player>();
        if (_player != null)
        {
            _player.current_hp = _player.current_hp + 25;
            if (_player.health < _player.current_hp)
            {
                _player.current_hp = _player.health;
            }
            Destroy(self);
        }
    }
}
