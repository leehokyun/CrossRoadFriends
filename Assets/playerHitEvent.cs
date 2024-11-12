using UnityEngine;

public class playerHitEvent : MonoBehaviour
{

    void GameOver()
    {
        GameManager.Instance.GameOver();
    }
}
