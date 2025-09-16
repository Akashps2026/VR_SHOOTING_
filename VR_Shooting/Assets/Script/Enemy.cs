using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.XR.CoreUtils;

public class Enemy : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private XROrigin player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Start()
    {
        player = FindObjectOfType<XROrigin>();
    }
}
