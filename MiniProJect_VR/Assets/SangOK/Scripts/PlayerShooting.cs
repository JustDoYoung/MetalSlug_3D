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
        shotGun
    }
    GunState gunState;

    private void Start()
    {
        gunState = GunState.flameGun;
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
            
            GameObject grenade = Instantiate(grenadeFactory);
            
            grenade.transform.position = ThrowPosition.position;
            
            grenade.transform.forward = ThrowPosition.forward;




        }
    }
}
