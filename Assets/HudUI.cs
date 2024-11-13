using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class HudUI : MonoBehaviour
{

    public TextMeshProUGUI nowScore;
    public TextMeshProUGUI timeTxt;

    
    public void SetTimeTxt(float time)
    {
        timeTxt.text = time.ToString("N2");
    }

    public void UpdateUI(int score)
    {
        nowScore.text = score.ToString();
    }
}
