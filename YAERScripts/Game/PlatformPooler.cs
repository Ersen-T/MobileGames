using System.Collections.Generic;
using UnityEngine;

public class PlatformPooler : MonoBehaviour
{
    [SerializeField] private List<GameObject> _platformListA = new List<GameObject>();
    [SerializeField] private List<GameObject> _platformListB = new List<GameObject>();
    [SerializeField] private List<GameObject> _platformListC = new List<GameObject>();

    private float _zPos = 0.0f;

    private int _random;
    private int _platformMoveCounter = 0;

    

    private void Start()
    {
        int _randomCount = _platformListA.Count;
        int _forCount = _platformListA.Count;

        for (int i = 0; i < _forCount; i++)
        {
            _random = Random.Range(0, _randomCount);

            GameObject _platform = Instantiate(_platformListA[_random], new Vector3(0.0f, 0.0f, _zPos), Quaternion.identity);

            _platformListC.Add(_platform);
            _platformListB.Add(_platformListA[_random]);
            _platformListA.RemoveAt(_random);

            _zPos += 30.0f;

            _randomCount -= 1;
        }

        // Second set is just for diversity in colors.

        _randomCount = _platformListB.Count;

        for (int i = 0; i < _forCount; i++)
        {
            _random = Random.Range(0, _randomCount);

            GameObject _platform = Instantiate(_platformListB[_random], new Vector3(0.0f, 0.0f, _zPos), Quaternion.identity);

            _platformListC.Add(_platform);
            _platformListB.RemoveAt(_random);

            _zPos += 30.0f;

            _randomCount -= 1;
        }
    }

    private void Update()
    {
        if (MovePlatform.TriggerCount == 2)
        {
            _platformListC[_platformMoveCounter].transform.position = new Vector3(0.0f, 0.0f, _zPos);

            _platformListC[_platformMoveCounter].transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.SetActive(false);
            _platformListC[_platformMoveCounter].transform.GetChild(0).gameObject.transform.GetChild(2).gameObject.SetActive(true);

            _platformMoveCounter += 1;
            if (_platformMoveCounter == _platformListC.Count)
            {
                _platformMoveCounter = 0;
            }
            _zPos += 30.0f;
            MovePlatform.SetToOne();
        }
    }
}
