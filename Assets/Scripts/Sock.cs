using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sock : MonoBehaviour
{
    [Range(1,5)]
    public int sockHash = 1;
    SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        switch(sockHash)
        {
            case 1:
                sr.color = Color.red;
                break;
            case 2:
                sr.color = Color.green;
                break;
            case 3:
                sr.color = Color.blue;
                break;
            case 4:
                sr.color = Color.grey;
                break;
            case 5:
                sr.color = Color.cyan;
                break;
            default:
                sr.color = Color.clear;
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
            SockCanvas.instance.AddSock(sockHash);
        Destroy(gameObject);
    }
}
