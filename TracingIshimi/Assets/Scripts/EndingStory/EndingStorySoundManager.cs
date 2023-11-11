using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class EndingStorySoundManager : MonoBehaviour
{
   public AudioSource bgmSource;
    public AudioSource effSource;
    public GameObject effSource_obj;

    public AudioClip[] sound_eff;
    public AudioClip[] sound_bgm;
    public bool bgm_paused = false;

    public void playSoundEffect(string eff_name){
        for(int i = 0; i<sound_eff.Length;i++){
            if(eff_name==sound_eff[i].name){
                effSource.clip = sound_eff[i];
                effSource.Play();
            }
        }
    }
    public void fadeoutEffect(){
        effSource_obj.GetComponent<FadeOut>().isFadeOut = true;
    }

    public void playBGM(string bgm_name){
        for(int i = 0; i<sound_bgm.Length;i++){
            if(bgm_name==sound_bgm[i].name){
                bgmSource.clip = sound_bgm[i];
                bgmSource.Play();
            }
        }
    }

    public void pauseBGM(){
        bgmSource.Pause();
    }
    public void resumeBGM(){
        bgmSource.UnPause();
    }
    public void stopBGM(){
        bgmSource.Stop();
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
        effSource.Stop();
    }

    public void playButtonSound(){
        for(int i = 0; i<sound_eff.Length;i++){
            if("button_click"==sound_eff[i].name){
                effSource.clip = sound_eff[i];
                effSource.Play();
            }
        }
    }
}