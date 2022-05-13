using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public static BulletManager instance;
    private void Awake()
    {
        instance = this;
    }

    public int defaultHevyMachinGunBullet;
    public int defaultShotGunBullet;
    public int defaultFlameGunBullet;
    public int defaultBombBullet;
    public int defaultRocketLauncherBullet;



    // Start is called before the first frame update
    void Start()
    {
        defaultHevyMachinGunBullet = 200;
        defaultShotGunBullet = 30;
        defaultFlameGunBullet = 30;
        defaultRocketLauncherBullet = 30;
        defaultBombBullet = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
