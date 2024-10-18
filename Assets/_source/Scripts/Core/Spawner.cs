using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _content;
    [SerializeField] private Arrow _arrow;
    [SerializeField] private Ice _ice;

    public void SpawnArrow(Vector3 position)
    {
        Instantiate(_arrow, position, Quaternion.identity, _content);
    }

    public void SpawnIce(Vector3 position)
    {
        Instantiate(_ice, position, Quaternion.identity, _content);
    }
}