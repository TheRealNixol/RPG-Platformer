using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;

    void LateUpdate()
    {
        if (player.transform.position.x > 0)
        {
            transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(0, transform.position.y, transform.position.z);
        }
    }
}
