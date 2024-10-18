using System.Collections;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Coroutine _updateProcess;

    public void OnEnable()
    {
        Release();
        _updateProcess = StartCoroutine(UpdateProcess());
    }

    private IEnumerator UpdateProcess()
    {
        while(true)
        {
            transform.position += Time.deltaTime * _speed * Vector3.down;
            yield return null;
        }
    }


    private void Release()
    {
        if (_updateProcess != null)
        {
            StopCoroutine(_updateProcess);
            _updateProcess = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Game.Player.TakeDamage();
    }
}