using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject grenadeFactory;
    public Transform ThrowPosition;

   

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
                    GameObject dgBUllet = BulletManager.instance.MakeObj("DefaultGun");
                    dgBUllet.transform.position = ThrowPosition.position;
                    break;

                case GunState.heavyMachine:
                    BulletManager.instance.defaultHevyMachinGunBullet--;
                    GameObject hmBullet = BulletManager.instance.MakeObj("HeavyMachinGun");
                    hmBullet.transform.position = ThrowPosition.position;
                    
                    break;

                case GunState.flameGun:
                    BulletManager.instance.defaultFlameGunBullet--;
                    
                    break;

                case GunState.shotGun:
                    BulletManager.instance.defaultShotGunBullet--;
                    break;

                case GunState.rocketLauncher:
                    BulletManager.instance.defaultRocketLauncherBullet--;
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
            
            BulletManager.instance.defaultHevyMachinGunBullet += 200;            
            gunState = GunState.heavyMachine;
        }

        if(other.name == "FlameGun")
        {
           
            BulletManager.instance.defaultFlameGunBullet += 30;            
            gunState= GunState.flameGun;
        }
        if(other.name == "ShotGun") 
        {
            
            BulletManager.instance.defaultShotGunBullet += 30;            
            gunState = GunState.shotGun;
        }
        if(other.name == "Rocket")
        {
            
            BulletManager.instance.defaultRocketLauncherBullet += 30;           
            gunState = GunState.rocketLauncher;
        }
        if(other.name == "Bomb")
        {
            BulletManager.instance.defaultBombBullet += 10;
        }

        Destroy(other.gameObject);

    }
    
}
