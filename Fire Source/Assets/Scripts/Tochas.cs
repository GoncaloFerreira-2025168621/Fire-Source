using System;
using UnityEngine;

public class Tochas : MonoBehaviour
{
    public GameObject _Fogo;
    //public GameObject tochas;
    public string _TagPlayer = "Player";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(_TagPlayer))
        {
            Debug.Log("Tocha acesa");
            _Fogo.SetActive(true);
        }
    }
}
