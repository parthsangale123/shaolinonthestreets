using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class fight1health : MonoBehaviour
{
    public static float health = 200;
    public SpriteRenderer sp;
   
    public void TakeDamage(float damage)
    {
        health -= damage;
        
        sp.color = new Color(255, 255, 255, 255);

        Debug.Log("Player Health" + health);
        StartCoroutine(changeback());

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        
        StartCoroutine(die());
        sp.color = new Color(0, 0, 0, 255);

        Debug.Log("You Lose");
    }

    IEnumerator changeback()
    {

        sp.color = new Color(255, 146, 0, 255);
        yield return new WaitForSeconds(.1f);

        sp.color = new Color(255, 255, 255, 255);


    }
    IEnumerator die()
    {
        yield return new WaitForSeconds(0.5f);
        



        Time.timeScale = 0f;
    }
}
