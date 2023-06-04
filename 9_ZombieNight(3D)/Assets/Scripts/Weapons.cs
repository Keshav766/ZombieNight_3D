using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    [SerializeField] Camera fpCamera;
    [SerializeField] float rayRange = 100f;
    [SerializeField] float bulletDamage = 20f;
    [SerializeField] ParticleSystem muzzleParticles;
    [SerializeField] GameObject bulletImpactParticles;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        ProcessParticles();
        ProcessRaycast();
    }

    void ProcessParticles()
    {
        muzzleParticles.Play();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpCamera.transform.position, fpCamera.transform.forward, out hit, rayRange))
        {
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            CreateHitImpact(hit);
            if (target == null) { return; }
            target.TakeDamage(bulletDamage);
        }
        else
        {
            return;
        }
    }

    void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(bulletImpactParticles, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 0.5f);
    }
}
