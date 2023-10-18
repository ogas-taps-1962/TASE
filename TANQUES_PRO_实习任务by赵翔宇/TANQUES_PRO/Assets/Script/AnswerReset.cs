using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AnswerReset : MonoBehaviour
{
    private Text theText;
    protected void HearDead(object Pobject,BloodCheck.DeadArgs PdeadArgs)
    {
        if (PdeadArgs.SdeadNow==GameObject.FindWithTag("Player"))
        {
            Time.timeScale = 0;
            theText.text = "Over,press \"V\" to reset";
        }

        if (PdeadArgs.SdeadNow==GameObject.FindWithTag("Finish"))
        {
            Time.timeScale = 0;
            theText.text = "Win,press \"V\" to reset";
        }
    }
    private void ResetMe(object Pobject, EventArgs PeventArgs)
    {
        SceneManager.LoadScene(0,LoadSceneMode.Additive);
        SceneManager.LoadScene(1,LoadSceneMode.Additive);
        Time.timeScale = 1;
    }
    void Start()
    {
        theText = this.GetComponent<Text>();
        theText.text = "";
        BloodCheck.EdeadOne += HearDead;
        HearInput.EpressV += ResetMe;
    }
}
