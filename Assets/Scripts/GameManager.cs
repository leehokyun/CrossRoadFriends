using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public GameObject road;
    public GameObject monster;
    public GameObject tree;

    // ������ Y��
    Vector3 spawnPos1 = new Vector3(0, 0, 0);
    Vector3 spawnPos2 = new Vector3(0, 0, 0);
    //Transform spawnTransform;


    // Road�� 3~5�� �����Ǿ���Ѵ�.
        //Random range 3~5������ ������ŭ for���� ����.
        //�� Ƚ����ŭ Instantiate�ȴ�.

    // Road������ ��ġ ���� �޾ƿ;� �Ѵ�.
    // RoadPos�� Monster�� �����ȴ�.


    private void Start()
    {
        MakeRoad();
        MakeMonster();
        MakeTree();
    }

    void SetSpawnPos()
    {
        int[] spawnYPosArr = new int[] {-1, 0, 1, 2, 3, 4 };
        int spawnYPos1 = spawnYPosArr[Random.Range(0,spawnYPosArr.Length)]; //randomYPos������ spawnYPosArr�� �� ���� �������� �����
        int spawnYPos2 = spawnYPosArr[Random.Range(0, spawnYPosArr.Length)]; //randomYPos������ spawnYPosArr�� �� ���� �������� �����
        
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
