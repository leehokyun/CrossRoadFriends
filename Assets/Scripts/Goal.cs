using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Goal : MonoBehaviour
{
    public string playerTag;
    public GameObject particlePos;


    [SerializeField] private AudioClip goalSoundClip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(playerTag))
        {

            ParticleSystem particleSystem = GameManager.Instance.EffectParticle;

            particleSystem.transform.position = particlePos.transform.position;
            ParticleSystem.EmissionModule em = particleSystem.emission;
            em.SetBurst(0, new ParticleSystem.Burst(0, 10));
            particleSystem.Play();
            GoalSound();
        }
    }


    private void GoalSound()
    {
        if (goalSoundClip) SoundManager.PlayClip(goalSoundClip);
    }
}

