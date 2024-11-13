using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public string targetTag;

    private CharacterAnimationController collidingTargetAnimController;

    [SerializeField] private AudioClip hitSoundClip;

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
            HitSound();
        }
    }


    private void HitSound()
    {
        if (hitSoundClip) SoundManager.PlayClip(hitSoundClip);
    }
}