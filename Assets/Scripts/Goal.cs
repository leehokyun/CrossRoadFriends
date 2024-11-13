using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Goal : MonoBehaviour
{
    public string playerTag;
    public GameObject particlePos;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(playerTag))
        {

            ParticleSystem particleSystem = GameManager.Instance.EffectParticle;

            particleSystem.transform.position = particlePos.transform.position;
            particleSystem.Play();
        }
    }
}
