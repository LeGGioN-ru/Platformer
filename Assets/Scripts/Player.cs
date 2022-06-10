using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpPower;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Transform _respawnPoint;

    private bool _isCanJump;
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private int _isWalked;

    public void Die()
    {
        transform.position = _respawnPoint.position;
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _isWalked = Animator.StringToHash("IsWalked");
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(_speed * Time.deltaTime * -1, 0, 0);
            _spriteRenderer.flipX = true;
            _animator.SetBool(_isWalked, true);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(_speed * Time.deltaTime, 0, 0);
            _spriteRenderer.flipX = false;
            _animator.SetBool(_isWalked, true);
        }

        if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W)) && _isCanJump)
        {
            Jump();
        }

        if (Input.GetKey(KeyCode.A) == false && Input.GetKey(KeyCode.D) == false)
        {
            _animator.SetBool(_isWalked, false);
        }
    }

    private void Jump()
    {
        _rigidbody.AddForce(new Vector2(0, _jumpPower * 10));
        _isCanJump = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Platform platform))
        {
            _isCanJump = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Platform platform))
        {
            _isCanJump = false;
        }
    }
}
