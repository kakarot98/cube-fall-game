using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    void Awake() {
        if(instance == null){
            instance = this;
        }       
    }

    public void RestartGame(){
        Invoke("RestartAferTime", 2f);
    }

    void RestartAferTime(){
        UnityEngine.SceneManagement.SceneManager.LoadScene("GamePlay");
    }

}
