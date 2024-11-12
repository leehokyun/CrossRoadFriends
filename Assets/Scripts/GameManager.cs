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

    void MakeRoad()
    {
        int spawnAmount = Random.Range(3, 6); //������ ��(����)
        List<int> spawnYPosList = new List<int> { -1, 0, 1, 2, 3, 4 }; //������ Y��ġ�� int �迭

        for (int i = 0; i < spawnAmount; i++) //������ �縸ŭ �ݺ��Ͽ� ����
        {
            int spawnYPos = spawnYPosList[Random.Range(0, spawnYPosList.Count)]; //randomYPos�� �����ϰ� Ư�� ����Y���� ������
            Vector3 spawnPos = new Vector3(0, spawnYPos, 0); //���� ��ġ ���� 
            spawnYPosList.Remove(spawnYPos); //��ġ���� ��ġ�� �ʵ��� �迭���� ��� �� ���� ����.
            Instantiate(road, spawnPos, Quaternion.identity); //����
        }
    }

    void MakeMonster()
    {
        Debug.Log("���ͻ���");
    }

    void MakeTree()
    {
        int spawnAmount = Random.Range(8, 15); //������ ��(����)
        List<int> spawnXPosList = new List<int> { -2, -1, 0, 1, 2 }; //������ X��ġ�� int �迭
        List<int> spawnYPosList = new List<int> { -1, 0, 1, 2, 3, 4 }; //������ Y��ġ�� int �迭
        List<Vector3> spawnPosList = new List<Vector3>();

        //��� ���: Dictionary ��ü ������ �����ϴ� for���� ����� -> �� ���� �ű⼭ ��ġ�� �� ����.

        for (int i = 0; i < spawnAmount; i++)
        {
            int spawnXPos = spawnXPosList[Random.Range(0, spawnXPosList.Count)];//randomXPos�� �����ϰ� Ư�� ����X���� ������
            int spawnYPos = spawnYPosList[Random.Range(0, spawnYPosList.Count)]; //randomYPos�� �����ϰ� Ư�� ����Y���� ������
            Vector3 spawnPos = new Vector3(spawnXPos, spawnYPos, 0); //���� ��ġ ���� 

            if (spawnPosList.Contains(spawnPos))
            {
                continue;
            }
            spawnPosList.Add(spawnPos);
            Instantiate(tree, spawnPos, Quaternion.identity); //����
        }
    }


}
