using UnityEngine;

public class Carts : MonoBehaviour
{
    [SerializeField] private int _meleeAttackLv;
    [SerializeField] private int _rangeAttackLv;
    [SerializeField] private int _explosionFireLv;
    [SerializeField] private int _flameThrowerAttackLv;
    [SerializeField] private int _fireBallsAttackLv;
    [SerializeField] public int _card_melee = 1;
    [SerializeField] public int _card_range = 2;
    [SerializeField] public int _card_explosionFire = 3;
    [SerializeField] public int _card_flameThrower = 4;
    [SerializeField] public int _card_fireBalls = 5;
    [SerializeField] public int _card_escolhida = 0;
    [SerializeField] public int _card_atual;
    [SerializeField] public int _Card_1;
    [SerializeField] public int _Card_2;
    [SerializeField] public int _Card_3;
    [SerializeField] public int _Espaco_Cards_Disponivel = 3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _Card_1 = 0;
        _Card_2 = 1;
        _Card_3 = 2;
        _card_atual = _Card_1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MeleeAttackLv()
    {
        _card_escolhida = _card_melee;
        _meleeAttackLv++;
        if (_meleeAttackLv > 5)
        {
            _meleeAttackLv = 5; // Limita o nível máximo a 5
        }
        _Espaco_Cards_Disponivel--;

    }

    public void RangeAttackLv()
    {
        _card_escolhida = _card_range;
        _rangeAttackLv++;
        if (_rangeAttackLv > 5)
        {
            _rangeAttackLv = 5; // Limita o nível máximo a 5
        }
    }

    public void ExplosionFireLv()
    {
        _card_escolhida = _card_explosionFire;
        _explosionFireLv++;
        if (_explosionFireLv > 5)
        {
            _explosionFireLv = 5; // Limita o nível máximo a 5
        }
    }

    public void FlameThrowerAttackLv()
    {
        _card_escolhida = _card_flameThrower;
        _flameThrowerAttackLv++;
        if (_flameThrowerAttackLv > 5)
        {
            _flameThrowerAttackLv = 5; // Limita o nível máximo a 5
        }
    }

    public void FireBallsAttackLv()
    {
        _card_escolhida = _card_fireBalls;
        _fireBallsAttackLv++;
        if (_fireBallsAttackLv > 5)
        {
            _fireBallsAttackLv = 5; // Limita o nível máximo a 5
        }
    }

    public void VerificationCard()
    {
        //Verifica se a cartas disponiveis (Card_1, Card_2, Card_3) sao diferentes da carta escolhida (_card_escolhida) e se a carta atual (_card_atual) é diferente da carta escolhida (_card_escolhida)
        if (_card_atual != _card_escolhida)
        {
            if (_card_atual == _Card_1)
            {
                _card_atual = _Card_2;
                _Card_1 = _card_escolhida;
            }
            else if (_card_atual == _Card_2 && _Card_1 != 0)
            {
                _card_atual = _Card_3;
                _Card_2 = _card_escolhida;
            }
            else if (_card_atual == _Card_3 && _Card_1 != 0 && _Card_2 != 0)
            {
                _Card_3 = _card_escolhida;
            }
        }


    }
}
