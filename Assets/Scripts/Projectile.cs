using UnityEngine;

public class Projectile : MonoBehaviour
{
    private int _damage;

    private Rigidbody _rigidbody;

    private Vector3 _startPos;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();

        _startPos = transform.position;
    }

    public void Initialize(float speed, int damage)
    {
        _damage = damage;
        
        _rigidbody.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        /*if (_isPlayer && other.gameObject.CompareTag("Enemy"))
        {
            EnemyManager enemy = other.gameObject.GetComponent<EnemyManager>();
            
            enemy.TakeDamage(_damage);

            enemy.Taunted = true;
            enemy.currentState = EnemyManager.State.ChasePlayer;
            
            Destroy(gameObject);
        }
        else if (_isPlayer && other.gameObject.CompareTag("Deviant"))
        {
            DeviantManager enemy = other.gameObject.GetComponent<DeviantManager>();
            
            enemy.TakeDamage(_damage);

            enemy._taunted = true;
            enemy.currentState = DeviantManager.State.ChasePlayer;
            
            Destroy(gameObject);
        }
        else if(!_isPlayer && other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Entity>().TakeDamage(_damage);
            
            Destroy(gameObject);
        }*/
    }
}