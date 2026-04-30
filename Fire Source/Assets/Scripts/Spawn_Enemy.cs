using UnityEngine;

public class Spawn_Enemy : MonoBehaviour
{
    public float _spawnTimer; // Timer para controlar o tempo de spawn dos inimigos
    public float _enemySpawnInterval = 1f;// Intervalo de tempo entre os spawns dos inimigos

    public float _MaxEnemysLancados;
    public float _EnemysAtuais;
    public float _Wave;
    public bool _EnemysSpawn;

    [SerializeField] private GameObject[] _enemies; // Array de prefabs dos inimigos para spawnar


    public float _spawnRadius; // Raio de spawn para os inimigos
    public float _spawnradiuMinim; // Raio mínimo de spawn para os inimigos, para evitar que eles apareçam muito próximos do jogador
    const float _tau = 6.283185307179586476925286766559f; // Constante para calcular o ângulo de spawn dos inimigos
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _EnemysAtuais = _MaxEnemysLancados;
        _EnemysAtuais = _EnemysAtuais + _Wave;
    }

    // Update is called once per frame
    void Update()
    {
        _spawnTimer += Time.deltaTime;

        if (_EnemysSpawn == true )
        {
            if (_spawnTimer > _enemySpawnInterval)
            {
                if (_EnemysAtuais > 0)
                {
                    Spawn();
                }
            }
        }
        
    }

    private void Spawn()
    {
        _EnemysAtuais--;
        float RandowTau = Random.Range(0, _tau);
        float b = Random.Range(_spawnradiuMinim, _spawnRadius);
        Vector2 spawnPosition = new Vector2(transform.position.x + Mathf.Cos(RandowTau) * b, transform.position.y + Mathf.Sin(RandowTau) * b);
        Instantiate(_enemies[Random.Range(0, _enemies.Length)], spawnPosition, Quaternion.identity);
        _spawnTimer = 0;
    }

    void OnDrawGizmosSelected()
    {
        // Draw a wire sphere to visualize the spawn radius in the editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _spawnRadius);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, _spawnradiuMinim);
    }
}
