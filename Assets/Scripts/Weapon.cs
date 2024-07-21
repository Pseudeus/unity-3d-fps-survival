using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Camera FPCamera;
    [SerializeField] private float range = 100f;
    [SerializeField] private byte damage = 15;
    [SerializeField] private ParticleSystem muzzleFlash;
    [SerializeField] private GameObject hitEffect;
    [SerializeField] private Ammo ammoSlot;

    private void Shot()
    {
        PlayMuzzleFlash();
        RayCasting();
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void RayCasting()
    {
        RaycastHit hit;
        bool hitSomething = Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range);

        if (hitSomething)
        {
            CreateHitImpactVfx(hit);

            var target = hit.transform.GetComponent<EnemyHealth>();

            target?.TakeDamage(damage);
        }
        return;
    }

    private void CreateHitImpactVfx(RaycastHit hit)
    {
        var hitVfx = Instantiate(hitEffect, hit.point, Quaternion.identity);

        Destroy (hitVfx, 0.5f);
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1") && ammoSlot.IsAmmoAvailable())
        {
            Shot();
            ammoSlot.ReduceAmmo();
        }
    }
}
