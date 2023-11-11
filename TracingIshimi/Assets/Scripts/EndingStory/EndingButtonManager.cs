using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingButtonManager : MonoBehaviour
{
    public GameObject image_story;
    public GameObject conv_system;
    public Sprite sprite_shoot;
    public List<int> conv_character;
    int[] param_char;
    public List<string> conv_dialog;
    string[] param_dialog;
    public List<int> sprite_idx;
    int[] param_sprite;
    public List<int> sound_idx;
    int[] param_sound;

    private void Awake(){
        image_story.GetComponent<Image>().sprite = sprite_shoot;
        image_story.GetComponent<Image>().SetNativeSize();
    }

    public void Shoot(){
        conv_system.GetComponent<EndingScriptManager>().is_shoot = true;
        AppendDialog(30,1,-1,"");
        AppendDialog(30,0,-1,"화살을 맞은 이시미는 비틀거리며 쓰러졌고, 이내 피를 토하며 죽었다.");
        AppendDialog(40,-1,0,"죽은 이시미에게서는 여의주를 얻었다.");
        AppendDialog(10,2,0,"이대로라면 마을은 평안을 되찾겠지...");
        AppendDialog(30,-2,-1,"");
        AppendDialog(30,3,-1,"");
        AppendDialog(10,4,-1,"...!!!!!");
        AppendDialog(10,5,-1,"어떻게 이럴수가...");
        AppendDialog(30,-1,1,"");
        AppendDialog(30,-1,-1,"");
        AppendDialog(30,6,-1,"");
        AppendDialog(30,-1,4,"귀한 물건을 파는 고급스러운 상점 안.\n알 수 없는 빛이 맴도는 여의주가 전시되어있다.");
        AppendDialog(30,0,4,"아무도 그 출처를 묻지 않는다...");
        idListToArray();
        Debug.Log("Shoot");
        conv_system.SetActive(true);
        conv_system.GetComponent<EndingScriptManager>().CallConversation(param_char,param_dialog,param_sprite,param_sound);
    }

    public void NotShoot(){
        conv_system.GetComponent<EndingScriptManager>().is_shoot = false;
        AppendDialog(30,-1,-1,"이시미를 쏘지 않고 활을 내렸다.");
        AppendDialog(40,0,2,"이시미는 잠시 움직임을 멈췄다.\n그리고 높은 곳으로, 더 높은 곳으로 움직였다. ");
        AppendDialog(40,-1,2,"나는 그저 그 이시미를 바라볼 뿐이었다.");
        AppendDialog(20,-1,-1,"자네, ... 대체 왜?");
        AppendDialog(10,-1,-1,"이유는 모르겠어요. 단지, 나는 저것이 영물인지, 흉물인지 알 수 없을 뿐...");
        AppendDialog(30,-2,-1,"");//여기서 예외처리 바로 넘어가게
        AppendDialog(40,7,3,"천지를 울리는 굉음과 번쩍이는 번개가 잠시 우리의 눈과 귀를 가렸고, \n돌이 되어 그대로 굳어버린 이시미의 모습이 보였다.");
        AppendDialog(10,-1,3,"...! 이게 무슨...!");
        AppendDialog(30,-1,-1,"");
        AppendDialog(30,-1,-1,"그리고, 아주 오랫동안 비가 내렸다.");
        AppendDialog(30,-1,-1,"기나긴 장마였다.");
        AppendDialog(30,-1,-1,"");
        AppendDialog(30,6,4,"아주 오랜 시간이 지난 후...");
        AppendDialog(30,-1,4,"“자, 이 지역에서 가장 유명한 경관을 안 보고 갈 수 없겠죠.”");
        AppendDialog(30,-1,4,"“여기가 바로 용두암입니다.”");
        AppendDialog(30,-1,4,"“이무기 아시죠? 용이 되지 못한 뱀을 말하는데요,\n이 마을에 대대로 내려오는 전설이 있다고 합니다...”");
        idListToArray();
        Debug.Log("NotShoot");
        conv_system.SetActive(true);
        conv_system.GetComponent<EndingScriptManager>().CallConversation(param_char,param_dialog,param_sprite,param_sound);
    }

    void AppendDialog(int charid, int soundid, int spriteid, string dialog){
        conv_character.Add(charid);
        sound_idx.Add(soundid);
        sprite_idx.Add(spriteid);
        conv_dialog.Add(dialog);
    }

    void idListToArray(){
        param_char = conv_character.ToArray();
        param_sound = sound_idx.ToArray();
        param_sprite = sprite_idx.ToArray();
        param_dialog = conv_dialog.ToArray();
    }
}
