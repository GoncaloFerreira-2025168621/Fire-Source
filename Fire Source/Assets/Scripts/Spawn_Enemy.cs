using UnityEngine;

public class Spawn_Enemy : MonoBehaviour
{
    
    public float _enemySpawnInterval = 1f;// Intervalo de tempo entre os spawns dos inimigos
    public Waves _waves;

   

    [SerializeField] private GameObject[] _enemies; // Array de prefabs dos inimigos para spawnar


    public float _spawnRadius; // Raio de spawn para os inimigos
    public float _spawnradiuMinim; // Raio mínimo de spawn para os inimigos, para evitar que eles apareçam muito próximos do jogador
    const float _tau = 6.283185307179586476925286766559f; // Constante para calcular o ângulo de spawn dos inimigos
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn()
    {
        
        float RandowTau = Random.Range(0, _tau);
        float b = Random.Range(_spawnradiuMinim, _spawnRadius);
        Vector2 spawnPosition = new Vector2(transform.position.x + Mathf.Cos(RandowTau) * b, transform.position.y + Mathf.Sin(RandowTau) * b);
        Instantiate(_enemies[Random.Range(0, _enemies.Length)], spawnPosition, Quaternion.identity);
    }

    void OnDrawGizmosSelected()
    {
        // Draw a wire sphere to visualize the spawn radius in the editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _spawnRadius);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, _spawnradiuMinim);
    }

    public void NewWave()
    {
        _waves._Waves++;
        _waves._EnemysAtuais = _waves._MaxEnemysLancados + _waves._Waves;
        _waves._inimigosEmFalta = _waves._EnemysAtuais;
        _waves._CartaLancada = false;
        _waves._ProntoSpawn = true;
    }
}
