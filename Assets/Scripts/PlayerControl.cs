using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerControl : MonoBehaviour {

    public static UnityEvent OnDie = null;
    public static PlayerControl instance = null;

    [SerializeField]
    private Rigidbody2D rb;
    private Vector2 velocity;

    [SerializeField]
    private InputManager input;
    private ObjAudioManager audioManager;

    public bool canJump;

    [Range(50, 200)]
    public int maxHp = 100;
    [SerializeField]
    public float hp;

    [Range(10,30)]
    public float JumpForce = 15;
    private float fallGravity = 4.5f, lowGravity = 2.5f, walkVelocity = 7.5f;
    /*private Vector2[] sockQueuePosition;*/

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
        if (OnDie == null)
            OnDie = new UnityEvent();
    }

    void Start()
    {
        /*audioManager = GetComponent<ObjAudioManager>();*/
        hp = maxHp;
        rb.gravityScale = fallGravity;
        /*sockQueuePosition = new Vector2[6];*/
    }

    private void Update()
    {
        if (hp <= 0)
        {
            enabled = false;
            OnDie.Invoke();
        }
        velocity = rb.velocity;
        CheckCollision();
        JumpGravity(velocity);
        /* Control moving */
       
        HorizontalMoving(velocity);
        if (Input.GetKeyDown(input.jump))
            Jump(velocity);
        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x,-walkVelocity,walkVelocity),rb.velocity.y);
        /*sockQueuePosition[0] = transform.position;
        sockQueuePosition[1] = (Vector2)transform.position - rb.velocity.normalized;
        for (int i = 2; i < sockQueuePosition.Length; i++)
        {
            Vector2 followVector = Vector2.Lerp((sockQueuePosition[i] - sockQueuePosition[i - 1]).normalized, (sockQueuePosition[i] - sockQueuePosition[0]).normalized, 1 / i).normalized;
            sockQueuePosition[i] = sockQueuePosition[i - 1] - followVector;        
        }*/
    }

    void HorizontalMoving(Vector2 velocity)
    {
        int dir = 0; // 1 for right, -1 for left, 0 for none
        if (Input.GetKey(input.right)) 
            dir = 1;
        else if (Input.GetKey(input.left)) 
            dir = -1;
        else 
            dir = 0;
        rb.AddForce(30 * new Vector2(dir, 0));
        if(dir == 0)
            rb.velocity = new Vector2(0.8f * rb.velocity.x, rb.velocity.y);
    }

    void Jump(Vector2 velocity)
    {
        if (canJump == true)
        {
            rb.AddForce(new Vector2(0, JumpForce * fallGravity * Physics2D.gravity.magnitude));
            canJump = false;
        }
    }

    void JumpGravity(Vector2 velocity)
    {
        if (velocity.y > 0 && Input.GetKey(input.jump))
            rb.gravityScale = lowGravity;
        else
            rb.gravityScale = fallGravity;
    }

    [HideInInspector]
    public RaycastHit2D hit;

    void CheckCollision()
    {
        Vector2 leftfoot, rightfoot;
        leftfoot = new Vector2(transform.position.x - 0.5f * transform.localScale.x, transform.position.y - 0.5f * transform.localScale.y);
        rightfoot = new Vector2(rb.transform.position.x + 0.5f * transform.localScale.x, transform.position.y - 0.5f * transform.localScale.y);
        hit = Physics2D.CircleCast(leftfoot, 0.04f, rightfoot - leftfoot, (rightfoot - leftfoot).magnitude, 1 << 9 | 1 << 10); 
        if (hit.collider != null && hit.collider.isTrigger == false)
            canJump = true;
        else
            canJump = false;
    }

    public void GetDamage(float damage)
    {
        hp -= damage;
    }

    private void OnDestroy()
    {
        OnDie.RemoveAllListeners();
        OnDie = null;
    }
}