using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    public Gun gun;
    public GunType gunType;


    void Start()
    {
        //инициализируем стартовое оружие. По умолчанию пресет 1.      
        var gunPreset = new Gun1_preset();
        gunPreset.Initialize(gun); // интересно этот объект теперь в памяти? или где он?
        gun.SetGunPreset(gunPreset);
        gunType = GunType.SungleShoot;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Стреляем");
            gun.Shoot();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("Выбран пресет 1");
            gunType = GunType.SungleShoot;
            gun.SetGunPreset(new Gun1_preset());           

        } else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("Выбран пресет 2");
            gunType = GunType.SingleShoot_infinite;
            gun.SetGunPreset(new Gun2_preset());

        } else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("Выбран пресет 3");
            gunType = GunType.BurstShoot;
            gun.SetGunPreset(new Gun3_preset());
        }


    }
}
