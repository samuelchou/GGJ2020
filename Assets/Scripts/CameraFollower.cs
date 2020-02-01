using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    private PlayerControl player;
    private float camZ;
    [Range(0.05f, 0.5f)]
    public float followStr = 0.1f;

    void Start()
    {
        player = PlayerControl.instance;
        camZ = transform.position.z;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector2 playerPos = player.transform.position;
        Vector2 current = transform.position;
        current = Vector2.Lerp(current, playerPos, followStr);
        transform.position = new Vector3(current.x, current.y, camZ);
    }
}
