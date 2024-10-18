using UnityEngine;

public class WallBase : MonoBehaviour
{
    [SerializeField] private bool _isRight;
    [SerializeField] private float _offset;

    [Space(10)]
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private bool _isArrow;
    [SerializeField] private bool _isIce;

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector2 newPlayerPosition = Game.Player.transform.position;
        newPlayerPosition.x = transform.position.x + _offset;
        Game.Player.transform.position = newPlayerPosition;

        Game.Player.GrabWall(_isRight);

        if (_isIce) Game.Spawner.SpawnIce(_spawnPoint.position);
        if (_isArrow) Game.Spawner.SpawnArrow(_spawnPoint.position);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Game.Player.ReleaseWall();
    }
}