using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipButton : MonoBehaviour
{
    public void SkipButtonStartScene(){
        SceneManager.LoadScene("FindHint");
    }
    public void SkipButtonFinalScene(){
        SceneManager.LoadScene("EndingStory");
    }
}
