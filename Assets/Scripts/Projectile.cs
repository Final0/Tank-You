using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage;

    public float speed;

    public bool isMegaBullet;

    [SerializeField] private GameObject explosion;

    private Rigidbody _rigidbody;

    private const string Tank1Tag = "Tank1", Tank2Tag = "Tank2";

    private bool _tank1;

    private TankManager _currentTank;

    private void Awake() => _rigidbody = GetComponent<Rigidbody>();

    public void Initialize(bool tank1)
    {
        _tank1 = tank1;
        
        _currentTank = GameObject.FindWithTag(tank1 ? Tank1Tag : Tank2Tag).GetComponentInParent<TankManager>();
        
        if (!isMegaBullet)
        {
            var localDirection = transform.rotation.y * -transform.right;
            
            _rigidbody.velocity = localDirection.normalized * speed;
        }
        else
        {
            var localDirection = transform.rotation.x * transform.up;
            
            _rigidbody.velocity = localDirection.normalized * speed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_tank1 && other.gameObject.CompareTag(Tank2Tag) || !_tank1 && other.gameObject.CompareTag(Tank1Tag))
        {
            var tankEnemy = other.gameObject.GetComponentInParent<TankManager>();
            
            tankEnemy.TakeDamage(damage);
            tankEnemy.lastHit = true;

            _currentTank.lastHit = false;
            
            Destroy(gameObject);
        }
        else if (!other.gameObject.CompareTag(Tank1Tag) && !other.gameObject.CompareTag(Tank1Tag))
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy() => Instantiate(explosion, transform.position, Quaternion.identity);
}