using JetBrains.Annotations;
using UnityEngine;

public class SpawnCarts : MonoBehaviour
{
    [SerializeField] public Carts _cards;

    [SerializeField] public int _EspaceCart1;
    [SerializeField] public int _EspaceCart2;
    [SerializeField] public int _EspaceCart3;

    [SerializeField] public string _TagPlayer;

    [SerializeField] public GameObject _EspaceCart1_Obj;
    [SerializeField] public GameObject _EspaceCart2_Obj;
    [SerializeField] public GameObject _EspaceCart3_Obj;

    [SerializeField] private GameObject _Texto1;
    [SerializeField] private GameObject _Texto2;
    [SerializeField] private GameObject _Texto3;
    [SerializeField] private GameObject _Texto4;
    [SerializeField] private GameObject _Texto5;
    [SerializeField] private GameObject _Texto6;
    [SerializeField] private GameObject _Texto7;

    public int _numeroCarta1;
    public int _numeroCarta2;
    public int _numeroCarta3;

    public int[] numeros;

    public int _removeCardsOnExit = 0; // Flag para controlar se as cartas devem ser removidas ao sair do espaço

    private GameObject prefab;



    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void RandomizeCards()
    {

        // if (!collision.gameObject.CompareTag(_TagPlayer)) return;
        _Texto1.SetActive(false);
        _Texto2.SetActive(false);
        _Texto3.SetActive(false);
        _Texto4.SetActive(false);
        _Texto5.SetActive(false);
        _Texto6.SetActive(false);
        _Texto7.SetActive(false);

        Debug.Log("Player entrou no espaço de cartas");

        // Se o espaço para cartas estiver disponível e houver cartas disponíveis para escolher, Randomicamente escolhe 3 cartas para o jogador escolher
        if (_cards._cartasDisponiveis > 0)
        {
            _EspaceCart1 = Random.Range(1, 6); // 1..5
            _EspaceCart2 = Random.Range(1, 6);
            _EspaceCart3 = Random.Range(1, 6);
            Debug.Log("Cartas geradas: " + _EspaceCart1 + ", " + _EspaceCart2 + ", " + _EspaceCart3);
        }

        
        if(_cards._cartasDisponiveis <= 0)
        {
            numeros = new int[] { _numeroCarta1, _numeroCarta2, _numeroCarta3 };
            Debug.Log("Não há mais cartas disponíveis para escolher. Gerando cartas aleatórias.");
            _EspaceCart1 = numeros[Random.Range(0, numeros.Length)];
            _EspaceCart2 = numeros[Random.Range(0, numeros.Length)];
            _EspaceCart3 = numeros[Random.Range(0, numeros.Length)];
        }

       

        // Spawn das cartas nos slots
        SpawnSlot(_EspaceCart1, _EspaceCart1_Obj, 1);
        SpawnSlot(_EspaceCart2, _EspaceCart2_Obj, 2);
        SpawnSlot(_EspaceCart3, _EspaceCart3_Obj, 3);

        
    }

    public void SpawnSlot(int cartaNum, GameObject slotObj, int slotIndex)
    {
        if (slotObj == null)
        {
            Debug.LogWarning($"Slot {slotIndex} não está atribuído no inspector.");
            return;
        }

        prefab = GetPrefabByNumber(cartaNum);
        if (prefab == null)
        {
            Debug.LogWarning($"Carta número {cartaNum} inválida para o slot {slotIndex}.");
            return;
        }

        Debug.Log($"Carta {slotIndex}: instanciando {prefab.name}");

        // Remove filhos anteriores (caso exista)
        for (int i = slotObj.transform.childCount - 1; i >= 0; i--)
        {
            var child = slotObj.transform.GetChild(i);
            Destroy(child.gameObject);
        }
        



        // Instancia o prefab SEM parent e depois seta o parent — evita o aviso do Unity
        var instantiated = Instantiate(prefab, slotObj.transform.position, Quaternion.identity);
        instantiated.transform.SetParent(slotObj.transform, false);
        // Ajuste local para garantir alinhamento
        instantiated.transform.localPosition = Vector3.zero;

        // Ativa o slot (se estiver desativado)
        if (!slotObj.activeSelf) slotObj.SetActive(true);
        
    }

    private GameObject GetPrefabByNumber(int num)
    {
        switch (num)
        {
            case 1: return _cards._Card_Melee;
            case 2: return _cards._Card_Range;
            case 3: return _cards._Card_ExplosionFire;
            case 4: return _cards._Card_FlameThrower;
            case 5: return _cards._Card_FireBalls;
            default: return null;
        }
    }

    //Remove as cartas do ecra quando o jogador clicar em uma delas ou sair do espaço de cartas
    /*
      // Instancia o prefab SEM parent e depois seta o parent — evita o aviso do Unity
        var instantiated = Instantiate(prefab, slotObj.transform.position, Quaternion.identity);
        instantiated.transform.SetParent(slotObj.transform, false);
        // Ajuste local para garantir alinhamento
     */

    public void RemoveCardCheck()
    {
        _removeCardsOnExit = 1;
        RemoveCards();
    }
    private void RemoveCards()
    {
        if (_removeCardsOnExit == 1)
        {
            ClearSlot(_EspaceCart1_Obj);
            ClearSlot(_EspaceCart2_Obj);
            ClearSlot(_EspaceCart3_Obj);
            //_removeCardsOnExit = 0;
        }
    }

    private void ClearSlot(GameObject slotObj)
    {
        if (slotObj == null) return;

        for (int i = slotObj.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(slotObj.transform.GetChild(i).gameObject);
        }
    }

    public void AtributiteMeleeCard()
    {
        // Atribui a carta de ataque corpo a corpo ao primeiro slot disponível
        if (_numeroCarta1 == 0)
        {
            _numeroCarta1 = 1;
            GetPrefabByNumber(_numeroCarta1);
        }
        else if (_numeroCarta2 == 0 && _numeroCarta1 != 1)
        {
            _numeroCarta2 = 1;
            GetPrefabByNumber(_numeroCarta2);
        }
        else if (_numeroCarta3 == 0 && _numeroCarta1 != 1 && _numeroCarta2 != 1)
        {
            _numeroCarta3 = 1;
            GetPrefabByNumber(_numeroCarta3);
        }
    }
    public void AtributiteRangeCard()
    {
        // Atribui a carta de ataque corpo a corpo ao primeiro slot disponível
        if (_numeroCarta1 == 0)
        {
            _numeroCarta1 = 2;
            GetPrefabByNumber(_numeroCarta1);
        }
        else if (_numeroCarta2 == 0 && _numeroCarta1 != 2)
        {
            _numeroCarta2 = 2;
            GetPrefabByNumber(_numeroCarta2);
        }
        else if (_numeroCarta3 == 0 && _numeroCarta1 != 2 && _numeroCarta2 != 2)
        {
            _numeroCarta3 = 2;
            GetPrefabByNumber(_numeroCarta3);
        }
    }
    public void AtributiteExplosionFireCard()
    {
        if (_numeroCarta1 == 0)
        {
            _numeroCarta1 = 3;
            GetPrefabByNumber(_numeroCarta1);
        }
        else if (_numeroCarta2 == 0 && _numeroCarta1 != 3)
        {
            _numeroCarta2 = 3;
            GetPrefabByNumber(_numeroCarta2);
        }
        else if (_numeroCarta3 == 0 && _numeroCarta1 != 3 && _numeroCarta2 != 3)
        {
            _numeroCarta3 = 3;
            GetPrefabByNumber(_numeroCarta3);
        }
    }
    
    public void AtributiteFlameThrowerCard()
    {
        if (_numeroCarta1 == 0)
        {
            _numeroCarta1 = 4;
            GetPrefabByNumber(_numeroCarta1);
        }
        else if (_numeroCarta2 == 0 && _numeroCarta1 != 4)
        {
            _numeroCarta2 = 4;
            GetPrefabByNumber(_numeroCarta2);
        }
        else if (_numeroCarta3 == 0 && _numeroCarta1 != 4 && _numeroCarta2 != 4)
        {
            _numeroCarta3 = 4;
            GetPrefabByNumber(_numeroCarta3);
        }
    }
    
    public void AtributiteFireBallsCard()
    {
        if(_numeroCarta1 == 0)
        {
            _numeroCarta1 = 5;
            GetPrefabByNumber(_numeroCarta1);
        }
        else if(_numeroCarta2 == 0 && _numeroCarta1 != 5)
        {
            _numeroCarta2 = 5;
            GetPrefabByNumber(_numeroCarta2);
        }
        else if(_numeroCarta3 == 0 && _numeroCarta1 != 5 && _numeroCarta2 != 5)
        {
            _numeroCarta3 = 5;
            GetPrefabByNumber(_numeroCarta3);
        }
    }


    public void AtivarTextos()
    {
        _Texto1.SetActive(true);
        _Texto2.SetActive(true);
        _Texto3.SetActive(true);
        _Texto4.SetActive(true);
        _Texto5.SetActive(true);
        _Texto6.SetActive(true);
        _Texto7.SetActive(true);
    }
}
