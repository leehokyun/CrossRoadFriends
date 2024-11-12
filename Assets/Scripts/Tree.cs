using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public string targetTag;

    private CharacterAnimationController collidingTargetAnimController;

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