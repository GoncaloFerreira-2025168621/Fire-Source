using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerAttack : MonoBehaviour
{

    [Header("General Attack Settings")]
    [SerializeField] private GameObject _PlayerDirection;
    [SerializeField] private float _AttackCooldown; // Tempo de cooldown do ataque em segundos
    [SerializeField] private Player_controller _movement;

    [Header("Cards")]
    [SerializeField] private Carts _cards;

    [Header("Melee Attack")]
    [SerializeField] private GameObject _MeleeAttack_lv1;
    [SerializeField] private GameObject _MeleeAttack_lv2;
    [SerializeField] private GameObject _MeleeAttack_lv3;
    [SerializeField] private GameObject _MeleeAttack_lv4;
    [SerializeField] private GameObject _MeleeAttack_lv5;
    [SerializeField] private float _MeleeRange; // Alcance do ataque corpo a corpo
    [SerializeField] private float _MeleeAttackCooldown; // Tempo de cooldown do ataque corpo a corpo em segundos
    [SerializeField] private float _MeleeAttackTimer; // Timer para controlar o tempo de ataque corpo a corpo

    [Header("Range Attack")]
    [SerializeField] private float _ShotRangeValue; // Valor do alcance do ataque a distância
    [SerializeField] private float _speedShot; // Velocidade da bala
    [SerializeField] private GameObject _Shot;
    [SerializeField] private float _RangeAttackCooldown; // Tempo de cooldown do ataque a distância em segundos
    [SerializeField] private float _RangeAttackTimer; // Timer para controlar o tempo de ataque a distância

    [Header("Fire Ball Attack")]
    [SerializeField] private GameObject _FireBall_lv1;
    [SerializeField] private GameObject _FireBall_lv2;
    [SerializeField] private GameObject _FireBall_lv3;
    [SerializeField] private GameObject _FireBall_lv4;
    [SerializeField] private GameObject _FireBall_lv5;
    [SerializeField] private float _FireBallRange; // Alcance do ataque de bola de fogo
    [SerializeField] private float _speedFireBall; // Velocidade de rotação das bolas de fogo

    [Header("FlameThrower Attack")]
    [SerializeField] private GameObject _FlameThrower_lv1;
    [SerializeField] private GameObject _FlameThrower_lv2;
    [SerializeField] private GameObject _FlameThrower_lv3;
    [SerializeField] private GameObject _FlameThrower_lv4;
    [SerializeField] private GameObject _FlameThrower_lv5;
    [SerializeField] private float _speedFlameThrower; // Velocidade do ataque de lança chamas

    [Header("ExplosionFire Attack")]
    [SerializeField] private GameObject _ExplosionFire;
    [SerializeField] private float _ExplosionFireRange; // Alcance do ataque de explosão de fogo
    [SerializeField] private float _speedExplosionFire; // Velocidade do ataque de explosão de fogo
    [SerializeField] private float _ExplosionFireCooldown; // Tempo de cooldown do ataque de explosão de fogo em segundos
    [SerializeField] private float _ExplosionFireTimer; // Timer para controlar o tempo de ataque de explosão de fogo


    //[SerializeField] private float _meleeRange = 1f; // Alcance do ataque corpo a corpo

    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_cards._card_atual == _cards._card_melee) // Verifica se a carta atual é a de ataque corpo a corpo
        {

        }
        else if (_cards._card_atual == _cards._card_range) // Verifica se a carta atual é a de ataque a distância
        {

        }
        else if (_cards._card_atual == _cards._card_explosionFire) // Verifica se a carta atual é a de ataque de explosão de fogo
        {

        }
        else if (_cards._card_atual == _cards._card_flameThrower) // Verifica se a carta atual é a de ataque de lança chamas
        { 

        }
        else if (_cards._card_atual == _cards._card_fireBalls) // Verifica se a carta atual é a de ataque de bola de fogo
        {
            
        }
        _ExplosionFireTimer += Time.deltaTime; // Incrementa o cooldown do ataque de explosão de fogo a cada frame
        _RangeAttackTimer += Time.deltaTime; // Incrementa o cooldown do ataque a distância a cada frame
        _MeleeAttackTimer += Time.deltaTime; // Incrementa o cooldown do ataque corpo a corpo a cada frame

        if (_MeleeAttackTimer >= _MeleeAttackCooldown) // Verifica se o cooldown do ataque é igual ao tempo definido
        {
            MeleeAttack(); // Chama o método de ataque base
        }
        else
        {
            if (_MeleeAttackTimer >= 0.5f) // Verifica se o cooldown do ataque é igual a 0.5 segundos
            {
                _MeleeAttack_lv1.SetActive(false); // Desativa o ponto de ataque para indicar que o ataque não está  mais ativo
                //_Bala.SetActive(false);
            }
        }

        if (_RangeAttackTimer >= _RangeAttackCooldown) // Verifica se o cooldown do ataque é igual ao tempo definido
        {
            RangeAttack(); // Chama o método de ataque à distância
        }

        if (_ExplosionFireTimer >= _ExplosionFireCooldown) // Verifica se o cooldown do ataque é igual ao tempo definido
        {
            ExplosionFire(); // Chama o método de ataque de explosão de fogo
        }

        FireBalls(); // Chama o método de ataque de bola de fogo
        FlameThrower(); // Chama o método de ataque de lança chamas
    }

    public void MeleeAttack()
    {
        Debug.Log("Melee Attack");
        // Pega a posição do mouse no mundo
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

        // Direcao do player para o rato
        Vector2 direction = (mousePos - _PlayerDirection.transform.position).normalized;

        // Rotacao baseada na direcao
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Aplicar rotacao
        _MeleeAttack_lv1.transform.rotation = Quaternion.Euler(0, 0, angle);

        // Posicionar a volta do player
        _MeleeAttack_lv1.transform.localPosition = (Vector3)direction * _MeleeRange;

        // ajusta aqui (testa 90 ou -90)
        angle -= 90f;

        _MeleeAttack_lv1.transform.rotation = Quaternion.Euler(0, 0, angle);

        //Instantiate(_AttackPoint, _AttackPoint.transform.position, _AttackPoint.transform.rotation); // Ativa o ponto de ataque para indicar que o ataque está ativo
        _MeleeAttack_lv1.SetActive(true); // Ativa o ponto de ataque para indicar que o ataque está ativo
        _MeleeAttackTimer = 0f; // Reseta o cooldown do ataque

        }

    
    public void RangeAttack()
    {
        
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);// Pega a posição do mouse no mundo
        mousePos.z = 0f;

        // Direcao do player para o rato
        Vector2 direction = (mousePos - _PlayerDirection.transform.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;// Rotacao baseada na direcao

        // Criar bala
        GameObject bala = Instantiate(_Shot, _PlayerDirection.transform.position, Quaternion.identity);

        // Rotação
        bala.transform.rotation = Quaternion.Euler(0, 0, angle - 90f);

        // Definir alvo (um ponto à frente)
        Vector3 target = _PlayerDirection.transform.position + (Vector3)direction * _ShotRangeValue;

        // Inicializar movimento
        bala.GetComponent<Bala>().Init(target, _speedShot);

        _RangeAttackTimer = 0f; // Reseta o cooldown do ataque a distância
    }

    //FireBalls Giratorias no eixo do player
    public void FireBalls()
    {
        _FireBall_lv1.transform.Rotate(0, 0, _speedFireBall * Time.deltaTime, Space.Self); ; // Aplica uma rotação contínua ao redor do eixo Z
        _FireBall_lv1.SetActive(true);
    }

    public void FlameThrower()
    {
        _FlameThrower_lv1.transform.Rotate(0, 0, _speedFlameThrower * Time.deltaTime, Space.Self); // Aplica uma rotação contínua ao redor do eixo Z
    }

    public void ExplosionFire()
    {
        Debug.Log("Explosion Fire Attack");

        _ExplosionFire.SetActive(true);// Ativa a explosão de fogo

        //Aumenta o tamanho da explosão de fogo ate atingir o alcance definido
        _ExplosionFire.transform.localScale += Vector3.one * _speedExplosionFire * Time.deltaTime;
        if (_ExplosionFire.transform.localScale.x >= _ExplosionFireRange)
        {
            _ExplosionFire.transform.localScale = Vector3.zero; // Reseta o tamanho da explosão de fogo para o próximo ataque
            _ExplosionFireTimer = 0f; // Reseta o cooldown do ataque de explosão de fogo
            _ExplosionFire.SetActive(false); // Desativa a explosão de fogo quando atingir o alcance máximo
        }
    }
}

