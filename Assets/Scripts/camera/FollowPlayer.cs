using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 last_position;
    void LateUpdate()
    {
        if (player)
        {
            if (player.transform.position.x > 0)
            {
                transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 3f, transform.position.z);
                last_position = transform.position;
            }
            else
            {
                transform.position = new Vector3(0, player.transform.position.y + 3f, transform.position.z);
                last_position = transform.position;
            }
        } 
        else 
        {
            transform.position = last_position;
        }
        
    }
}
