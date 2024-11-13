using System.Collections.Generic;
using UnityEngine;
public class Monster : MonoBehaviour
{
    public MonsterSO[] monsterSOArr;
    public MonsterSO monsterSO;
    private float speed;

    Animator animator;
    
    public string targetPlayerTag;
    public string targetWallTag;
    private CharacterAnimationController collidingTargetAnimController;

    [SerializeField] private AudioClip hitSoundClip;

    void SetMonsterType()
    {
        int probability = Random.Range(0, 100);

        switch(probability / 10)
        {
            case 10:
            case 9:
            case 8:
                monsterSO = monsterSOArr[2]; //hell
                break;
            case 7:
            case 6:
            case 5:
                monsterSO = monsterSOArr[1]; //hard
                break;
            default:
                monsterSO = monsterSOArr[0]; //normal
                break;
        }
    }

    private void Awake()
    {
        SetMonsterType();
        Sprite sprite = GetComponent<Sprite>();

        animator = GetComponentInChildren<Animator>();
        animator.runtimeAnimatorController = monsterSO.animator;

        sprite = monsterSO.sprite;
        gameObject.transform.localScale *= monsterSO.size;
        speed = monsterSO.speed;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        transform.position += Vector3.right * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject receiver = collision.gameObject; //닿은애를 리시버라고 할게요.

        if (receiver.CompareTag(targetPlayerTag)) //닿은 애의 태그를 봤을 때 타겟태그가 아니라면 
        {
            ColWithPlayer(receiver);
        }
        else if(receiver.CompareTag(targetWallTag))
        {
            gameObject.SetActive(false);
        }
        return; //무시할겁니다.
    }

    private void ColWithPlayer(GameObject go)
    {
        collidingTargetAnimController = go.gameObject.GetComponent<CharacterAnimationController>();
        if (collidingTargetAnimController != null)
        {
            collidingTargetAnimController.Hit();
            HitSound();
        }
    }

    private void HitSound()
    {
        if (hitSoundClip) SoundManager.PlayClip(hitSoundClip);
    }
}
