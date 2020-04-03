using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
   public float moveSpeed = 2f;
   public float bound = 6f;
   public bool isLeftSpeed, isRightSpeed, isPlatform, isSpike, isBreakable;

   private Animator anim;

    void Awake(){
        anim = GetComponent<Animator>();
    }
    
    void Update(){
        Move();

    }

    void Move(){
        Vector2 temp = transform.position;
        temp.y += moveSpeed * Time.deltaTime;
        transform.position = temp;

        if(temp.y>=bound){
            gameObject.SetActive(false);
        }
    }

    void BreakableDeactivate(){
        Invoke("DeactivateGameObject",0.3f);
    }

    void DeactivateGameObject(){
        SoundManager.instance.IceBreakSound();
        gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D target){
        if(target.tag == "Player"){

            if(isSpike){
                target.transform.position = new Vector2(1000f, 1000f);
                SoundManager.instance.GameOverkSound();
                GameManager.instance.RestartGame();
            }
        }
    }

    void OnCollisionEnter2D(Collision2D target) {
        if(target.gameObject.tag == "Player"){
            if(isBreakable){
                SoundManager.instance.LandSound();
                anim.Play("Break");
            }
            if(isPlatform){
                SoundManager.instance.LandSound();
            }
        }
    } // oncolliisionenter

    void OnCollisionStay2D(Collision2D target) {
        if(target.gameObject.tag == "Player"){            
            if(isLeftSpeed){
                target.gameObject.GetComponent<PlayerMovement>().PlatformMove(-1f);
            }
            if(isRightSpeed){
                target.gameObject.GetComponent<PlayerMovement>().PlatformMove(1f);
            }
        }
    }

    
}






