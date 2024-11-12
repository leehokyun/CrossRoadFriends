using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private string playerTag;
    public Transform Player;

    
    public GameObject endPanel;
    public TextMeshProUGUI nowScore;

    public int score = 0;

    float time = 0f;

    private void Awake()
    {
        if (Instance != null) Destroy(gameObject);
        Instance = this;

        Player = GameObject.FindGameObjectWithTag(playerTag).transform;
    }

    private void Update()
    {
        time += Time.deltaTime;
    }

    public void GameOver()
    {
        Time.timeScale = 0f; 
        //이거 말고 Update에서 처리할 수 있는 정지 방법이 있을 것. update timescale. 몬스터, 캐릭터, Ianimated 캐릭터들의 이동만 따로 
        //nowScore.text에 스코어 ToString()하기.
        endPanel.SetActive(true);
    }

    public void AddScore(int coinPoint)
    {
        score += coinPoint;
        UpdateUI();
    }

    public void UpdateUI()
    {
        nowScore.text = score.ToString();
    }
}
