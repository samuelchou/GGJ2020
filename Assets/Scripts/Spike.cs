using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public int damage = 20; // 作用於玩家身上

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            PlayerControl.instance.GetDamage(damage);
            if (collision.gameObject.transform.position.x > transform.position.x)
                PlayerControl.instance.GiveForce(new Vector2(250, 300));
            else
                PlayerControl.instance.GiveForce(new Vector2(-250, 300));
        }
    }
}
