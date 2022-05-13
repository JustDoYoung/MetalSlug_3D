using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject grenadeFactory;
    public Transform ThrowPosition;

    public GameObject defaultGunEffect;
    public GameObject heavyMachineGunEffect;
    public GameObject flameGunEffect;
    public GameObject shotGunEffect;
    public GameObject grenadeEffect;


    public enum GunState
    {
        defaultGun,
        heavyMachine,
        flameGun,
        shotGun,
        rocketLauncher
    }
    GunState gunState;

    private void Start()
    {
        gunState = GunState.defaultGun;
    }

    
    void Update()
    {

        

        if (Input.GetMouseButtonDown(0))
        {
            switch (gunState)
            {
                case GunState.defaultGun:
                    Instantiate(defaultGunEffect, ThrowPosition);
                    break;

                case GunState.heavyMachine:
                    Instantiate(heavyMachineGunEffect, ThrowPosition);
                    break;

                case GunState.flameGun:
                    Instantiate(flameGunEffect, ThrowPosition);
                    break;

                case GunState.shotGun:
                    Instantiate (shotGunEffect, ThrowPosition);
                    break;

            }
           
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (BulletManager.instance.defaultBombBullet > 0)
            {

                GameObject grenade = Instantiate(grenadeFactory);

                grenade.transform.position = ThrowPosition.position;

                grenade.transform.forward = ThrowPosition.forward;

                BulletManager.instance.defaultBombBullet--;
            }


        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.name == "HeavyMachinGun")
        {          
            if(gunState == GunState.heavyMachine)
            {
                BulletManager.instance.defaultHevyMachinGunBullet += 200;
            }
            gunState = GunState.heavyMachine;
        }

        if(other.name == "FlameGun")
        {
            if(gunState == GunState.flameGun)
            {
                BulletManager.instance.defaultFlameGunBullet += 30;
            }
            gunState= GunState.flameGun;
        }
        if(other.name == "ShotGun") 
        {
            if(gunState== GunState.shotGun)
            {
                BulletManager.instance.defaultShotGunBullet += 30;
            }
            gunState = GunState.shotGun;
        }
        if(other.name == "Rocket")
        {
            if(gunState == GunState.rocketLauncher)
            {
                BulletManager.instance.defaultRocketLauncherBullet += 30;
            }
            gunState = GunState.rocketLauncher;
        }
        if(other.name == "Bomb")
        {
            BulletManager.instance.defaultBombBullet += 10;
        }

        Destroy(other.gameObject);

    }
    
}
