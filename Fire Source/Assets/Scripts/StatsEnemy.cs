using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class StatsEnemy : MonoBehaviour
{
    [Header("Stats Tank")]
    [SerializeField] public float _lifeTank = 15;
    [SerializeField] public float _SpeedTank = 1;
    [SerializeField] public float _DamageTank = 5;
    

    [Header("Stats Normal Enemy")]
    [SerializeField] public float _lifeNormal = 10;
    [SerializeField] public float _SpeedNormal = 2;
    [SerializeField] public float _DamageNormal = 10;

    [Header("Stats Dano Enemy")]
    [SerializeField] public float _lifeDano = 5;
    [SerializeField] public float _SpeedDano = 3;
    [SerializeField] public float _DamageDano = 15;

    [Header("Stats gerais")]
    [SerializeField] public float _lifeAtual;
    [SerializeField] public float _SpeedAtual;
    [SerializeField] public float _DamageAtual;

    [SerializeField] public float _Visao = 2;
    [SerializeField] public float _VisaoMin;
    [SerializeField] public float _AtackColldown = 1;



    private Transform _playerTransform;
    private StatsPlayer _player;

    [SerializeField] public int _typeEnemy;// 1 para tanque, 2 para normal e 3 para dano
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (_typeEnemy == 1)
        {
            _lifeAtual = _lifeTank;
            _SpeedAtual = _SpeedTank;
            _DamageAtual = _DamageTank;
        }
        else if (_typeEnemy == 2)
        {
            _lifeAtual = _lifeNormal;
            _SpeedAtual = _SpeedNormal;
            _DamageAtual = _DamageNormal;
        }
        else if (_typeEnemy == 3)
        {
            _lifeAtual = _lifeDano;
            _SpeedAtual = _SpeedDano;
            _DamageAtual = _DamageDano;
        }

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            _playerTransform = playerObj.transform;
            _player = playerObj.GetComponent<StatsPlayer>();
        }
        /*if (_Visao <= 0)
        {
            _SpeedAtual = 0f; // Para o inimigo quando estiver muito pr�ximo do player
            _player.TakeDamage(_DamageAtual); //da dano ao player
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, _playerTransform.position);


        // Se o player estiver dentro do alcance, move at� ele
        if (distance <= _Visao)
        {
            Vector3 direction = (_playerTransform.position - transform.position).normalized;
            transform.position += direction * _SpeedAtual * Time.deltaTime;
            _AtackColldown -= Time.deltaTime;
        }
        if(distance <= _VisaoMin && _AtackColldown <= 0)
        {
            Debug.Log("Enimigo a tirar dano");
            _player.TakeDamage(_DamageAtual);
            _SpeedAtual = 0;
            _AtackColldown = 1;
        }

        if (_lifeAtual <= 0)
        {
            Destroy(gameObject);
        }
    }

    /*void OnCollisionEnter2D(Collider2D collision)
    {
        Debug.Log("Entrei");
        if ( collision.gameObject.CompareTag("Player"))
        {
            _player.TakeDamage(_DamageAtual);
        }
    }*/

    public void LifeEnemy(float life)
    {
        Debug.Log("LifeEnemy Chamado com dano: " + life);
        _lifeAtual -= life;// Subtrai o dano da vida atual do inimigo

        
    }

    private void OnDrawGizmos()
    {
        // Desenha um gizmo para visualizar o alcance de detec��o do inimigo
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _Visao);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _VisaoMin);
    }
}
