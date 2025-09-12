// Target.cs
using UnityEngine;

public class Target : MonoBehaviour
{
    public int scoreValue = 10;
    public GameManager gameManager;

    void Start()
    {
        if (gameManager == null) gameManager = FindObjectOfType<GameManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            gameManager?.AddScore(scoreValue);
            // play hit FX or animation here
            gameObject.SetActive(false);          // simple "destroy"
            Destroy(other.gameObject);            // remove bullet
        }
    }
}
