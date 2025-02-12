using UnityEngine;

public class EnemigoShooter : MonoBehaviour
{
    [SerializeField] public float velocidad = 5.0f;
    [SerializeField] public int ladoZonaRespawn = 40;
    private GameObject protagonista;

    private void Start()
    {
        protagonista = MiniShooterGM.instance.Protagonista();
    }
    public void DestruirObjetivo()
    {
        GetComponent<Renderer>().material.color = Random.ColorHSV();
        CambiarPosicionObjetivo();

    }

    public void CambiarPosicionObjetivo()
    {
        transform.position = new Vector3(Random.Range(-ladoZonaRespawn, ladoZonaRespawn),
                                        transform.position.y,
                                        Random.Range(-ladoZonaRespawn, ladoZonaRespawn));
    }


    // Update is called once per frame
    void Update()
    {
        Vector3 posEsteEnemigo = transform.position;
        float distanciaObjetivo = Vector3.Distance(posEsteEnemigo, protagonista.transform.position);

        if (distanciaObjetivo > 1)
        {
            transform.position = Vector3.MoveTowards(posEsteEnemigo, protagonista.transform.position, velocidad * Time.deltaTime);
        }
        else
        {
            MiniShooterGM.instance.FinPartida();
        }
    
    }
}
