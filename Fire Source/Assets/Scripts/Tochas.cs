//using System;
using TMPro;
using UnityEngine;

public class Tochas : MonoBehaviour
{
    [SerializeField] private GameObject _Light;
    [SerializeField] private GameObject _Fire;

    [SerializeField] private GameObject _Fire2;
    [SerializeField] private GameObject _Fire3;
    [SerializeField] private GameObject _Fire4;

    [SerializeField] private GameObject _Light1;
    [SerializeField] private GameObject _Light2;
    [SerializeField] private GameObject _Light3;
    //public GameObject tochas;
    [SerializeField] private string _TagPlayer = "Player";

    [SerializeField] private float _LightPowerX;
    //[SerializeField] private float _LightPowerY;
    [SerializeField] private float _FirePower;

    [SerializeField] private Waves _waves;
    [SerializeField] private float _LifeAtual;
    [SerializeField] private float _LifeInicio;
    [SerializeField] public TextMeshProUGUI _textLife;

    [SerializeField] public SpawnCarts _spawnCarts;

    private bool _hasSpawned = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        _LifeAtual = _LifeInicio;
    }

    // Update is called once per frame
    void Update()
    {
        if (_Light.activeSelf && _Light.transform.localScale.x < _LightPowerX)
        {
            ScaleProgressiveLight();
        }

        if (_Light.activeSelf && _Fire.transform.localScale.x < _FirePower)
        {
            ScaleProgressiveFire();
        }

        if (_LifeAtual < 0)
        {
            Destroy(gameObject);
            Application.LoadLevel(0);
            Debug.Log("Torre Sem vida");
        }
        _textLife.text = "Vida da Torre Principal" + _LifeAtual.ToString();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (_hasSpawned == true) return;
        if (other.gameObject.CompareTag(_TagPlayer))
        {
            _spawnCarts.RandomizeCards();
            Debug.Log("Tocha acesa");
            _Light.SetActive(true);
            _Light1.SetActive(true);
            _Light2.SetActive(true);
            _Light3.SetActive(true);
            _hasSpawned = true;
        }
        // Marca como já gerado para não repetir
        
    }

    public void ScaleProgressiveLight()
    {
        _Light.transform.localScale += new Vector3(0.04f, 0.06f, 0);
        _Light1.transform.localScale += new Vector3(0.02f, 0.03f, 0);
        _Light2.transform.localScale += new Vector3(0.02f, 0.03f, 0);
        _Light3.transform.localScale += new Vector3(0.02f, 0.03f, 0);
    }

    public void ScaleProgressiveFire()
    {
        _Fire.transform.localScale += new Vector3(0.002666f, 0.003999f, 0);
    }

    public void TakeDamage(float life)
    {
        _LifeAtual = _LifeAtual - life;
    }
}
