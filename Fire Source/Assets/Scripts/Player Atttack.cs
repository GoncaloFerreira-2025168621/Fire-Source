using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    [Header("General Attack Settings")]
    [SerializeField] private GameObject _PlayerDirection;
    [SerializeField] private float _AttackCooldown; // Tempo de cooldown do ataque em segundos
    [SerializeField] private Player_controller _movement;

    [Header("Cards")]
    [SerializeField] private Carts _cards;

    [Header("StatsPlayer")]
    [SerializeField] private StatsPlayer _statsPlayer;

    [Header("Lvl Power Attack")]
    [SerializeField] private Carts _cards_lv;

    [Header("Melee Attack")]
    [SerializeField] public GameObject _MeleeAttack_lv1;
    [SerializeField] public GameObject _MeleeAttack_lv2;
    [SerializeField] public GameObject _MeleeAttack_lv3;
    [SerializeField] public GameObject _MeleeAttack_lv4;
    [SerializeField] public GameObject _MeleeAttack_lv5;
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

        // Encontra o objeto com a tag "Cards" e obtém o componente Carts
        GameObject CardsObj = GameObject.FindGameObjectWithTag("Cards");
        if (CardsObj != null)
        {
           
            _cards = CardsObj.GetComponent<Carts>();
            _cards_lv = CardsObj.GetComponent<Carts>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //timers
        //verifica se o ataque de explosão de fogo está disponível para ser usado
       /* if (_cards_lv._explosionFireLv > 0)
        {
            _ExplosionFireTimer += Time.deltaTime; // Incrementa o cooldown do ataque de explosão de fogo a cada frame
        }*/
        //verifica se o ataque a distância está disponível para ser usado
        if (_cards_lv._rangeAttackLv > 0)
        {
            _RangeAttackTimer += Time.deltaTime; // Incrementa o cooldown do ataque a distância a cada frame
        }
        //verifica se melee attack está disponível para ser usado
        if (_cards_lv._meleeAttackLv > 0) // Verifica se o nível do ataque corpo a corpo é maior que 0
        {
            _MeleeAttackTimer += Time.deltaTime; // Incrementa o cooldown do ataque corpo a corpo a cada frame
        }
        
        FireBalls();
        FlameThrower();
        ExplosionFire();
        //MeleeAttack();

        if (_cards_lv._fireBallsAttackLv == 1)
        {
            
        }
        if (_cards_lv._flameThrowerAttackLv == 1)
        {
            
        }
        if (_cards_lv._explosionFireLv == 1)
        {
            
        }

        /*// Define o cooldown do ataque corpo a corpo com base no nível do ataque
        if (_cards_lv._meleeAttackLv == 1)
        {
            _MeleeAttackCooldown = 2f;

        }
        else if (_cards_lv._meleeAttackLv == 2)
        {
            _MeleeAttackCooldown = 1.5f;
        }
        else if (_cards_lv._meleeAttackLv == 3)
        {
            _MeleeAttackCooldown = 1f;
        }
        else if (_cards_lv._meleeAttackLv == 4)
        {
            _MeleeAttackCooldown = 0.75f;
        }
        else if (_cards_lv._meleeAttackLv == 5)
        {
            _MeleeAttackCooldown = 0.5f;
        }*/

        // Define o cooldown do ataque a distância com base no nível do ataque
        if (_cards_lv._rangeAttackLv == 1)
        {
            _RangeAttackCooldown = 2f;
        }
        else if (_cards_lv._rangeAttackLv == 2)
        {
            _RangeAttackCooldown = 1.5f;
        }
        else if (_cards_lv._rangeAttackLv == 3)
        {
            _RangeAttackCooldown = 1f;
        }
        else if (_cards_lv._rangeAttackLv == 4)
        {
            _RangeAttackCooldown = 0.75f;
        }
        else if (_cards_lv._rangeAttackLv == 5)
        {
            _RangeAttackCooldown = 0.5f;
        }

        if (_RangeAttackTimer >= _RangeAttackCooldown) // Verifica se o cooldown do ataque a distância é igual ao tempo definido
        {
            RangeAttack(); // Chama o método de ataque a distância
        }

        if (_MeleeAttackTimer >= _MeleeAttackCooldown) // Verifica se o cooldown do ataque é igual ao tempo definido
        {
            MeleeAttack(); // Chama o método de ataque base
        }
        


        /*
        if (_cards_lv._rangeAttackLv == 1 && _RangeAttackTimer >= _RangeAttackCooldown) // Verifica se o cooldown do ataque a distância é igual ao tempo definido
        {
            RangeAttack(); // Chama o método de ataque a distância
        }
        if(_cards_lv._fireBallsAttackLv == 1) // Verifica se o nível do ataque de bola de fogo é 1
        {
            FireBalls(); // Chama o método de ataque de bola de fogo
        }*/
    }

    public void MeleeAttack()
    {
        //_MeleeAttack_lv1.SetActive(true); 
        //Debug.Log("Melee Attack");
        // Pega a posição do mouse no mundo
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

        // Direcao do player para o rato
        Vector2 direction = (mousePos - _PlayerDirection.transform.position).normalized;

        // Rotacao baseada na direcao
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Aplicar rotacao
        //_MeleeAttack_lv1.transform.rotation = Quaternion.Euler(0, 0, angle);

        // Posicionar a volta do player
        //_MeleeAttack_lv1.transform.localPosition = (Vector3)direction * _MeleeRange;
        _MeleeAttack_lv1.transform.position = _PlayerDirection.transform.position + (Vector3)direction * _MeleeRange;
        _MeleeAttack_lv2.transform.position = _PlayerDirection.transform.position + (Vector3)direction * _MeleeRange;
        _MeleeAttack_lv3.transform.position = _PlayerDirection.transform.position + (Vector3)direction * _MeleeRange;
        _MeleeAttack_lv4.transform.position = _PlayerDirection.transform.position + (Vector3)direction * _MeleeRange;
        _MeleeAttack_lv5.transform.position = _PlayerDirection.transform.position + (Vector3)direction * _MeleeRange;

        // ajusta aqui (testa 90 ou -90)
        angle -= 90f;

        

        //Debug.Log("FireBallsAttackLv called");
        if (_cards_lv._meleeAttackLv == 1)
        {
            _MeleeAttack_lv1.SetActive(true);
            _MeleeAttack_lv1.transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        else if (_cards_lv._meleeAttackLv == 2)
        {
            _MeleeAttack_lv1.SetActive(false); // Desativa o nível anterior para evitar sobreposição
            _MeleeAttack_lv2.SetActive(true);
            _MeleeAttack_lv2.transform.rotation = Quaternion.Euler(0, 0, angle);

        }
        else if (_cards_lv._meleeAttackLv == 3)
        {
            _MeleeAttack_lv2.SetActive(false); // Desativa o nível anterior para evitar sobreposição
            _MeleeAttack_lv3.SetActive(true);
            _MeleeAttack_lv3.transform.rotation = Quaternion.Euler(0, 0, angle);

        }
        else if (_cards_lv._meleeAttackLv == 4)
        {
            _MeleeAttack_lv3.SetActive(false); // Desativa o nível anterior para evitar sobreposição
            _MeleeAttack_lv4.SetActive(true);
            _MeleeAttack_lv4.transform.rotation = Quaternion.Euler(0, 0, angle);

        }
        else if (_cards_lv._meleeAttackLv == 5)
        {
            _MeleeAttack_lv4.SetActive(false); // Desativa o nível anterior para evitar sobreposição
            _MeleeAttack_lv5.SetActive(true);
            _MeleeAttack_lv5.transform.rotation = Quaternion.Euler(0, 0, angle);
        }

        //Instantiate(_AttackPoint, _AttackPoint.transform.position, _AttackPoint.transform.rotation); // Ativa o ponto de ataque para indicar que o ataque está ativo
        // _MeleeAttack_lv1.SetActive(true); // Ativa o ponto de ataque para indicar que o ataque está ativo

        _MeleeAttackTimer = 0;
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

        //Debug.Log("FireBallsAttackLv called");
        if (_cards_lv._fireBallsAttackLv == 1)
        {
            _FireBall_lv1.SetActive(true);
            _FireBall_lv1.transform.Rotate(0, 0, _speedFireBall * Time.deltaTime, Space.Self); // Aplica uma rotação contínua ao redor do eixo Z
        }
        else if (_cards_lv._fireBallsAttackLv == 2)
        {
            _FireBall_lv1.SetActive(false); // Desativa o nível anterior para evitar sobreposição
            _FireBall_lv2.SetActive(true);
            _FireBall_lv2.transform.Rotate(0, 0, _speedFireBall * Time.deltaTime, Space.Self); // Aplica uma rotação contínua ao redor do eixo Z
        }
        else if (_cards_lv._fireBallsAttackLv == 3)
        {
            _FireBall_lv2.SetActive(false); // Desativa o nível anterior para evitar sobreposição
            _FireBall_lv3.SetActive(true);
            _FireBall_lv3.transform.Rotate(0, 0, _speedFireBall * Time.deltaTime, Space.Self); // Aplica uma rotação contínua ao redor do eixo Z
        }
        else if (_cards_lv._fireBallsAttackLv == 4)
        {
            _FireBall_lv3.SetActive(false); // Desativa o nível anterior para evitar sobreposição
            _FireBall_lv4.SetActive(true);
            _FireBall_lv4.transform.Rotate(0, 0, _speedFireBall * Time.deltaTime, Space.Self); // Aplica uma rotação contínua ao redor do eixo Z
        }
        else if (_cards_lv._fireBallsAttackLv == 5)
        {
            _FireBall_lv4.SetActive(false); // Desativa o nível anterior para evitar sobreposição
            _FireBall_lv5.SetActive(true);
            _FireBall_lv5.transform.Rotate(0, 0, _speedFireBall * Time.deltaTime, Space.Self); // Aplica uma rotação contínua ao redor do eixo Z
        }

    }

    public void FlameThrower()
    {
        //Debug.Log("FlameThrowerAttackLv called");
        //

        if(_cards_lv._flameThrowerAttackLv == 1)
        {
            _FlameThrower_lv1.SetActive(true);
            _FlameThrower_lv1.transform.Rotate(0, 0, _speedFlameThrower * Time.deltaTime, Space.Self); // Aplica uma rotação contínua ao redor do eixo Z
        }
        else if (_cards_lv._flameThrowerAttackLv == 2)
        {
            _FlameThrower_lv1.SetActive(false); // Desativa o nível anterior para evitar sobreposição
            _FlameThrower_lv2.SetActive(true);
            _FlameThrower_lv2.transform.Rotate(0, 0, _speedFlameThrower * Time.deltaTime, Space.Self); // Aplica uma rotação contínua ao redor do eixo Z
        }
        else if (_cards_lv._flameThrowerAttackLv == 3)
        {
            _FlameThrower_lv2.SetActive(false); // Desativa o nível anterior para evitar sobreposição
            _FlameThrower_lv3.SetActive(true);
            _FlameThrower_lv3.transform.Rotate(0, 0, _speedFlameThrower * Time.deltaTime, Space.Self); // Aplica uma rotação contínua ao redor do eixo Z
        }
        else if (_cards_lv._flameThrowerAttackLv == 4)
        {
            _FlameThrower_lv3.SetActive(false); // Desativa o nível anterior para evitar sobreposição
            _FlameThrower_lv4.SetActive(true);
            _FlameThrower_lv4.transform.Rotate(0, 0, _speedFlameThrower * Time.deltaTime, Space.Self); // Aplica uma rotação contínua ao redor do eixo Z
        }
        else if (_cards_lv._flameThrowerAttackLv == 5)
        {
            _FlameThrower_lv4.SetActive(false); // Desativa o nível anterior para evitar sobreposição
            _FlameThrower_lv5.SetActive(true);
            _FlameThrower_lv5.transform.Rotate(0, 0, _speedFlameThrower * Time.deltaTime, Space.Self); // Aplica uma rotação contínua ao redor do eixo Z
        }

    }

    public void ExplosionFire()
    {
        //Debug.Log("Explosion Fire Attack");

        // Verifica se o nível do ataque de explosão de fogo é maior que 0 para ativar a explosão de fogo
        if (_cards_lv._explosionFireLv > 0)
            _ExplosionFire.SetActive(true);// Ativa a explosão de fogo

        //Aumenta o tamanho da explosão de fogo ate atingir o alcance definido
        _ExplosionFire.transform.localScale += Vector3.one * _speedExplosionFire * Time.deltaTime;
        if (_cards_lv._explosionFireLv == 1)
        {
            _ExplosionFireRange = 2f; // Define o alcance da explosão de fogo para o nível 1
        }
        else if(_cards_lv._explosionFireLv == 2)
        {
            _ExplosionFireRange = 3f; // Define o alcance da explosão de fogo para o nível 2
        }
        else if(_cards_lv._explosionFireLv == 3)
        {
            _ExplosionFireRange = 4f; // Define o alcance da explosão de fogo para o nível 3
        }
        else if(_cards_lv._explosionFireLv == 4)
        {
            _ExplosionFireRange = 5f; // Define o alcance da explosão de fogo para o nível 4
        }
        else if(_cards_lv._explosionFireLv == 5)
        {
            _ExplosionFireRange = 6f; // Define o alcance da explosão de fogo para o nível 5
        }

        if (_ExplosionFire.transform.localScale.x >= _ExplosionFireRange)
        {
            _ExplosionFire.transform.localScale = Vector3.zero; // Reseta o tamanho da explosão de fogo para o próximo ataque
            _ExplosionFireTimer = 0f; // Reseta o cooldown do ataque de explosão de fogo
            _ExplosionFire.SetActive(false); // Desativa a explosão de fogo quando atingir o alcance máximo
        }
    }

    public void Carvao()
    {
        
        float life = _statsPlayer._lifePlayerAtual;
        life = (float)(life + life * 0.70);
        _statsPlayer._lifePlayerAtual = life;   
    }

    public void Madeira()
    {
        float life = _statsPlayer._lifePlayerAtual;
        life = (float)(life + life * 0.50);
        _statsPlayer._lifePlayerAtual = life;
    }

    public void folha ()
    {
        float life = _statsPlayer._lifePlayerAtual;
        life = (float)(life + life * 0.25);
        _statsPlayer._lifePlayerAtual = life;
    }

    
}

