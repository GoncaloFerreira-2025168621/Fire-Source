using TMPro;
using UnityEngine;

public class PilarSecundario : MonoBehaviour
{
    [SerializeField] private float _LifeAtual;
    [SerializeField] private float _LifeInicio;
    [SerializeField] public TextMeshProUGUI _textLife;
    [SerializeField] public string _id_Torre;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _LifeAtual = _LifeInicio;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_id_Torre == "norte")
        {
            _textLife.text = "Vida Torre " + _id_Torre + " " + _LifeAtual.ToString();
        }
        else if (_id_Torre == "oeste")
        {
            _textLife.text = "Vida Torre " + _id_Torre + " " + _LifeAtual.ToString();
        }
        else if ( _id_Torre == "este")
        {
            _textLife.text = "Vida Torre " + _id_Torre + " " + _LifeAtual.ToString();
        }
        if (_LifeAtual <= 0)
        {
            Destroy(gameObject);
            Application.LoadLevel(0);
            Debug.Log("Torre Sem vida");
        }
    }

    public void TakeDamage(float life)
    {
        _LifeAtual = _LifeAtual - life;
    }
}
