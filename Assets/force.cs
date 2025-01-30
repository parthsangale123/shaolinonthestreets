using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
public class force : MonoBehaviour
{


    Rigidbody2D rg;
    Animator anim;
    public static bool h;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
   

    // Update is called once per frame
    
    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.CompareTag("Player") && col.gameObject.GetComponent<Rigidbody2D>().linearVelocity.y<=0 && col.gameObject.GetComponent<Transform>().position.y>0.7f){
            
            rg=col.gameObject.GetComponent<Rigidbody2D>();
            anim=col.gameObject.GetComponent<Animator>();
            rg.AddForce(new Vector2(rg.linearVelocity.x, 900f));
            Vector2 vel=rg.linearVelocity;
            h=true;
            StartCoroutine(j());
            if(anim.GetInteger("right")==1){
                vel=new Vector2(1200, rg.linearVelocity.y);
                rg.linearVelocity=vel;
                Debug.Log("dance");
            }
            else if(anim.GetInteger("right")==2){
                rg.AddForce(new Vector2(-1200f, rg.linearVelocity.y));

            }
        }
    }
    IEnumerator j(){
        yield return new WaitForSeconds(0.7f);
        h=false;
    }
}
