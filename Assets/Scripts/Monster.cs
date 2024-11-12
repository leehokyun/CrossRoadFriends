using UnityEngine;

public class Monster : MonoBehaviour
{

    private void Update()
    {
        Move();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.GameOver();
        }
    }

    private void Move()
    {
        transform.position += Vector3.right * 0.01f;
    }
}
