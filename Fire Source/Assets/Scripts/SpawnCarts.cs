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

    // Guard para garantir que as cartas só sejam geradas/instanciadas uma vez
    private bool _hasSpawned = false;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_hasSpawned) return;
        if (!collision.gameObject.CompareTag(_TagPlayer)) return;

        Debug.Log("Player entrou no espaço de cartas");

        // Se o espaço para cartas estiver disponível e houver cartas disponíveis para escolher, Randomicamente escolhe 3 cartas para o jogador escolher
        if (_cards._cartasDisponiveis > 0)
        {
            _EspaceCart1 = Random.Range(1, 6); // 1..5
            _EspaceCart2 = Random.Range(1, 6);
            _EspaceCart3 = Random.Range(1, 6);
            Debug.Log("Cartas geradas: " + _EspaceCart1 + ", " + _EspaceCart2 + ", " + _EspaceCart3);
        }

        // Spawn das cartas nos slots
        SpawnSlot(_EspaceCart1, _EspaceCart1_Obj, 1);
        SpawnSlot(_EspaceCart2, _EspaceCart2_Obj, 2);
        SpawnSlot(_EspaceCart3, _EspaceCart3_Obj, 3);

        // Marca como já gerado para não repetir
        _hasSpawned = true;
    }

    private void SpawnSlot(int cartaNum, GameObject slotObj, int slotIndex)
    {
        if (slotObj == null)
        {
            Debug.LogWarning($"Slot {slotIndex} não está atribuído no inspector.");
            return;
        }

        GameObject prefab = GetPrefabByNumber(cartaNum);
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

        // Instancia o prefab como filho do slot, mantendo a posição do slot
        var instantiated = Instantiate(prefab, slotObj.transform.position, Quaternion.identity, slotObj.transform);
        // Ajuste local (se necessário) para garantir alinhamento
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
    public void ClearSlots()
    {
        // Remove os filhos dos slots para limpar as cartas exibidas
        Destroy(_EspaceCart1_Obj);
        Destroy(_EspaceCart2_Obj);
        Destroy(_EspaceCart3_Obj);
        // Marca como não gerado para permitir nova geração no futuro
        _hasSpawned = false;
    }

   
}
