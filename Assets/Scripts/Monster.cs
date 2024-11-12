using UnityEngine;

public class Monster : MonoBehaviour
{
    public string targetTag;
    private CharacterAnimationController collidingTargetAnimController;

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

        if (!receiver.CompareTag(targetTag)) //닿은 애의 태그를 봤을 때 타겟태그가 아니라면 
        {
            return; //무시할겁니다.
        }

        collidingTargetAnimController = collision.gameObject.GetComponent<CharacterAnimationController>();
        if (collidingTargetAnimController != null)
        {
            collidingTargetAnimController.Hit();
        }
    }
}
