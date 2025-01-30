using UnityEngine;
using UnityEngine.InputSystem;
public class pausemenu : MonoBehaviour
{
    public InputActionReference i;
    public static bool paused=false;
    public GameObject g1;
    public GameObject g2;
    
    public void pause(){
        Time.timeScale=0f;
        g1.SetActive(false);
        g2.SetActive(true);
    }
    public void resume(){
        Time.timeScale=1f;
        g1.SetActive(true);
        g2.SetActive(false);
    }
    public void pi(InputAction.CallbackContext context){
        switch(context.phase){
            case InputActionPhase.Performed:
                if(!paused){
                    pause();
                }
                else{
                    resume();
                }
                break;
        }
    }
}
