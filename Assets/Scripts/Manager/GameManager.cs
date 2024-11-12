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
        //�̰� ���� Update���� ó���� �� �ִ� ���� ����� ���� ��. update timescale. ����, ĳ����, Ianimated ĳ���͵��� �̵��� ���� 
        //nowScore.text�� ���ھ� ToString()�ϱ�.
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
