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
        GameObject receiver = collision.gameObject; //�����ָ� ���ù���� �ҰԿ�.

        if (!receiver.CompareTag(targetTag)) //���� ���� �±׸� ���� �� Ÿ���±װ� �ƴ϶�� 
        {
            return; //�����Ұ̴ϴ�.
        }

        collidingTargetAnimController = collision.gameObject.GetComponent<CharacterAnimationController>();
        if (collidingTargetAnimController != null)
        {
            collidingTargetAnimController.Hit();
        }
    }
}
