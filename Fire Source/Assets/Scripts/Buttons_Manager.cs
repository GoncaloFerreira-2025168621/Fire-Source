using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons_Manager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Play()
    {
        SceneManager.LoadScene("Waves");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Voltar ()
    {
        SceneManager.LoadScene("Menu");
    }
}
