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

    public GameObject road;
    public GameObject monster;
    public GameObject tree;
    public GameObject coin;

    // 스폰될 Y값
    Vector3 spawnPos1 = new Vector3(0, 0, 0);
    Vector3 spawnPos2 = new Vector3(0, 0, 0);

    List<int> spawnXPosList = new List<int> { -2, -1, 0, 1, 2 }; //스폰될 X위치값 int 배열
    List<int> spawnYPosList = new List<int> { -3, -2, -1, 0, 1, 2, 3, 4 }; //스폰될 Y위치값 int 배열
    List<int> spawnedRoadYPosList = new List<int>(); //몬스터 생성할 위치 찾기 위해서 생성된 로드 위치 담아놓기

    List<Vector3> objectSpawnPosList = new List<Vector3>(); //나무, 코인 오브젝트가 이미 생성된 위치 값을 저장해놓는 리스트 (이후 겹쳐서 생성되지 않도록 하기 위함)

    public GameObject endPanel;
    public TextMeshProUGUI nowScore;

    public int score = 0;

    private void Awake()
    {
        if (Instance != null) Destroy(gameObject);
        Instance = this;

        Player = GameObject.FindGameObjectWithTag(playerTag).transform;
    }


    private void Start()
    {
        MakeRoad();
        MakeMonster();
        MakeTree();
        MakeCoin();
    }

    void MakeRoad()
    {
        int spawnAmount = Random.Range(4, 7); //스폰할 양(랜덤)

        for (int i = 0; i < spawnAmount; i++) //스폰될 양만큼 반복하여 생성
        {
            int spawnYPos = spawnYPosList[Random.Range(0, spawnYPosList.Count)]; //randomYPos에 랜덤하게 특정 스폰Y값이 배정됨
            Vector3 spawnPos = new Vector3(0, spawnYPos, 0); //스폰 위치 세팅 
            spawnYPosList.Remove(spawnYPos); //위치값이 겹치지 않도록 배열에서 방금 쓴 값을 삭제. 
            Instantiate(road, spawnPos, Quaternion.identity); //생성

            spawnedRoadYPosList.Add(spawnYPos); //몬스터 생성할 위치 찾기위해서 생성된 로드 위치 담아놓기
        }

        //HAVE TO FIX:
        //리스트나 배열을 활용해 Index접근법 활용하기.(배열 추천)
        //현재 문제: spawnAMount가 매번 for문을 돌아야하는 만큼의 비효율 
        //계산식이 지금은 n이다. Index방식을 쓰면 1이 될 수 있다.(효율적)
    }

    void MakeMonster()
    {

        int spawnedRoadYPos;

        for (int i = 0; i < spawnedRoadYPosList.Count; i++)
        {
            spawnedRoadYPos = spawnedRoadYPosList[i];
            Vector3 spawnPos = new Vector3(-3, spawnedRoadYPos, 0);
            Instantiate(monster, spawnPos, Quaternion.identity); //생성 -> Invoke Reapeating으로 바뀌어야하나.
        }
    }

    void MakeTree()
    {
        int spawnAmount = Random.Range(8, 15); //스폰할 양(랜덤)

        for (int i = 0; i < spawnAmount; i++)
        {
            int spawnXPos = spawnXPosList[Random.Range(0, spawnXPosList.Count)];//randomXPos에 랜덤하게 특정 스폰X값이 배정됨
            int spawnYPos = spawnYPosList[Random.Range(0, spawnYPosList.Count)]; //randomYPos에 랜덤하게 특정 스폰Y값이 배정됨
            Vector3 spawnPos = new Vector3(spawnXPos, spawnYPos, 0); //스폰 위치 세팅 

            if (objectSpawnPosList.Contains(spawnPos)) //오브젝트들이 생성된 위치벡터들의 리스트를 체크한뒤, 이미 리스트에 있다면 다음 for문으로.
            {
                continue;
            }
            objectSpawnPosList.Add(spawnPos);
            Instantiate(tree, spawnPos, Quaternion.identity); //생성
        }
    }

    void MakeCoin()
    {
        int spawnAmount = Random.Range(5, 15); //스폰할 양(랜덤)

        for (int i = 0; i < spawnAmount; i++)
        {
            int spawnXPos = spawnXPosList[Random.Range(0, spawnXPosList.Count)];//randomXPos에 랜덤하게 특정 스폰X값이 배정됨
            int spawnYPos = spawnYPosList[Random.Range(0, spawnYPosList.Count)]; //randomYPos에 랜덤하게 특정 스폰Y값이 배정됨
            Vector3 spawnPos = new Vector3(spawnXPos, spawnYPos, 0); //스폰 위치 세팅 

            if (objectSpawnPosList.Contains(spawnPos))
            {
                continue;
            }
            objectSpawnPosList.Add(spawnPos);
            Instantiate(coin, spawnPos, Quaternion.identity); //생성
        }
        //문제가 있다. 이경우에는 컨티뉴로 건너뛰면 최소 스폰양을 채우지 못하게 될 수 있다.
        
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
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
