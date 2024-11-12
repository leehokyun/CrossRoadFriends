using UnityEngine;

public class Monster : MonoBehaviour
{
    public string targetPlayerTag;
    public string targetWallTag;
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

        if (receiver.CompareTag(targetPlayerTag)) //���� ���� �±׸� ���� �� Ÿ���±װ� �ƴ϶�� 
        {
            ColWithPlayer(receiver);
        }
        else if(receiver.CompareTag(targetWallTag))
        {
            Destroy(this.gameObject);
        }
        return; //�����Ұ̴ϴ�.
    }

    private void ColWithPlayer(GameObject go)
    {
        collidingTargetAnimController = go.gameObject.GetComponent<CharacterAnimationController>();
        if (collidingTargetAnimController != null)
        {
            collidingTargetAnimController.Hit();
        }
    }
}
