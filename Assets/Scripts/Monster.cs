using UnityEngine;

public class Monster : MonoBehaviour
{
    public string targetPlayerTag;
    public string targetWallTag;
    private CharacterAnimationController collidingTargetAnimController;

    [SerializeField] private AudioClip hitSoundClip;

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        transform.position += Vector3.right * 0.01f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject receiver = collision.gameObject; //�����ָ� ���ù���� �ҰԿ�.

        if (receiver.CompareTag(targetPlayerTag)) //���� ���� �±׸� ���� �� Ÿ���±װ� �ƴ϶�� 
        {
            ColWithPlayer(receiver);
        }
        else if(receiver.CompareTag(targetWallTag))
        {
            gameObject.SetActive(false);
        }
        return; //�����Ұ̴ϴ�.
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
