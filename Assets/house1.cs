using UnityEngine;
using UnityEngine.SceneManagement;
public class house1 : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("Player")){
            SceneManager.LoadScene("house1");
        }
    }
}
