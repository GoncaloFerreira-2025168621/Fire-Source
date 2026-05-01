using TMPro;
using UnityEngine;

public class Waves : MonoBehaviour
{
    [SerializeField] public float _Waves;
    [SerializeField] private StatsPlayer _player;
    [SerializeField] private Spawn_Enemy _enemy;
    [SerializeField] public bool _ProntoSpawn = false;


    //[SerializeField] private Transform _transform;
    //[SerializeField] private GameObject _Corredor;
    [SerializeField] public float _inimigosEmFalta;
    //[SerializeField] private int _numeroDeCorredores;
    [SerializeField] public SpawnCarts _spawnCarts;
    [SerializeField] public bool _CartaLancada = false;

    [SerializeField] public TextMeshProUGUI _Wave;
    [SerializeField] public TextMeshProUGUI _Enimigos;

    public float _MaxEnemysLancados;
    public float _EnemysAtuais;
    public float _spawnTimer; // Timer para controlar o tempo de spawn dos inimigos


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

        _EnemysAtuais = _MaxEnemysLancados + _Waves;
        
    }

    // Update is called once per frame
    void Update()
    {
        _Wave.text = "Wave " + _Waves.ToString();
        _Enimigos.text = "Enimgos Restantes: " + _inimigosEmFalta.ToString();
        if (_ProntoSpawn == true)
        {

                _enemy.Spawn();
                _EnemysAtuais = _EnemysAtuais - 1;
        }
        if (_EnemysAtuais == 0)
        {
            _ProntoSpawn = false;
        }
        

       
        if (_inimigosEmFalta <= 0 && _CartaLancada == false && _EnemysAtuais == 0)
        {

            Debug.Log("Todos os inimigos derrotados");
            _spawnCarts.RandomizeCards();
            _CartaLancada = true;
        }

        if (_player._lifePlayerAtual <= 0)
        {
            _Waves = 0;
        }
    }


}
