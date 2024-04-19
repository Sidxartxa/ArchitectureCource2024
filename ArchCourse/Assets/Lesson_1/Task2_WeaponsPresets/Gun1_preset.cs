using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun1_preset : IShoot
//в этом пресете мы стреляем одиночными пулями.
// Количество пуль ограничено
// перезарядка не предусмотрена

{
    
    private Gun _gun;
    private int BulletNum = 1; // количество пуль за выстрел

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
            GameObject bullet = GameObject.Instantiate(_bulletPrefab, _shootPoint.transform.position, Quaternion.identity); 
            bullet.GetComponent<Rigidbody>().AddForce(Vector3.forward * 1000);
            _gun.RemoveAmmo(BulletNum);
        }
        

    }
}
