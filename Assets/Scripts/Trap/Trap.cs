using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public int damage = 25;

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D _colInfo)
    {
        Player _player = _colInfo.GetComponent<Player>();
        if (_player != null)
        {
            PlayerMovement _player_movement = _colInfo.GetComponent<PlayerMovement>();
            _player.DamagePlayer(damage);
            _player_movement.PushPlayer(_colInfo.GetComponent<Rigidbody2D>().velocity);
        }
    }
}
