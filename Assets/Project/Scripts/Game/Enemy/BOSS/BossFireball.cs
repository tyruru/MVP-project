using UnityEngine;

public class BossFireball : MonoBehaviour
{
    private Rigidbody2D _body2D;

    [SerializeField] private ParticleSystem _partical;
    [SerializeField] private float _speed;
    [SerializeField] private LayerMask _destroyLayer;

    private Transform _playerTransform;

    private void Awake()
    {
        _body2D = GetComponent<Rigidbody2D>();
        _playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    private void Start()
    {
        Vector2 targetPosition = _playerTransform.position; 
        Vector2 fireballPosition = transform.position;
        Vector2 direction = (targetPosition - fireballPosition).normalized;

        _body2D.velocity = direction * _speed;

        _partical.Play();
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.CompareTag("Player"))
        {
            target.GetComponent<HealthView>().TakeDamage(1, transform.position);
            Destroy(gameObject);
        }

        if (((1 << target.gameObject.layer) & _destroyLayer) != 0)
        {
            Destroy(gameObject);
        }
    }
}
