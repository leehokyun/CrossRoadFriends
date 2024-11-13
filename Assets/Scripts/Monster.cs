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
