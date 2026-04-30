using UnityEngine;

public class Waves : MonoBehaviour
{
    [SerializeField] public int _Waves;
    [SerializeField] private StatsPlayer _player;
    [SerializeField] private Spawn_Enemy _enemy;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            _player = playerObj.GetComponent<StatsPlayer>();
        }

        GameObject enemyObj = GameObject.FindGameObjectWithTag("SpawnEnemys");
        if (enemyObj != null)
        {
            _enemy = enemyObj.GetComponent<Spawn_Enemy>();
        }
        _Waves = 1;
        _enemy._Wave = _Waves;
    }

    // Update is called once per frame
    void Update()
    {
        if (_enemy._EnemysAtuais <= 0)
        {
            _Waves = _Waves + 1;
            _enemy._Wave = _Waves;
        }

        if (_player._lifePlayerAtual <= 0)
        {
            _Waves = 0;
            _enemy._Wave = _Waves;
        }
    }
}
