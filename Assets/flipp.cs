using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flipp : MonoBehaviour
{
    public GameObject player;
    public Transform tr;
    public SpriteRenderer sr;
    public bool isflipped = true;
    public static bool t;
    public void LookAtPlayer()
    {
        if (player.GetComponent<Transform>().position.x <= tr.position.x)
        {
            sr.flipX = true;
            t = true;
        }
        else if (player.GetComponent<Transform>().position.x > tr.position.x)
        {
            sr.flipX = false;
            t = false;
        }

    }
}
