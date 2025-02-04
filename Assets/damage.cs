using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class damage : MonoBehaviour
{
    public Rigidbody2D rn;
    public int maxhealth = 200;
    int currenthealth;
    
    public SpriteRenderer sp;
    public Animator anim;
    
    public Slider slider;
    
    
    void Start()
    {
        currenthealth = maxhealth;
        slider.maxValue=maxhealth;
        slider.minValue=0;

    }
    void Update()
    {
        if(currenthealth>0){
            slider.value=currenthealth;
        }
        else if (currenthealth<=0){
            slider.value=0;
        }

    }
    public void TakeDamage(int damage)
    {
        currenthealth -= damage;
        
        Debug.Log(currenthealth);
        sp.color = new Color(210, 0, 0);
        StartCoroutine(changeback());
        Debug.Log("Opponent Health" + currenthealth);
        if (currenthealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        anim.SetTrigger("die");
        sp.color = new Color(0, 0, 0);
        StartCoroutine(die());

        Debug.Log("You win");
        

    }
    IEnumerator changeback()
    {
        yield return new WaitForSeconds(0.25f);

        sp.color = new Color(255, 255, 255);
    }
    IEnumerator die()
    {
        yield return new WaitForSeconds(0.5f);
        
        
        
        
        

        Time.timeScale = 0f;
    }
}
