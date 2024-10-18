using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private GameObject[] _healthImages;


    [Space(10)]
    [SerializeField] private float _upJumpForce;
    [SerializeField] private float _sideJumpForce;

    [Space(10)]
    [SerializeField] private float _linerDragStandart = 0.5f;
    [SerializeField] private float _linerDragSlide = 6f;

    private Rigidbody2D _rigidbody;
    private SpriteRenderer _sprite;

    private int _jumpCount;
    private int _health;

    public bool IsRight
    {
        get => _sprite.flipX; 
        set => _sprite.flipX = value; 
    }

    public int Health
    {
        get => _health;
        set
        {
            _health = value;
            for(int i = 0; i < _healthImages.Length; i++)            
                _healthImages[i].SetActive(i < _health);

            if (_health < 1) {
                ResetGame();
                Debug.Log("GameOver");
            } 
        }
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();
    }

    public void ResetGame()
    {
        IsRight = false;
        _rigidbody.simulated = false;
        transform.position = Vector2.zero;
        _jumpCount = 2;
        Health = 3;
    }

    public void GrabWall(bool isRight)
    {
        IsRight = isRight;
        _rigidbody.velocity = Vector2.zero;
        _jumpCount = 2;

        _rigidbody.drag = _linerDragSlide;
    }

    public void ReleaseWall()
    {      
        _rigidbody.drag = _linerDragStandart;
    }

    public void Jump()
    {
        if (_jumpCount != 0)
        {
            if(_jumpCount == 1) IsRight = !IsRight;

            _rigidbody.velocity = Vector2.zero;
            _rigidbody.AddForce(new Vector2(IsRight ? -_sideJumpForce : _sideJumpForce, _upJumpForce), ForceMode2D.Impulse);

            _jumpCount--;
        }
    }

    public void TakeDamage()
    {
        _rigidbody.AddForce(Vector2.down * 5, ForceMode2D.Impulse);
        Health--;
    }
}