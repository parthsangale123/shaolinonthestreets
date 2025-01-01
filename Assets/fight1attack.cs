using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fight1attack : StateMachineBehaviour
{
    Transform tr;
    Rigidbody2D rb;
    public float speed = 5f;
    public float attackrange = 1.2f;
    flipp i;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        tr = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        i = animator.GetComponent<flipp>();
        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<flipp>().LookAtPlayer();

        if (Vector2.Distance(tr.position, rb.position) <= attackrange)
        {
            animator.SetTrigger("attack");
        }
        else
        {
            Vector2 target = new Vector2(tr.position.x, rb.position.y);

            Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
            rb.MovePosition(newPos);

        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("attack");
    }


}
