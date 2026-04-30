//using System;
using UnityEngine;

public class Tochas : MonoBehaviour
{
    [SerializeField] private GameObject _Light;
    [SerializeField] private GameObject _Fire;
    //public GameObject tochas;
    [SerializeField] private string _TagPlayer = "Player";

    [SerializeField] private float _LightPower;
    [SerializeField] private float _FirePower;

    [SerializeField] private Spawn_Enemy _spawn_Enemy;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       /* GameObject SpawnEnemy = GameObject.FindGameObjectWithTag("SpawnEnemy");
        if (SpawnEnemy != null)
        {

            _spawn_Enemy = SpawnEnemy.GetComponent<Spawn_Enemy>();
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        if (_Light.activeSelf && _Light.transform.localScale.x < _LightPower)
        {
            ScaleProgressiveLight();
        }

        if (_Light.activeSelf && _Fire.transform.localScale.x < _FirePower)
        {
            ScaleProgressiveFire();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(_TagPlayer))
        {
            Debug.Log("Tocha acesa");
            _Light.SetActive(true);
            _spawn_Enemy._EnemysSpawn = true;
        }
    }

    public void ScaleProgressiveLight()
    {
        _Light.transform.localScale += new Vector3(0.04f, 0.02f, 0);
    }

    public void ScaleProgressiveFire()
    {
        _Fire.transform.localScale += new Vector3(0.002666f, 0.003999f, 0);
    }
}
