using UnityEngine;

public class TakeDamage : MonoBehaviour
{

    [Header("PlayerAttack")]
    [SerializeField] public StatsEnemy _statsEnemy;
    [SerializeField] public float _damageBase;
    [SerializeField] public float _damageMelee = 5;
    [SerializeField] public float _damageRange = 2;
    [SerializeField] public float _damageExplosion = 5;
    [SerializeField] public float _damageFlameThrower = 2;
    [SerializeField] public float _damageFireBall = 3;
    [SerializeField] public int _TypeDamage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {
            _statsEnemy = collision.gameObject.GetComponent<StatsEnemy>();
        }

        // Verificar se o objeto colidido tem a tag "Enemy"
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Colisão com o inimigo detectada!");
            switch (_TypeDamage)
            {
                case 1:
                    _statsEnemy.LifeEnemy(_damageMelee + _damageBase);// Aplica o dano de ataque corpo a corpo
                    break;
                case 2:
                    _statsEnemy.LifeEnemy(_damageRange + _damageBase);// Aplica o dano de ataque a distância
                    break;
                case 3:
                    _statsEnemy.LifeEnemy(_damageExplosion + _damageBase);// Aplica o dano de explosão de fogo
                    break;
                case 4:
                    _statsEnemy.LifeEnemy(_damageFlameThrower + _damageBase);// Aplica o dano de lança chamas
                    break;
                case 5:
                    _statsEnemy.LifeEnemy(_damageFireBall + _damageBase);// Aplica o dano de bola de fogo
                    break;
                default:
                    _statsEnemy.LifeEnemy(_damageBase + _damageBase);// Aplica o dano base caso o tipo de dano seja desconhecido
                    break;
            }

            
        }
    }
}
