using UnityEngine;

public class Carts : MonoBehaviour
{
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
        GameObject SpawnCardsObj = GameObject.FindGameObjectWithTag("SpawnCarts");
        if (SpawnCardsObj != null)
        {

            _spawnCarts = SpawnCardsObj.GetComponent<SpawnCarts>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MeleeAttackLv()
    {
        _meleeAttackLv++;
        if (_meleeAttackLv > 5)
        {
            _meleeAttackLv = 5; // Limita o nível máximo a 5
        }
        _CartaEscolhida = _card_melee;
        _CartaSelecionada_Obj = _Card_Melee;
        _PlayerAttack.MeleeAttack();
        _spawnCarts._EspaceCart1_Obj.SetActive(false);
        _spawnCarts._EspaceCart2_Obj.SetActive(false);
        _spawnCarts._EspaceCart3_Obj.SetActive(false);
    }

    public void RangeAttackLv()
    {
        _rangeAttackLv++;
        if (_rangeAttackLv > 5)
        {
            _rangeAttackLv = 5; // Limita o nível máximo a 5
        }
        _CartaEscolhida = _card_range;
        _CartaSelecionada_Obj = _Card_Range;
        _PlayerAttack.RangeAttack();
        _spawnCarts._EspaceCart1_Obj.SetActive(false);
        _spawnCarts._EspaceCart2_Obj.SetActive(false);
        _spawnCarts._EspaceCart3_Obj.SetActive(false);
    }

    public void ExplosionFireLv()
    {
        _CartaEscolhida = _card_explosionFire;
        _explosionFireLv++;
        if (_explosionFireLv > 5)
        {
            _explosionFireLv = 5; // Limita o nível máximo a 5
        }
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
        _CartaSelecionada_Obj = _Card_FlameThrower;
        _PlayerAttack.FlameThrower();
        _spawnCarts._EspaceCart1_Obj.SetActive(false);
        _spawnCarts._EspaceCart2_Obj.SetActive(false);
        _spawnCarts._EspaceCart3_Obj.SetActive(false);
    }

    public void FireBallsAttackLv()
    {
        _CartaEscolhida = _card_fireBalls;
        _fireBallsAttackLv++;
        if (_fireBallsAttackLv > 5)
        {
            _fireBallsAttackLv = 5; // Limita o nível máximo a 5
        }
        _CartaSelecionada_Obj = _Card_FireBalls;
        _PlayerAttack.FireBalls();

    }

    public void VerificationCard()
    {
        //true = carta disponivel False = carta indisponivel
        //Verifica se a carta escolhida já está presente em um dos espaços de cartas e se ainda há espaço disponível para adicionar a carta
        if ((_CartaEscolhida != _Card_1 && _cartasDisponiveis > 0) 
            && (_CartaEscolhida != _Card_2 && _cartasDisponiveis > 0) 
            && (_CartaEscolhida != _Card_3 && _cartasDisponiveis > 0))
            {
                //Verifica se o espaço para a carta está disponível e atribui a carta escolhida ao espaço correspondente
                if (_Space_Cards1 == _Espaco_Cards_Disponivel)
                {
                    _cartasDisponiveis--;
                    _Card_1 = _CartaEscolhida;
                    _Space_Cards1 = false;
                    _spawnCarts._EspaceCart1_Obj = _CartaSelecionada_Obj;
                }
                else if (_Space_Cards2 == _Espaco_Cards_Disponivel)
                {
                    _cartasDisponiveis--;
                    _Card_2 = _CartaEscolhida;
                    _Space_Cards2 = false;
                    _spawnCarts._EspaceCart2_Obj = _CartaSelecionada_Obj;
            }
                else if (_Space_Cards3 == _Espaco_Cards_Disponivel)
                {
                    _cartasDisponiveis--;
                    _Card_3 = _CartaEscolhida;
                    _Space_Cards3 = false;
                    _spawnCarts._EspaceCart3_Obj = _CartaSelecionada_Obj;
            }
            }
        else
        {
            _Espaco_Cards_Disponivel = true;
        }

        

    }
}
