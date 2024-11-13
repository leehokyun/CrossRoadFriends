using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinPoint = 10;
        
    public string playerTag;

    [SerializeField] private AudioClip coinSoundClip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag(playerTag))
        {
            CoinSound();
            GameManager.Instance.AddScore(coinPoint);
            Destroy(gameObject);
        }
    }

    private void CoinSound()
    {
        if (coinSoundClip) SoundManager.PlayClip(coinSoundClip);
    }

}
