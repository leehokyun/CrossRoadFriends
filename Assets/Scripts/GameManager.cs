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

    // ������ Y��
    Vector3 spawnPos1 = new Vector3(0, 0, 0);
    Vector3 spawnPos2 = new Vector3(0, 0, 0);

    List<int> spawnYPosList = new List<int>(); 
    List<int> spawnedRoadYPosList = new List<int>(); //���� ������ ��ġ ã�����ؼ� ������ �ε� ��ġ ��Ƴ���

    private void Start()
    {
        MakeRoad();
        MakeMonster();
        MakeTree();
    }

    void MakeRoad()
    {
        int spawnAmount = Random.Range(4, 7); //������ ��(����)
        spawnYPosList = new List<int> { -3, -2, -1, 0, 1, 2, 3, 4 }; //������ Y��ġ�� int �迭

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
            spawnedRoadYPos = spawnedRoadYPosList[i];
            Vector3 spawnPos = new Vector3(0, spawnedRoadYPos, 0);
            Instantiate(monster, spawnPos, Quaternion.identity); //���� -> Invoke Reapeating���� �ٲ����ϳ�.
        }
    }

    void MakeTree()
    {
        int spawnAmount = Random.Range(8, 15); //������ ��(����)
        List<int> spawnXPosList = new List<int> { -2, -1, 0, 1, 2 }; //������ X��ġ�� int �迭
        List<Vector3> spawnPosList = new List<Vector3>();

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
