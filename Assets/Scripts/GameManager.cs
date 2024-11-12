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


    // Road가 3~5개 생성되어야한다.
        //Random range 3~5사이의 변수만큼 for문이 돈다.
        //그 횟수만큼 Instantiate된다.

    // Road마다의 위치 값을 받아와야 한다.
    // RoadPos에 Monster가 생성된다.


    private void Start()
    {
        MakeRoad();
        MakeMonster();
        MakeTree();
    }

    void SetSpawnPos()
    {
        int[] spawnYPosArr = new int[] {-1, 0, 1, 2, 3, 4 };
        int spawnYPos1 = spawnYPosArr[Random.Range(0,spawnYPosArr.Length)]; //randomYPos변수에 spawnYPosArr중 한 값이 랜덤으로 저장됨
        int spawnYPos2 = spawnYPosArr[Random.Range(0, spawnYPosArr.Length)]; //randomYPos변수에 spawnYPosArr중 한 값이 랜덤으로 저장됨
        
        spawnPos1 = new Vector3(0, spawnYPos1, 0);
        spawnPos2 = new Vector3(0, spawnYPos2, 0);
    }

    void MakeRoad()
    {
        SetSpawnPos();
        Instantiate(road, spawnPos1, Quaternion.identity);
        Instantiate(road, spawnPos2, Quaternion.identity);

    }

    void MakeMonster()
    {
        SetSpawnPos();
        Instantiate(monster, spawnPos1, Quaternion.identity);
        Instantiate(monster, spawnPos2, Quaternion.identity);
    }

    void MakeTree()
    {
        SetSpawnPos();
        Instantiate(tree, spawnPos1, Quaternion.identity);
        Instantiate(tree, spawnPos2, Quaternion.identity);
    }
}
