using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Start()
    {
        player = GameObject.Find("XR Origin (XR Rig)");
    }

    private void Update()
    {
        navMeshAgent.destination = player.transform.position;
    }
}
