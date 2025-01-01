using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
public class playermovement2 : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform tr;
    public float speed = 5f;
    Vector2 movment;
    public Animator anim;
    // Update is called once per frame
    public bool jump;
    public Transform a1;
    public Transform a2;
    Transform attackpoint;
    public float attack_range = 0.5f;
    public LayerMask enemylayers;
    public float attackrate = 2f;
    float nextattacktime = 0f;
    float currenthealth;
    public SpriteRenderer sr;
    public GameObject g;


    public InputActionReference move;
    
    public bool pch;
    public bool kk;
    void Start()
    {

        currenthealth = 200f;

        attackpoint = a1;
    }
    private void OnEnable()
    {
        move.action.Enable();
        
    }
    private void OnDisable()
    {
        move.action.Disable();
        
    }
    void Update()
    {
        currenthealth = fight1health.health;
        movment = move.action.ReadValue<Vector2>();
        

    }
    void FixedUpdate()
    {




        if (pch == false && kk == false)
        {
            
            anim.SetInteger("punch", 0);
            rb.linearVelocity = new Vector2(movment.x * speed, rb.linearVelocity.y);
            if (movment.y == 1f && jump == false)
            {
                rb.AddForce(new Vector2(rb.linearVelocity.x, 1000f));
                anim.SetBool("jump", true);

            }
            if (movment.x == 1f)
            {
                anim.SetInteger("right", 1);
                attackpoint = a1;
                sr.flipX = false;
                anim.SetBool("move", true);
            }
            else if (movment.x == -1f)
            {
                sr.flipX = true;
                anim.SetInteger("right", 2);
                anim.SetBool("move", true);
                attackpoint = a2;

            }
            else if (movment.x == 0f)
            {

                anim.SetInteger("punch", 0);
                anim.SetBool("move", false);
            }


        }
        if (pch == true && kk == false && !jump)
        {
            if (Time.time >= nextattacktime)
            {
                punch();
                nextattacktime = Time.time + 1f/2f ;
            }
            anim.SetInteger("punch", 1);
            rb.linearVelocity = new Vector2(movment.x * speed, rb.linearVelocity.y);
            if (movment.x == 1f)
            {
                sr.flipX = false;
                anim.SetInteger("right", 1);
                attackpoint = a1;
                anim.SetBool("move", true);
            }
            else if (movment.x == -1f)
            {
                sr.flipX = true;
                anim.SetInteger("right", 2);
                anim.SetBool("move", true);
                attackpoint = a2;

            }
            else if (movment.x == 0f)
            {
                anim.SetBool("move", false);

            }




        }
        else if (kk == true && !jump)
        {
            if (Time.time >= nextattacktime)
            {
                kick();
                nextattacktime = Time.time + 1.5f;
            }

            anim.SetInteger("punch", 2);
            anim.SetBool("move", false);
            rb.MovePosition(rb.position);
            if (movment.x == 1f)
            {
                sr.flipX = false;
                anim.SetInteger("right", 1);
                attackpoint = a1;


            }
            else if (movment.x == -1f)
            {
                sr.flipX = true;
                anim.SetInteger("right", 2);

                attackpoint = a2;
            }
        }





    }
    void punch()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackpoint.position, attack_range, enemylayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            
            enemy.GetComponent<damage>().TakeDamage(5);
            if (anim.GetInteger("right") == 1)
            {
                g.GetComponent<Rigidbody2D>().AddForce(new Vector2(200f, g.GetComponent<Rigidbody2D>().linearVelocity.y));
            }
            else if (anim.GetInteger("right") == 2)
            {
                g.GetComponent<Rigidbody2D>().AddForce(new Vector2(-200f, g.GetComponent<Rigidbody2D>().linearVelocity.y));
            }
        }

    }
    void kick()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackpoint.position, attack_range, enemylayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            
            enemy.GetComponent<damage>().TakeDamage(7);
            if (anim.GetInteger("right") == 1)
            {
                g.GetComponent<Rigidbody2D>().AddForce(new Vector2(100f, g.GetComponent<Rigidbody2D>().linearVelocity.y));
            }
            else if (anim.GetInteger("right") == 2)
            {
                g.GetComponent<Rigidbody2D>().AddForce(new Vector2(-100f, g.GetComponent<Rigidbody2D>().linearVelocity.y));
            }
        }

    }
    private void OnCollisionEnter2D(Collision2D other)
    {


        if (other.gameObject.CompareTag("Square"))
        {
            jump = false;
            anim.SetBool("jump", false);


        }

    }
    private void OnCollisionExit2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("Square"))
        {
            jump = true;
        }

    }
    public void OnPunch(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:
                pch = true;
                break;
            case InputActionPhase.Canceled:
                pch = false;
                break;
        }
    }
    public void OnKick(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:
                kk = true;
                break;
            case InputActionPhase.Canceled:
                kk = false;
                break;
        }
    }
}
