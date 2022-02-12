using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject firePoint;

    [SerializeField] private float speed;
    [SerializeField] public int damage;

    public void Shoot()
    {
        var currentBullet = Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation).GetComponent<Projectile>();
        currentBullet.Initialize(speed, damage);
    }
}