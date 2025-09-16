// VRGun.cs
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

[RequireComponent(typeof(XRGrabInteractable))]
public class VRGun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform muzzle;
    public float bulletSpeed = 40f;
    public AudioClip shootSfx;

    XRGrabInteractable grab;

    void Awake()
    {
        grab = GetComponent<XRGrabInteractable>();
        grab.selectEntered.AddListener(OnSelectEntered);
        grab.selectExited.AddListener(OnSelectExited);
        grab.activated.AddListener(OnActivated);
    }

    void OnSelectEntered(SelectEnterEventArgs args) { /* optional: visual change */ }
    void OnSelectExited(SelectExitEventArgs args) { /* optional */ }

    void OnActivated(ActivateEventArgs args)
    {
        Shoot();
    }

    void Shoot()
    {
        if (bulletPrefab == null || muzzle == null) return;
        var b = Instantiate(bulletPrefab, muzzle.position, Quaternion.Euler(-90f,0,0));
        var rb = b.GetComponent<Rigidbody>();
        if (rb != null) rb.linearVelocity = muzzle.forward * bulletSpeed;
        if (shootSfx != null) AudioSource.PlayClipAtPoint(shootSfx, muzzle.position);
    }

    void OnDestroy()
    {
        if (grab != null)
        {
            grab.selectEntered.RemoveListener(OnSelectEntered);
            grab.selectExited.RemoveListener(OnSelectExited);
            grab.activated.RemoveListener(OnActivated);
        }
    }
}
