using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public static BulletManager instance;
    private void Awake()
    {
        instance = this;

        dfBullet = new GameObject[50];
        hMBullet = new GameObject[200];
        fgBullet = new GameObject[30];
        sgBullet = new GameObject[30];
        rlBullet = new GameObject[30];
        grBullet = new GameObject[10];

        CreateInstance();

    }

    PlayerShooting ps;

    public int defaultHevyMachinGunBullet;
    public int defaultShotGunBullet;
    public int defaultFlameGunBullet;
    public int defaultBombBullet;
    public int defaultRocketLauncherBullet;


    public GameObject defaultGunEffect;
    public GameObject heavyMachineGunEffect;
    public GameObject flameGunEffect;
    public GameObject shotGunEffect;
    public GameObject rocketLauncherEffect;
    public GameObject grenadeEffect;

    GameObject[] dfBullet;
    GameObject[] hMBullet;
    GameObject[] fgBullet;
    GameObject[] sgBullet;
    GameObject[] rlBullet;
    GameObject[] grBullet;

    public GameObject[] targetPool;


    public Transform dfParent;
    public Transform hmParent;
    public Transform fgParent;
    public Transform sgParent;
    public Transform rlParent;
    public Transform grParent;
    


    



    // Start is called before the first frame update
    void Start()
    {
        defaultHevyMachinGunBullet = 0;
        defaultShotGunBullet = 0;
        defaultFlameGunBullet = 0;
        defaultRocketLauncherBullet = 0;
        defaultBombBullet = 10;
    }


    public void CreateInstance()
    {
        for (int i = 0; i < dfBullet.Length; i++)
        {
            GameObject defaultbullet = Instantiate(defaultGunEffect);
            defaultbullet.transform.parent = dfParent;
            dfBullet[i] = defaultbullet;
            defaultbullet.SetActive(false);
        }

        for (int i = 0; i < hMBullet.Length; i++)
        {
            GameObject heavyMachingunBullet = Instantiate(heavyMachineGunEffect);
            heavyMachingunBullet.transform.parent = hmParent;
            hMBullet[i] = heavyMachingunBullet;
            heavyMachingunBullet.SetActive(false);
        }

        for (int i = 0; i < sgBullet.Length; i++)
        {
            GameObject shotGunBullet = Instantiate(shotGunEffect);
            shotGunBullet.transform.parent = sgParent;
            sgBullet[i] = shotGunBullet;
            shotGunBullet.SetActive(false);
        }

        for (int i = 0; i < fgBullet.Length; i++)
        {
            GameObject flameGunBullet = Instantiate(flameGunEffect);
            flameGunBullet.transform.parent = fgParent;
            fgBullet[i] = flameGunBullet;
            flameGunBullet.SetActive(false);
        }

        for (int i = 0; i < rlBullet.Length; i++)
        {
            GameObject rocketLauncherBullet = Instantiate(rocketLauncherEffect);
            rocketLauncherBullet.transform.parent = rlParent;
            rlBullet[i] = rocketLauncherBullet;
            rocketLauncherBullet.SetActive(false);
        }

        for (int i = 0; i < grBullet.Length; i++)
        {
            GameObject BombBullet = Instantiate(grenadeEffect);
            BombBullet.transform.parent = grParent;
            grBullet[i] = BombBullet;
            BombBullet.SetActive(false);
        }

    }
    public GameObject MakeObj(string name)
    {
        
        switch (name)
        {
            case "DefaultGun":
                targetPool = dfBullet;
                break;

            case "HeavyMachinGun":
                targetPool = hMBullet;
                break;

            case "FlameGun":
                targetPool = fgBullet;
                break;

            case "ShotGun":
                targetPool = sgBullet;
                break;

            case "RocketLauncher":
                targetPool = rlBullet;
                break;

            case "Grenade":
                targetPool = grBullet;
                break;
        }
        for(int i = 0; i < targetPool.Length; i++)
        {
            if (!targetPool[i].activeSelf)
            {
                targetPool[i].SetActive(true);
                return targetPool[i];
            }
        }
        return null;
    }


    // Update is called once per frame
    void Update()
        {

        }
    
}

     //        string key = prefabName;

//        bulletFactory = Resources.Load<GameObject>("Prefabs/" + prefabName);
//        // �̸� maxCount��ŭ �������� ��Ȱ��ȭ �ϰ�ʹ�.
//        // ��Ͽ� ��Ƴ���ʹ�.
//        for (int i = 0; i < amount; i++)
//        {
//            GameObject bullet = Instantiate(bulletFactory);
//            bullet.transform.parent = parent;
//            bullet.name = key;
//            bullet.SetActive(false);
//            // ���� list�� key�� �������� �ʴ´ٸ� 
//            if (false == list.ContainsKey(key))
//            {
//                // key�� value�� �߰��ϰ�ʹ�.
//                list.Add(key, new List<GameObject>());
//                inActiveList.Add(key, new List<GameObject>());
//            }

//            list[key].Add(bullet);
//            inActiveList[key].Add(bullet);
//        }
//    }

//public GameObject GetInactiveBullet(string key)
//{
//    if (false == inActiveList.ContainsKey(key))
//    {
//        return null;
//    }
//    // ���� ��Ȱ������� 0�� ���� ũ�ٸ�
//    if (inActiveList[key].Count > 0)
//    {
//        //  ��Ȱ������� ù��° �Ѿ��� Ȱ��ȭ�ϰ�
//        inActiveList[key][0].SetActive(true);
//        GameObject temp = inActiveList[key][0];
//        //  ��Ȱ����Ͽ��� �����ϰ�
//        inActiveList[key].RemoveAt(0);
//        //  ��ȯ�ϰ�ʹ�.
//        return temp;
//    }
//    // �׷����ʴٸ�(���� ��Ȱ������� 0�����)        //  null�� ��ȯ�ϰ�ʹ�.

//    GameObject bullet = Instantiate(bulletFactory);
//    bullet.transform.parent = list[key][0].transform.parent;
//    bullet.name = key;
//    list[key].Add(bullet);
//    bullet.SetActive(true);
//    return bullet;
//}

//public void AddInactiveList(GameObject obj)
//{
//    obj.SetActive(false);
//    string key = obj.name;
//    if (inActiveList.ContainsKey(key))
//    {
//        if (false == inActiveList[key].Contains(obj))
//        {
//            inActiveList[key].Add(obj);
//        }
//    }
//}

//public static bool IsObjectPoolObject(GameObject obj)
//{
//    string key = obj.name;
//    if (BulletManager.instance.list.ContainsKey(key))
//    {
//        return BulletManager.instance.list[key].Contains(obj);
//    }

//    return false;
//}



