using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public GameObject road;
    public GameObject monster;
    public GameObject tree;

    // 스폰될 Y값
    Vector3 spawnPos1 = new Vector3(0, 0, 0);
    Vector3 spawnPos2 = new Vector3(0, 0, 0);
    //Transform spawnTransform;


    // Road가 3~5개 생성되어야한다.(완료)
        //Random range 3~5사이의 변수만큼 for문이 돈다. (완료)
        //그 횟수만큼 Road가 Instantiate된다. (완료)

    // Road마다의 위치 값을 받아와야 한다.(전역변수)
    // RoadPos에 Monster가 생성된다. (Invoke Repeat)

    // Tree로 한줄이 꽉차는 상황에 대해서도 예외처리를 해야하지 않나.


    private void Start()
    {
        MakeRoad();
        //MakeMonster();
        MakeTree();
    }

    void MakeRoad()
    {
        int spawnAmount = Random.Range(3, 6); //3이상 6미만 횟수만큼 생성이 반복된다.
        for (int i = 0; i < spawnAmount; i++)
        {
            int spawnYPos = Random.Range(-1, 5);
            Vector3 spawnPos = new Vector3(0, spawnYPos, 0);
            Instantiate(road, spawnPos, Quaternion.identity);
        }
    }

    //void MakeMonster()
    //{
    //    SetSpawnPos();
    //    Instantiate(monster, spawnPos1, Quaternion.identity);
    //}

    void MakeTree()
    {
        int spawnAmount = Random.Range(3, 6); //3이상 6미만 횟수만큼 생성이 반복된다.
        for (int i = 0; i < spawnAmount; i++)
        {
            int spawnYPos = Random.Range(-1, 5);
            int spawnXPos = Random.Range(-2, 3);
            Vector3 spawnPos = new Vector3(spawnXPos, spawnYPos, 0);
            Instantiate(tree, spawnPos, Quaternion.identity);
        }
    }

    //void SetSpawnPos()
    //{
    //    int[] spawnYPosArr = new int[] { -1, 0, 1, 2, 3, 4 };
    //    int spawnYPos1 = spawnYPosArr[Random.Range(0, spawnYPosArr.Length)]; //randomYPos변수에 spawnYPosArr중 한 값이 랜덤으로 저장됨

    //    spawnPos1 = new Vector3(0, spawnYPos1, 0);
    //}

}
