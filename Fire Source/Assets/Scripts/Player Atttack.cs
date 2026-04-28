using UnityEngine;

public class PlayerAtttack : MonoBehaviour
{
    [SerializeField] private GameObject _PlayerDirection;
    [SerializeField] private float _AttackSpeed;
    [SerializeField] private float _AttackCooldown; // Tempo de cooldown do ataque em segundos
    [SerializeField] private GameObject _MeleeAttack;
    [SerializeField] private float _ShotRangeValue; // Valor do alcance do ataque a distância
    [SerializeField] private float _MeleeRange; // Alcance do ataque corpo a corpo
    [SerializeField] private float _speedShot; // Velocidade da bala
    [SerializeField] private GameObject _Shot;

    //[SerializeField] private float _meleeRange = 1f; // Alcance do ataque corpo a corpo
    [SerializeField] private Player_controller _movement;
    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _AttackSpeed += Time.deltaTime;// Incrementa o cooldown do ataque a cada frame

        if (_AttackSpeed >= _AttackCooldown) // Verifica se o cooldown do ataque é igual ao tempo definido
        {
            MeleeAttack(); // Chama o método de ataque base
            RangeAttack(); // Chama o método de ataque à distância


        }
        else
        {
            if (_AttackSpeed >= 0.5f) // Verifica se o cooldown do ataque é igual a 0.5 segundos
            {
                _MeleeAttack.SetActive(false); // Desativa o ponto de ataque para indicar que o ataque não está  mais ativo
                //_Bala.SetActive(false);
            }
        }
    }

    public void MeleeAttack()
    {
        Debug.Log("Melee Attack");
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

        // Direcao do player para o rato
        Vector2 direction = (mousePos - _PlayerDirection.transform.position).normalized;

        // Rotacao baseada na direcao
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Aplicar rotacao
        _MeleeAttack.transform.rotation = Quaternion.Euler(0, 0, angle);

        // Posicionar a volta do player
        _MeleeAttack.transform.localPosition = (Vector3)direction * _MeleeRange;

        // ajusta aqui (testa 90 ou -90)
        angle -= 90f;

        _MeleeAttack.transform.rotation = Quaternion.Euler(0, 0, angle);

        //Instantiate(_AttackPoint, _AttackPoint.transform.position, _AttackPoint.transform.rotation); // Ativa o ponto de ataque para indicar que o ataque está ativo
        _MeleeAttack.SetActive(true); // Ativa o ponto de ataque para indicar que o ataque está ativo
        _AttackSpeed = 0f; // Reseta o cooldown do ataque

        }

    
    public void RangeAttack()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

        Vector2 direction = (mousePos - _PlayerDirection.transform.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Criar bala
        GameObject bala = Instantiate(_Shot, _PlayerDirection.transform.position, Quaternion.identity);

        // Rotação
        bala.transform.rotation = Quaternion.Euler(0, 0, angle - 90f);

        // Definir alvo (um ponto à frente)
        Vector3 target = _PlayerDirection.transform.position + (Vector3)direction * _ShotRangeValue;

        // Inicializar movimento
        bala.GetComponent<Bala>().Init(target, _speedShot);

        //_AttackSpeed = 0f;
    }
}

