using UnityEngine;

public class ColisionBau : MonoBehaviour
{
    [SerializeField] private string _playerTag = "Player"; // Tag do jogador
    [SerializeField] private SpawnCarts _spawnCarts;

    // Guard para garantir que as cartas só sejam geradas/instanciadas uma vez
    private bool _hasSpawned = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        _spawnCarts._removeCardsOnExit = 0; // Reseta a flag para permitir que as cartas sejam removidas ao sair do espaço
        if (_hasSpawned) return;

        if (collision.gameObject.CompareTag(_playerTag))
        {
            Debug.Log("Player entrou no baú");
            _spawnCarts.RandomizeCards(); // Chama o método para randomizar as cartas
            // Aqui você pode adicionar a lógica para o que acontece quando o jogador entra no baú

        }

        // Marca como já gerado para não repetir
        _hasSpawned = true;
    }
}
