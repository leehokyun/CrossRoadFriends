using UnityEngine;

public class playerAnimationEvent : MonoBehaviour
{
    [SerializeField] private AudioClip foolStepClip;

    void GameOver()
    {
        GameManager.Instance.GameOver();
    }

    private void FootStepSound()
    {
        if(foolStepClip) SoundManager.PlayClip(foolStepClip);
    }
}
