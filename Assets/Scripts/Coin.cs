using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinPoint = 10;
        
    public string playerTag;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag(playerTag))
        {
            GameManager.Instance.AddScore(coinPoint);
            Destroy(gameObject);
        }
    }
}
