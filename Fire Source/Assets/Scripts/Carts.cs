using UnityEngine;

public class Carts : MonoBehaviour
{
    [SerializeField] private int _meleeAttackLv;
    [SerializeField] private int _rangeAttackLv;
    [SerializeField] private int _explosionFireLv;
    [SerializeField] private int _flameThrowerAttackLv;
    [SerializeField] private int _fireBallsAttackLv;
    [SerializeField] private int _card_melee = 1;
    [SerializeField] private int _card_range = 2;
    [SerializeField] private int _card_explosionFire = 3;
    [SerializeField] private int _card_flameThrower = 4;
    [SerializeField] private int _card_fireBalls = 5;
    [SerializeField] private int _card_empty = 0;
    [SerializeField] public int _card_atual;
    [SerializeField] public int _Card_1;
    [SerializeField] public int _Card_2;
    [SerializeField] public int _Card_3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _Card_1 = 0;
        _Card_2 = 0;
        _Card_3 = 0;
        _card_atual = _Card_1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MeleeAttackLv()
    {
        _card_empty = _card_melee;
        _meleeAttackLv++;
        if (_meleeAttackLv > 5)
        {
            _meleeAttackLv = 5; // Limita o nível máximo a 5
        }

    }

    public void RangeAttackLv()
    {

    }

    public void ExplosionFireLv()
    {
    }

    public void FlameThrowerAttackLv()
    {

    }

    public void FireBallsAttackLv()
    {


    }

    public void VerificationCard()
    {
        if (_card_atual == _Card_1)
        {
            _card_atual = _Card_2;
            _Card_1 = _card_empty;
        }
    }
}
