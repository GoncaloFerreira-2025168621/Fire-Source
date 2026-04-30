using UnityEngine;

public class Carts : MonoBehaviour
{
    //public bool _DestroyCards = false;

    [Header("PlayerAttack")]
    [SerializeField] public PlayerAttack _PlayerAttack;


    [Header("Card Objetos")]
    [SerializeField] public GameObject _Card_Melee;// Prefab da carta de ataque corpo a corpo com o numero 1
    [SerializeField] public GameObject _Card_Range;// Prefab da carta de ataque a distância com o numero 2
    [SerializeField] public GameObject _Card_ExplosionFire;// Prefab da carta de ataque de explosão de fogo com o numero 3
    [SerializeField] public GameObject _Card_FlameThrower;// Prefab da carta de ataque de lança chamas com o numero 4
    [SerializeField] public GameObject _Card_FireBalls;// Prefab da carta de ataque de bola de fogo com o numero 5
    [SerializeField] public GameObject _CartaSelecionada_Obj;// Prefab da carta escolhida para ser adicionada ao espaço de cartas
    [SerializeField] public SpawnCarts _spawnCarts;


    [Header("Cards Levels")]
    [SerializeField] public int _meleeAttackLv;
    [SerializeField] public int _rangeAttackLv;
    [SerializeField] public int _explosionFireLv;
    [SerializeField] public int _flameThrowerAttackLv;
    [SerializeField] public int _fireBallsAttackLv;

    [Header("Cards Disponiveis")]
    [SerializeField] public int _card_melee = 1;
    [SerializeField] public int _card_range = 2;
    [SerializeField] public int _card_explosionFire = 3;
    [SerializeField] public int _card_flameThrower = 4;
    [SerializeField] public int _card_fireBalls = 5;
    [SerializeField] public int _CartaEscolhida;
    //[SerializeField] public int _card_atual;
    [SerializeField] public int _Card_1;
    [SerializeField] public int _Card_2;
    [SerializeField] public int _Card_3;
    [SerializeField] public bool _Espaco_Cards_Disponivel;
    [SerializeField] public int _cartasDisponiveis;

    [Header("Cards Espaço")]
    [SerializeField] public bool _Space_Cards1;
    [SerializeField] public bool _Space_Cards2;
    [SerializeField] public bool _Space_Cards3;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject SpawnCardsObj = GameObject.FindGameObjectWithTag("GameManager");
        if (SpawnCardsObj != null)
        {

            _spawnCarts = SpawnCardsObj.GetComponent<SpawnCarts>();
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _meleeAttackLv = 0;
            _rangeAttackLv = 0;
            _explosionFireLv = 0;
            _flameThrowerAttackLv = 0;
            _fireBallsAttackLv = 0;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _meleeAttackLv = 5;
            _rangeAttackLv = 5;
            _explosionFireLv = 5;
            _flameThrowerAttackLv = 5;
            _fireBallsAttackLv = 5;
        }
    }

    public void MeleeAttackLv()
    {
        Debug.Log("MeleeAttackLv called");
        _meleeAttackLv++;
        if (_meleeAttackLv > 5)
        {
            _meleeAttackLv = 5; // Limita o nível máximo a 5
        }

        if (_meleeAttackLv == 1)// Se for a primeira vez que a carta de ataque corpo a corpo é escolhida, decrementa o número de cartas disponíveis
            _cartasDisponiveis--;

        _CartaEscolhida = _card_melee;
        _CartaSelecionada_Obj = _Card_Melee;
        _PlayerAttack.MeleeAttack();
        _spawnCarts._EspaceCart1_Obj.SetActive(false);
        _spawnCarts._EspaceCart2_Obj.SetActive(false);
        _spawnCarts._EspaceCart3_Obj.SetActive(false);

        
    }

    public void RangeAttackLv()
    {
        Debug.Log("RangeAttackLv called");
        _rangeAttackLv++;
        if (_rangeAttackLv > 5)
        {
            _rangeAttackLv = 5; // Limita o nível máximo a 5
        }

        if (_rangeAttackLv == 1)// Se for a primeira vez que a carta de ataque a distância é escolhida, decrementa o número de cartas disponíveis
            _cartasDisponiveis--;

        _CartaEscolhida = _card_range;
        _CartaSelecionada_Obj = _Card_Range;
        _PlayerAttack.RangeAttack();
        _spawnCarts._EspaceCart1_Obj.SetActive(false);
        _spawnCarts._EspaceCart2_Obj.SetActive(false);
        _spawnCarts._EspaceCart3_Obj.SetActive(false);

        
        
    }

    public void ExplosionFireLv()
    {
        Debug.Log("ExplosionFireLv called");
        _CartaEscolhida = _card_explosionFire;
        _explosionFireLv++;
        if (_explosionFireLv > 5)
        {
            _explosionFireLv = 5; // Limita o nível máximo a 5
        }

        if( _explosionFireLv == 1)// Se for a primeira vez que a carta de explosão de fogo é escolhida, decrementa o número de cartas disponíveis
            _cartasDisponiveis--;

        _CartaSelecionada_Obj = _Card_ExplosionFire;
        _PlayerAttack.ExplosionFire();
        _spawnCarts._EspaceCart1_Obj.SetActive(false);
        _spawnCarts._EspaceCart2_Obj.SetActive(false);
        _spawnCarts._EspaceCart3_Obj.SetActive(false);

        
    }

    public void FlameThrowerAttackLv()
    {
        
        _CartaEscolhida = _card_flameThrower;
        _flameThrowerAttackLv++;
        if (_flameThrowerAttackLv > 5)
        {
            _flameThrowerAttackLv = 5; // Limita o nível máximo a 5
        }

        if (_flameThrowerAttackLv == 1)// Se for a primeira vez que a carta de lança chamas é escolhida, decrementa o número de cartas disponíveis
            _cartasDisponiveis--;

        _CartaSelecionada_Obj = _Card_FlameThrower;
        _PlayerAttack.FlameThrower();
        _spawnCarts._EspaceCart1_Obj.SetActive(false);
        _spawnCarts._EspaceCart2_Obj.SetActive(false);
        _spawnCarts._EspaceCart3_Obj.SetActive(false);

        
    }

    public void FireBallsAttackLv()
    {
        Debug.Log("FireBallsAttackLv called");
        _CartaEscolhida = _card_fireBalls;
        _fireBallsAttackLv++;
        if (_fireBallsAttackLv > 5)
        {
            _fireBallsAttackLv = 5; // Limita o nível máximo a 5
        }

        if (_fireBallsAttackLv == 1)// Se for a primeira vez que a carta de bola de fogo é escolhida, decrementa o número de cartas disponíveis
        {
            _cartasDisponiveis--;
        }

        _CartaSelecionada_Obj = _Card_FireBalls;
        _PlayerAttack.FireBalls();
        _spawnCarts._EspaceCart1_Obj.SetActive(false);
        _spawnCarts._EspaceCart2_Obj.SetActive(false);
        _spawnCarts._EspaceCart3_Obj.SetActive(false);

        
    }

    public void VerificationCard()
    {
        
    }
}
