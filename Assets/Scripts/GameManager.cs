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


    // Road�� 3~5�� �����Ǿ���Ѵ�.(�Ϸ�)
        //Random range 3~5������ ������ŭ for���� ����. (�Ϸ�)
        //�� Ƚ����ŭ Road�� Instantiate�ȴ�. (�Ϸ�)

    // Road������ ��ġ ���� �޾ƿ;� �Ѵ�.(��������)
    // RoadPos�� Monster�� �����ȴ�. (Invoke Repeat)

    // Tree�� ������ ������ ��Ȳ�� ���ؼ��� ����ó���� �ؾ����� �ʳ�.


    private void Start()
    {
        MakeRoad();
        //MakeMonster();
        MakeTree();
    }

    void MakeRoad()
    {
        int spawnAmount = Random.Range(3, 6); //3�̻� 6�̸� Ƚ����ŭ ������ �ݺ��ȴ�.
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
        int spawnAmount = Random.Range(3, 6); //3�̻� 6�̸� Ƚ����ŭ ������ �ݺ��ȴ�.
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
    //    int spawnYPos1 = spawnYPosArr[Random.Range(0, spawnYPosArr.Length)]; //randomYPos������ spawnYPosArr�� �� ���� �������� �����

    //    spawnPos1 = new Vector3(0, spawnYPos1, 0);
    //}

}
