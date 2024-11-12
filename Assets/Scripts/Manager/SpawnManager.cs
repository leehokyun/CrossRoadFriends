
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject road;
    public GameObject monster;
    public GameObject tree;
    public GameObject coin;

    // ������ Y��
    Vector3 spawnPos1 = new Vector3(0, 0, 0);
    Vector3 spawnPos2 = new Vector3(0, 0, 0);

    List<int> spawnXPosList = new List<int> { -2, -1, 0, 1, 2 }; //������ X��ġ�� int �迭
    List<int> spawnYPosList = new List<int> { -3, -2, -1, 0, 1, 2, 3}; //������ Y��ġ�� int �迭
    List<int> spawnedRoadYPosList = new List<int>(); //���� ������ ��ġ ã�� ���ؼ� ������ �ε� ��ġ ��Ƴ���

    List<Vector3> objectSpawnPosList = new List<Vector3>(); //����, ���� ������Ʈ�� �̹� ������ ��ġ ���� �����س��� ����Ʈ (���� ���ļ� �������� �ʵ��� �ϱ� ����)


    private void Start()
    {
        MakeRoad();
        MakeTree();
        MakeCoin();
        InvokeRepeating("MakeMonster", 1f, 5f);
    }

    void MakeRoad()
    {
        int spawnAmount = Random.Range(4, 7); //������ ��(����)

        for (int i = 0; i < spawnAmount; i++) //������ �縸ŭ �ݺ��Ͽ� ����
        {
            int spawnYPos = spawnYPosList[Random.Range(0, spawnYPosList.Count)]; //randomYPos�� �����ϰ� Ư�� ����Y���� ������
            Vector3 spawnPos = new Vector3(0, spawnYPos, 0); //���� ��ġ ���� 
            spawnYPosList.Remove(spawnYPos); //��ġ���� ��ġ�� �ʵ��� �迭���� ��� �� ���� ����. 
            Instantiate(road, spawnPos, Quaternion.identity); //����

            spawnedRoadYPosList.Add(spawnYPos); //���� ������ ��ġ ã�����ؼ� ������ �ε� ��ġ ��Ƴ���
        }

        //HAVE TO FIX:
        //����Ʈ�� �迭�� Ȱ���� Index���ٹ� Ȱ���ϱ�.(�迭 ��õ)
        //���� ����: spawnAMount�� �Ź� for���� ���ƾ��ϴ� ��ŭ�� ��ȿ�� 
        //������ ������ n�̴�. Index����� ���� 1�� �� �� �ִ�.(ȿ����)
    }

    void MakeMonster()
    {

        int spawnedRoadYPos;

        for (int i = 0; i < spawnedRoadYPosList.Count; i++)
        {
            int spawnXPos = Random.Range(-6, -2); //���� �ð� ���� ���Ͱ� ���;��ϴµ�, �Ÿ����� ���� �ð����� ���µ��� ���̵��� �߸ŷ� ����� �ڵ�. ���� �����丵 �ʿ�
            spawnedRoadYPos = spawnedRoadYPosList[i];
            Vector3 spawnPos = new Vector3(spawnXPos, spawnedRoadYPos, 0);
            Instantiate(monster, spawnPos, Quaternion.identity);
        }
    }

    void MakeTree()
    {
        int spawnAmount = Random.Range(8, 15); //������ ��(����)

        for (int i = 0; i < spawnAmount; i++)
        {
            int spawnXPos = spawnXPosList[Random.Range(0, spawnXPosList.Count)];//randomXPos�� �����ϰ� Ư�� ����X���� ������
            int spawnYPos = spawnYPosList[Random.Range(0, spawnYPosList.Count)]; //randomYPos�� �����ϰ� Ư�� ����Y���� ������
            Vector3 spawnPos = new Vector3(spawnXPos, spawnYPos, 0); //���� ��ġ ���� 

            if (objectSpawnPosList.Contains(spawnPos)) //������Ʈ���� ������ ��ġ���͵��� ����Ʈ�� üũ�ѵ�, �̹� ����Ʈ�� �ִٸ� ���� for������.
            {
                continue;
            }
            objectSpawnPosList.Add(spawnPos);
            Instantiate(tree, spawnPos, Quaternion.identity); //����
        }
    }

    void MakeCoin()
    {
        int spawnAmount = Random.Range(5, 15); //������ ��(����)

        for (int i = 0; i < spawnAmount; i++)
        {
            int spawnXPos = spawnXPosList[Random.Range(0, spawnXPosList.Count)]; //randomXPos�� �����ϰ� Ư�� ����X���� ������
            int spawnYPos = spawnYPosList[Random.Range(0, spawnYPosList.Count)]; //randomYPos�� �����ϰ� Ư�� ����Y���� ������
            Vector3 spawnPos = new Vector3(spawnXPos, spawnYPos, 0); //���� ��ġ ���� 

            if (objectSpawnPosList.Contains(spawnPos))
            {
                continue;
            }
            objectSpawnPosList.Add(spawnPos);
            Instantiate(coin, spawnPos, Quaternion.identity); //����
        }
        //������ �ִ�. �̰�쿡�� ��Ƽ���� �ǳʶٸ� �ּ� �������� ä���� ���ϰ� �� �� �ִ�.
        //do while���� ������ ������ �����ϰ� ��.
    }
}