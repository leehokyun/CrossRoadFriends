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

    public GameObject endPanelUI;
    public GameObject hudUI;

    EndPanel endPanel;
    HudUI hud;

    public int score = 0;

    public float time = 0f;
    private float elapsedTime = 0f; // ��� �ð� ����
    public ParticleSystem EffectParticle;


    public ObjectPool ObjectPool { get; private set; }

    private void Awake()
    {
        if (Instance != null) Destroy(gameObject);
        Instance = this;

        Player = GameObject.FindGameObjectWithTag(playerTag).transform;

        EffectParticle = GameObject.FindGameObjectWithTag("Particle").gameObject.GetComponent<ParticleSystem>();
        ObjectPool = GetComponent<ObjectPool>();

        endPanel = endPanelUI.gameObject.GetComponent<EndPanel>();
        hud = hudUI.gameObject.GetComponent<HudUI>();
    }

    private void Start()
    {
        Time.timeScale = 1f;
    }

    private void Update()
    {
        time += Time.deltaTime;
        hud.SetTimeTxt(time);

        elapsedTime += Time.deltaTime;

        //�� 10�ʸ��� �ð��� üũ�Ѵ�.
        if (elapsedTime >= 10f)
        {
            AddScore(100);
            elapsedTime = 0f;
        }
    }

    public void GameOver()
    {
        //Time.timeScale = 0f;

        endPanel.SetPanel();
        endPanelUI.SetActive(true);
    }
        
    public void AddScore(int Score)
    {
        score += Score;
        hud.UpdateUI(score);
    }
}
