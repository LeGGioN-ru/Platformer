using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;

    private Transform[] _pathPoints;
    private int _currentPoint;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        GetPathPoints();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _pathPoints[_currentPoint].position, _speed * Time.deltaTime);

        if (transform.position == _pathPoints[_currentPoint].position)
        {
            _currentPoint++;
            _spriteRenderer.flipX = !_spriteRenderer.flipX;

            if (_currentPoint == _pathPoints.Length)
            {
                _currentPoint = 0;
            }
        }
    }

    private void GetPathPoints()
    {
        _pathPoints = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _pathPoints[i] = _path.GetChild(i);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Player player))
        {
            player.Die();
        }
    }
}
