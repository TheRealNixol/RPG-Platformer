using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaPotion : MonoBehaviour
{
    public GameObject self;
    void OnTriggerEnter2D(Collider2D _colInfo)
    {
        Player _player = _colInfo.GetComponent<Player>();
        if (_player != null)
        {
            _player.current_mana = _player.current_mana + 25;
            if (_player.mana < _player.current_mana) 
            {
                _player.current_mana = _player.mana;
            }
            Destroy(self);
        }
    }
}
