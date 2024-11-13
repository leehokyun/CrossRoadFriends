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
    private float elapsedTime = 0f; // ��� �ð� ����
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

        //�� 10�ʸ��� �ð��� üũ�Ѵ�.
        if (elapsedTime >= 10f)
        {
            AddScore(100);
            elapsedTime = 0f;
        }
    }

    //�ð� ���� �޾ƿ´�.
    //10�ʸ���, �� 10�� ����� ������
    //100���� ���Ѵ�.
    //�ð��� UI�� ǥ���Ѵ�.

    public void GameOver()
    {
        Time.timeScale = 0f; 
        //�̰� ���� Update���� ó���� �� �ִ� ���� ����� ���� ��. update timescale. ����, ĳ����, Ianimated ĳ���͵��� �̵��� ���� 
        //nowScore.text�� ���ھ� ToString()�ϱ�.
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
