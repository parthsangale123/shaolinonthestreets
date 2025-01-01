using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class playermovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public Animator anim;
    public Vector2 mov;
    public bool h;
    public bool g;
    public InputActionReference move;
    public InputActionReference speed;
    public float movespeed=1.25f;
    // Start is called before the first frame update
    private void OnEnable()
    {
        move.action.Enable();
        speed.action.Enable();

    }
    private void OnDisable()
    {
        move.action.Disable();
        speed.action.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        mov = move.action.ReadValue<Vector2>();
    }
    void FixedUpdate()
    {
        if (mov.x != 0 && mov.y == 0)
        {
            anim.SetInteger("directi0n", 2);

            if (mov.x == 1)
            {
                anim.SetBool("move", true);
                sr.flipX = true;

                rb.linearVelocity = new Vector2(mov.x * movespeed, 0);
                
            }
            else if (mov.x == -1)
            {
                anim.SetBool("move", true);
                sr.flipX = false;

                rb.linearVelocity = new Vector2(mov.x * movespeed, 0);
            }
            if (!g)
            {
                h = true;
            }
        }
        else if (mov.y != 0 && mov.x == 0)
        {
            if (mov.y == 1)
            {
                anim.SetBool("move", true);
                anim.SetInteger("directi0n", 1);
                rb.linearVelocity = new Vector2(0, mov.y * movespeed);

            }
            else if (mov.y == -1)
            {
                anim.SetBool("move", true);
                anim.SetInteger("directi0n", 0);
                rb.linearVelocity = new Vector2(0, mov.y * movespeed);

            }
            if (!h)
            {
                g = true;
            }
        }
        else if (mov.y != 0 && mov.x != 0)
        {
            if (!h && g)
            {
                anim.SetInteger("directi0n", 2);

                if (mov.x>0)
                {
                    anim.SetBool("move", true);
                    sr.flipX = true;

                    rb.linearVelocity = new Vector2(1 * movespeed, 0);
                }
                else if (mov.x <0)
                {
                    anim.SetBool("move", true);
                    sr.flipX = false;

                    rb.linearVelocity = new Vector2(-1 * movespeed, 0);
                }
            }
            else if (h && !g)
            {
                if (mov.y >0)
                {
                    anim.SetBool("move", true);
                    anim.SetInteger("directi0n", 1);
                    rb.linearVelocity = new Vector2(0, 1 * movespeed);

                }
                else if (mov.y <0)
                {
                    anim.SetBool("move", true);
                    anim.SetInteger("directi0n", 0);
                    rb.linearVelocity = new Vector2(0, -1 * movespeed);

                }
            }

        }
        else if(mov.x==0 && mov.y == 0)
        {
            anim.SetBool("move", false);
            h = false;
            g = false;
            rb.linearVelocity = new Vector2(0f, 0f);
        }
    }
    public void OnShift(InputAction.CallbackContext context)
    {
        switch (context.phase) {
            case InputActionPhase.Performed:
                anim.SetBool("fast", true);
                movespeed = 2.75f;
                break;
            case InputActionPhase.Canceled:
                anim.SetBool("fast", false);
                movespeed = 1.25f;
        
                break;
        }
       
        
    }
}
