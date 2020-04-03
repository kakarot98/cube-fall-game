using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    
    [SerializeField]
    private AudioSource soundFX;

    [SerializeField]
    private AudioClip landClip, deathClip, iceClip, gameOverClip;
    void Awake()
    {
        if(instance==null){
            instance = this;
        }
    }

    public void LandSound(){
        soundFX.clip = landClip;
        soundFX.Play();
    }

    public void IceBreakSound(){
        soundFX.clip = iceClip;
        soundFX.Play();
    }

    public void DeathSound(){
        soundFX.clip = deathClip;
        soundFX.Play();
    }

    public void GameOverkSound(){
        soundFX.clip = gameOverClip;
        soundFX.Play();
    }



}
