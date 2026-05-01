using TMPro;
using UnityEngine;

public class StatsPlayer : MonoBehaviour
{

    [SerializeField] public float _lifePlayer;
    [SerializeField] public float _lifePlayerAtual;
    [SerializeField] public TextMeshProUGUI _textLife;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _lifePlayerAtual = _lifePlayer;
    }

    // Update is called once per frame
    void Update()
    {
        if (_lifePlayerAtual < 0)
        {
            Destroy(gameObject);
            Application.LoadLevel(0);
            Debug.Log("Player Sem vida");
        }
        _textLife.text = "Vida da Torre " + _lifePlayerAtual.ToString();

        if (_lifePlayerAtual >= _lifePlayer)
        {
            _lifePlayerAtual = _lifePlayer;
        }
    }

    public void TakeDamage(float life)
    {
        _lifePlayerAtual = _lifePlayerAtual - life;
        
    }
}
