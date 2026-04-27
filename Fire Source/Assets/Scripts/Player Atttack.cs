using UnityEngine;

public class PlayerAtttack : MonoBehaviour
{
    [SerializeField] private GameObject _PlayerDirection;
    [SerializeField] private float _AttackSpeed;
    [SerializeField] private float _AttackCooldown; // Tempo de cooldown do ataque em segundos
    [SerializeField] private GameObject _AttackPointBase;
    [SerializeField] private GameObject _AttackPointRange;
    [SerializeField] private GameObject _Bala;

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
            BaseAttack(); // Chama o método de ataque base
        }
        else
        {
            if (_AttackSpeed >= 0.5f) // Verifica se o cooldown do ataque é igual a 0.5 segundos
            {
                _AttackPointBase.SetActive(false); // Desativa o ponto de ataque para indicar que o ataque não está mais ativo
            }
        }

        RangeAttack(); // Chama o método de ataque à distância
    }

    public void BaseAttack()
    {

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

        // Direção do player para o rato
        Vector2 direction = (mousePos - _PlayerDirection.transform.position).normalized;

        // Rotação baseada na direção
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Aplicar rotação
        _AttackPointBase.transform.rotation = Quaternion.Euler(0, 0, angle);

        // Posicionar à volta do player
        _AttackPointBase.transform.localPosition = direction;

        // ajusta aqui (testa 90 ou -90)
        angle -= 90f;

        _AttackPointBase.transform.rotation = Quaternion.Euler(0, 0, angle);

        //Instantiate(_AttackPoint, _AttackPoint.transform.position, _AttackPoint.transform.rotation); // Ativa o ponto de ataque para indicar que o ataque está ativo
        _AttackPointBase.SetActive(true); // Ativa o ponto de ataque para indicar que o ataque está ativo
        _AttackSpeed = 0f; // Reseta o cooldown do ataque

        }

    
    public void RangeAttack()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

        // Direção do player para o rato
        Vector2 direction = (mousePos - _PlayerDirection.transform.position).normalized;

        // Rotação baseada na direção
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Aplicar rotação
        _Bala.transform.rotation = Quaternion.Euler(0, 0, angle);
        _AttackPointRange.transform.rotation = Quaternion.Euler(0, 0, angle);

        // Posicionar à volta do player
        _Bala.transform.localPosition = direction;
        _AttackPointRange.transform.localPosition = direction;

        // ajusta aqui (testa 90 ou -90)
        angle -= 90f;

        _Bala.transform.rotation = Quaternion.Euler(0, 0, angle);
        _AttackPointRange.transform.rotation = Quaternion.Euler(0, 0, angle);



        _Bala.transform.position = Vector2.MoveTowards(transform.position, _AttackPointRange.transform.position, _AttackSpeed * Time.deltaTime);
    }
}

