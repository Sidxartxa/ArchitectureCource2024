using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Gun: MonoBehaviour


{
   public GameObject _shootPoint; // точка, откуда будут вылетать пули. Пули будут лететь forward.
   public GameObject _bulletPrefab; // префаб пули
   public bool infiniteAmmo;
   public int maxAmmo = 100;
   public int currentAmmo; 


    private IShoot _gun_preset { get; set; }

    public void Start()
    {
        currentAmmo = maxAmmo;
    }


    public void Shoot()
    {
        _gun_preset.Shoot(_shootPoint, _bulletPrefab);        
        Debug.Log("Осталось патронов: " + currentAmmo);
    }

    public void RemoveAmmo(int num)
    {
        currentAmmo -= num;
    }

    public void SetGunPreset(IShoot gunPreset)
    {
        _gun_preset = gunPreset;
        gunPreset.Initialize(this);
    }
}


public interface IShoot 
{
   void Shoot(GameObject shootPoint, GameObject bulletPrefab);
   void Initialize(Gun gun);
}

public enum GunType
{
    SungleShoot,
    SingleShoot_infinite,
    BurstShoot
}