using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class peopleTextIn : MonoBehaviour
{

    public float time;
    public Text text;
    int num;
    AudioSource typingAudio;
    // Start is called before the first frame update
    void Start(){
        typingAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame

    void Update()
    {
        time += Time.deltaTime;
        num = (int)time;

        if (num > 55) {
            text.text = "자네, 그거 들었나?";
            startAudio();
        }

        if (num > 59) {
            text.text = "박영감네 밭에 이시미가 나타나서 동네 사람들을 죄다 잡아먹은 모양이야.";
            startAudio();
        }

        if (num > 68) {
            text.text = "이시미가 뭐냐고?";
            startAudio();
        }

        if (num > 72) {
            text.text = "그 괴물 있잖나, 용이 되지 못해서 사람들을 해친다는 그 이무기놈.";
            startAudio();
        }

        if (num > 79) {
            text.text = "박영감네 가족, 식솔. 그놈에게 다 잡아먹혔다네.";
            startAudio();
        }

        if (num > 85) {
            text.text = "그 어린 손주놈까지 말이야. 쯧쯧, 안됐지.";
            startAudio();
        }
        
        if (num > 89) {
            text.text = "‘... 또 누가 죽었냐고?";
            startAudio();
        }

        if (num > 95) {
            text.text = "글쎄, 마을 골칫덩이였던 그놈이 요즘은 통 안 보이는데…";
            startAudio();
        }

        if (num > 101) {
            text.text = "그놈은 안 잡아먹혔나?";
            startAudio();
        }

        if (num > 104) {
            text.text = "... 아닐세, 자네도 몸조심하게나.";
            startAudio();
        }

        if (num > 114) {
            SceneManager.LoadScene("MoveToNPC");
        }


    }
    void startAudio(){
        typingAudio.Play();
    }
}
