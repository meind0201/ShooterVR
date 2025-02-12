using TMPro;
using UnityEngine;

public class MiniShooterGM : MonoBehaviour
{

    [SerializeField] private GameObject protagonista;
    [SerializeField] private GameObject textoFinPartida;
    [SerializeField] private GameObject enemigos;
    public static MiniShooterGM instance;

    private void Start()
    {
        enemigos.gameObject.SetActive(true);
        textoFinPartida.gameObject.SetActive(false);
    }
    private void Awake()
    {
        instance = this;
    }

    public GameObject Protagonista()
    {
        return protagonista;
    }
    public void FinPartida()
    {
        enemigos.gameObject.SetActive(false);
        textoFinPartida.gameObject.SetActive(true); // Activa el GameObject que contiene el texto
        //Time.timeScale = 0;
    }


}
