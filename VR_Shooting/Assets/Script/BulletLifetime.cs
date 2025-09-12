// BulletLifetime.cs
using UnityEngine;

public class BulletLifetime : MonoBehaviour
{
    void Start() => Destroy(gameObject, 5f); // auto cleanup
}
