
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //[SerializeField] private GameObject road;
    //[SerializeField] private GameObject monster;
    //[SerializeField] private GameObject tree;
    //[SerializeField] private GameObject coin;


    // 스폰될 Y값
    Vector3 spawnPos1 = new Vector3(0, 0, 0);
    Vector3 spawnPos2 = new Vector3(0, 0, 0);

    List<int> spawnXPosList = new List<int> { -2, -1, 0, 1, 2 }; //스폰될 X위치값 int 배열
    List<int> spawnYPosList = new List<int> { -3, -2, -1, 0, 1, 2, 3}; //스폰될 Y위치값 int 배열
    List<int> spawnedRoadYPosList = new List<int>(); //몬스터 생성할 위치 찾기 위해서 생성된 로드 위치 담아놓기

    List<Vector3> objectSpawnPosList = new List<Vector3>(); //나무, 코인 오브젝트가 이미 생성된 위치 값을 저장해놓는 리스트 (이후 겹쳐서 생성되지 않도록 하기 위함)


    private void Start()
    {
        MakeRoad();
        MakeTree();
        MakeCoin();
        InvokeRepeating("MakeMonster", 1f, 5f);
    }

    void MakeRoad()
    {
        int spawnAmount = Random.Range(3, 5); //스폰할 양(랜덤)

        for (int i = 0; i < spawnAmount; i++) //스폰될 양만큼 반복하여 생성
        {
            int spawnYPos = spawnYPosList[Random.Range(0, spawnYPosList.Count)]; //randomYPos에 랜덤하게 특정 스폰Y값이 배정됨
            Vector3 spawnPos = new Vector3(0, spawnYPos, 0); //스폰 위치 세팅 
            spawnYPosList.Remove(spawnYPos); //위치값이 겹치지 않도록 배열에서 방금 쓴 값을 삭제. 
            GameObject road = GameManager.Instance.ObjectPool.SpawnFromPool("Road");
            road.transform.position = spawnPos;
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
            int spawnXPos = Random.Range(-6, -2); //원래 시간 차로 몬스터가 나와야하는데, 거리차를 통해 시간차로 나온듯이 보이도록 야매로 때우는 코드. 차후 리팩토링 필요
            spawnedRoadYPos = spawnedRoadYPosList[i];
            Vector3 spawnPos = new Vector3(spawnXPos, spawnedRoadYPos, 0);

            GameObject monster = GameManager.Instance.ObjectPool.SpawnFromPool("Monster");
            monster.transform.position = spawnPos;
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
            GameObject tree = GameManager.Instance.ObjectPool.SpawnFromPool("Tree");
            tree.transform.position = spawnPos;
        }
    }

    void MakeCoin()
    {
        int spawnAmount = Random.Range(10, 15); //스폰할 양(랜덤)

        for (int i = 0; i < spawnAmount; i++)
        {
            int spawnXPos = spawnXPosList[Random.Range(0, spawnXPosList.Count)]; //randomXPos에 랜덤하게 특정 스폰X값이 배정됨
            int spawnYPos = spawnYPosList[Random.Range(0, spawnYPosList.Count)]; //randomYPos에 랜덤하게 특정 스폰Y값이 배정됨
            Vector3 spawnPos = new Vector3(spawnXPos, spawnYPos, 0); //스폰 위치 세팅 

            if (objectSpawnPosList.Contains(spawnPos))
            {
                continue;
            }
            objectSpawnPosList.Add(spawnPos);
            GameObject coin = GameManager.Instance.ObjectPool.SpawnFromPool("Coin");
            coin.transform.position = spawnPos;
        }
        //문제가 있다. 이경우에는 컨티뉴로 건너뛰면 최소 스폰양을 채우지 못하게 될 수 있다.
        //do while쓰면 강제로 생성은 가능하게 함.
    }
}