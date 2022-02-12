using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject bullet, megaBullet, turret;
    
    public void Shoot()
    {
        var bulletPosition = transform.position + bullet.transform.position;
        var bulletRotation = turret.transform.rotation * bullet.transform.rotation;
        
        var currentBullet = Instantiate(bullet, bulletPosition, bulletRotation);
        
        currentBullet.GetComponent<Projectile>().Initialize();
    }

    public void MegaShoot()
    {
        var bulletPosition = transform.position + megaBullet.transform.position;
        var bulletRotation = turret.transform.rotation * megaBullet.transform.rotation;
        
        var currentBullet = Instantiate(megaBullet, bulletPosition, bulletRotation);
        
        currentBullet.GetComponent<Projectile>().Initialize();
    }
}