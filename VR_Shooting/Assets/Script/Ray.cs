using UnityEngine;
using System.Collections.Generic;

public class NewMonoBehaviourScript : MonoBehaviour
{

    public float Range;
    public VRGun VRGun;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShootRay();
        Debug.DrawRay(VRGun.transform.position, VRGun.transform.forward * Range, Color.red);
    }

    public void ShootRay()
    { 
        RaycastHit hit;
        Physics.Raycast(VRGun.transform.position, VRGun.transform.forward, out hit, Range);
        Debug.Log(hit.transform.name);
    }
}
