using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Range(3,10)]
    public float walkVelocity = 5;
    private bool fltr; //False for Left, True for Right
    private static int layerMk = -1;

    private void Awake()
    {
        if(layerMk < 0)
        {
            layerMk = 0;
            layerMk = layerMk | 1 << LayerMask.NameToLayer("Terrain");
            layerMk = layerMk | 1 << LayerMask.NameToLayer("Hazardous");
        }
    }

    private void FixedUpdate()
    {
        RaycastHit2D cliffDetect, wallDetect;
        if(fltr)
        {
            wallDetect = Physics2D.CircleCast(transform.position + new Vector3(0.5f * transform.localScale.x + 0.06f,0), 0.05f, Vector2.zero, 0, layerMk);
            cliffDetect = Physics2D.CircleCast(transform.position + new Vector3(0.5f * transform.localScale.x, -0.5f * transform.localScale.y), 0.05f, Vector2.zero, 0, layerMk);
        }
        else
        {
            wallDetect = Physics2D.CircleCast(transform.position + new Vector3(-0.5f * transform.localScale.x - 0.06f, 0), 0.05f, Vector2.zero, 0, layerMk);
            cliffDetect = Physics2D.CircleCast(transform.position + new Vector3(-0.5f * transform.localScale.x, -0.5f * transform.localScale.y), 0.05f, Vector2.zero, 0, layerMk);
        }
        if ((wallDetect.collider != null && wallDetect.collider.isTrigger == false) || cliffDetect.collider == null)
            fltr = !fltr;
        float walkDis = walkVelocity * Time.fixedDeltaTime;
        transform.position = new Vector2(transform.position.x + ((fltr)? walkDis : -walkDis), transform.position.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            fltr = !fltr;
            PlayerControl.instance.GetDamage(20);
        }
    }
}
