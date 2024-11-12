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
        //spawnYPos�� ��ġ�� �ʾƾ��Ѵ�. �׷������ؼ��� �迭������ �ѹ� �������� ���ŵǾ���Ѵ�.


    // Road������ ��ġ ���� �޾ƿ;� �Ѵ�.(��������)
    // RoadPos�� Monster�� �����ȴ�. (Invoke Repeat)

    // Tree�� ������ ������ ��Ȳ�� ���ؼ��� ����ó���� �ؾ����� �ʳ�.


    private void Start()
    {
        MakeRoad();
        //MakeMonster();
        MakeTree();
    }

    //void MakeRoad()
    //{
    //    int spawnAmount = Random.Range(3, 6); //3�̻� 6�̸� Ƚ����ŭ ������ �ݺ��ȴ�.
    //    for (int i = 0; i < spawnAmount; i++)
    //    {
    //        int[] spawnYPosArr = new int[] { -1, 0, 1, 2, 3, 4 };
    //        Vector3[] spawnPosArr = new Vector3[spawnAmount];

    //        for (int j = 0; j < spawnYPosArr.Length; j++)
    //        {
    //            int spawnYPos = spawnYPosArr[Random.Range(0, spawnYPosArr.Length)]; //randomYPos������ spawnYPosArr�� �� ���� �������� �����
    //            Vector3 spawnPos = new Vector3(0, spawnYPos, 0);
    //            spawnPosArr[j] = spawnPos;
    //            Instantiate(road, spawnPosArr[j], Quaternion.identity);
    //        }
    //    }
    //}
    void MakeRoad()
    {
        int spawnAmount = Random.Range(3, 6); //������ ��(����)
        List<int> spawnYPosList = new List<int> { -1, 0, 1, 2, 3, 4 }; //������ Y��ġ�� int �迭

        for (int j = 0; j < spawnAmount; j++) //������ �縸ŭ �ݺ��Ͽ� ����
        {
            int spawnYPos = spawnYPosList[Random.Range(0, spawnYPosList.Count)]; //randomYPos�� �����ϰ� Ư�� ����Y���� ������
            Vector3 spawnPos = new Vector3(0, spawnYPos, 0); //���� ��ġ ���� 
            spawnYPosList.Remove(spawnYPos); //��ġ���� ��ġ�� �ʵ��� �迭���� ���� ����.
            Instantiate(road, spawnPos, Quaternion.identity); //����
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
