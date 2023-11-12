using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindHintSoundManager : MonoBehaviour
{
    public AudioSource bgmSource;
    public AudioSource effSource;

    public AudioClip[] sound_eff;
    public AudioClip[] sound_bgm;
    
    public void playSoundEffect(string eff_name){
        for(int i = 0; i<sound_eff.Length;i++){
            if(eff_name==sound_eff[i].name){
                effSource.clip = sound_eff[i];
                effSource.Play();
            }
        }
    }

    public void playBGM(string bgm_name){
        for(int i = 0; i<sound_bgm.Length;i++){
            if(bgm_name==sound_bgm[i].name){
                bgmSource.clip = sound_bgm[i];
                bgmSource.Play();
            }
        }
    }

    public void playTypingSound(){
        for(int i = 0; i<sound_eff.Length;i++){
            if("text_typing"==sound_eff[i].name){
                effSource.clip = sound_eff[i];
                effSource.loop = true;
                effSource.Play();
            }
        }
    }
    public void stopTypingSound(){
        effSource.loop = false;
        effSource.Stop();
    }

}
