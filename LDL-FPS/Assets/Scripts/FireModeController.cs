using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireModeController : MonoBehaviour
{
    public bool onCooldown;

    private GunController gun;

    private void Start()
    {
        gun = GetComponentInChildren<GunController>();
        onCooldown = false;
    }
    private void Update()
    {
        
    }

    public void RapidFire()
    {
        gun.Shoot();
        StartCoroutine(FireCooldown(gun.fireRate));

    }

    public IEnumerator FireCooldown(float fireRate)
    {
        onCooldown = true;
        yield return new WaitForSeconds(fireRate);
        onCooldown = false;
    }

    private void OnEnable()
    {
    }
    private void OnDisable()
    {
        
    }

}
