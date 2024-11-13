using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DefaultMonsterSO", menuName = "TopDownController/Monsters/Default", order = 0)]
public class MonsterSO : ScriptableObject
{
    [Header("Monster Info")]
    public float speed;
    public float size;
    //public Animation animation;
    public Sprite sprite;
    public GameObject prefab;
}
