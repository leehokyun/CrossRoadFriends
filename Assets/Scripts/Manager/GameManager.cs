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


    public TextMeshProUGUI timeTxt;
    public int score = 0;

    float time = 0f;
    private float elapsedTime = 0f; // 경과 시간 변수
    public ParticleSystem EffectParticle;

    private void Awake()
    {
        if (Instance != null) Destroy(gameObject);
        Instance = this;

        Player = GameObject.FindGameObjectWithTag(playerTag).transform;

        EffectParticle = GameObject.FindGameObjectWithTag("Particle").gameObject.GetComponent<ParticleSystem>();

    }

    private void Update()
    {
        time += Time.deltaTime;
        SetTimeTxt();

        elapsedTime += Time.deltaTime;

        //매 10초마다 시간을 체크한다.
        if (elapsedTime >= 10f)
        {
            AddScore(100);
            elapsedTime = 0f;
        }
    }

    //시간 값을 받아온다.
    //10초마다, 즉 10의 배수일 때마다
    //100점씩 더한다.
    //시간도 UI에 표기한다.

    public void GameOver()
    {
        Time.timeScale = 0f; 
        //이거 말고 Update에서 처리할 수 있는 정지 방법이 있을 것. update timescale. 몬스터, 캐릭터, Ianimated 캐릭터들의 이동만 따로 
        //nowScore.text에 스코어 ToString()하기.
        endPanel.SetActive(true);
    }

    void SetTimeTxt()
    {
        timeTxt.text = time.ToString("N2");
    }
    
    public void AddScore(int Score)
    {
        score += Score;
        UpdateUI();
    }

    public void UpdateUI()
    {
        nowScore.text = score.ToString();
    }
}
