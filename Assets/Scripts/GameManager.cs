using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private string playerTag;
    public Transform Player;


    private void Awake()
    {
        if (Instance != null) Destroy(gameObject);
        Instance = this;

        Player = GameObject.FindGameObjectWithTag(playerTag).transform;
    }


    public GameObject road;
    public GameObject monster;
    public GameObject tree;

    // 스폰될 Y값
    Vector3 spawnPos1 = new Vector3(0, 0, 0);
    Vector3 spawnPos2 = new Vector3(0, 0, 0);

    List<int> spawnYPosList = new List<int>(); 
    List<int> spawnedRoadYPosList = new List<int>(); //몬스터 생성할 위치 찾기위해서 생성된 로드 위치 담아놓기

    private void Start()
    {
        MakeRoad();
        MakeMonster();
        MakeTree();
    }

    void MakeRoad()
    {
        int spawnAmount = Random.Range(4, 7); //스폰할 양(랜덤)
        spawnYPosList = new List<int> { -3, -2, -1, 0, 1, 2, 3, 4 }; //스폰될 Y위치값 int 배열

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
            Vector3 spawnPos = new Vector3(0, spawnedRoadYPos, 0);
            Instantiate(monster, spawnPos, Quaternion.identity); //생성 -> Invoke Reapeating으로 바뀌어야하나.
        }
    }

    void MakeTree()
    {
        int spawnAmount = Random.Range(8, 15); //스폰할 양(랜덤)
        List<int> spawnXPosList = new List<int> { -2, -1, 0, 1, 2 }; //스폰될 X위치값 int 배열
        List<Vector3> spawnPosList = new List<Vector3>();

        for (int i = 0; i < spawnAmount; i++)
        {
            int spawnXPos = spawnXPosList[Random.Range(0, spawnXPosList.Count)];//randomXPos에 랜덤하게 특정 스폰X값이 배정됨
            int spawnYPos = spawnYPosList[Random.Range(0, spawnYPosList.Count)]; //randomYPos에 랜덤하게 특정 스폰Y값이 배정됨
            Vector3 spawnPos = new Vector3(spawnXPos, spawnYPos, 0); //스폰 위치 세팅 

            if (spawnPosList.Contains(spawnPos))
            {
                continue;
            }
            spawnPosList.Add(spawnPos);
            Instantiate(tree, spawnPos, Quaternion.identity); //생성
        }
    }


}
