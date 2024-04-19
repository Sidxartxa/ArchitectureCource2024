using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun3_preset : IShoot
{

    private Gun _gun;
    private int BulletNum = 3; // количество пуль за выстрел

    public void Initialize(Gun _gun)
    {
        this._gun = _gun;
    }

    public void Shoot(GameObject _shootPoint, GameObject _bulletPrefab)
    {

        if (_gun.currentAmmo <= 0)
        {
            Debug.Log("Пуль больше нет");
            return;
        }
        else
        {
            for (int i = 0; i < BulletNum; i++)
            {
                GameObject bullet = GameObject.Instantiate(_bulletPrefab, _shootPoint.transform.position, Quaternion.identity);
                bullet.GetComponent<Rigidbody>().AddForce(Vector3.forward * 1000);
            }            
            _gun.RemoveAmmo(BulletNum);
        }

    }

}