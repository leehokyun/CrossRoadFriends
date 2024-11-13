using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndPanel : MonoBehaviour
{
    public TextMeshProUGUI endScore;

    public string sceneName;
    public Button retryBtn;

    public void SetPanel()
    {
        endScore.text = GameManager.Instance.score.ToString();
    }

    public void Retry()
    {
        SceneManager.LoadScene(sceneName);
    }
}
