using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            //PlayerControl.instance.GetDamage(20);
            if (collision.gameObject.transform.position.x > transform.position.x)
                PlayerControl.instance.GiveForce(new Vector2(250, 300));
            else
                PlayerControl.instance.GiveForce(new Vector2(-250, 300));
        }
    }
}
