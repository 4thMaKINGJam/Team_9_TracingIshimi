using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindHintSoundManager : MonoBehaviour
{
    public AudioSource bgmSource;
    public AudioSource effSource;

    public AudioClip[] sound_eff;
    public AudioClip[] sound_bgm;

    void Awake(){
        int[] character_data = {20,10,20,10,20,20};
        string[] dialog_data = {"어서오게, 자네가 이시미를 잡으러 온 그 사람인가?","그렇습니다.","그래, 여기가 바로 사람들이 잡아먹힌 현장일세.","... 정말 참혹하군요.","그 괴물이 보이는 족족 잡아먹어서,\n누구를 얼마나 잡아먹었는지도 알 수가 없다고 하더군.","이 주변을 샅샅이 살펴보다 보면 단서를 얻을 수도 있겠지."};
    }

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
