using UnityEngine;

public class ControladorMovimientoShooter : MonoBehaviour
{


    [SerializeField] private float velocidadMovimiento = 10f;
    [SerializeField] private float sensibilidadRaton = 5f;
    [SerializeField] private float rotacionVertical = 0f;
    [SerializeField] private float limiteRotacionVertical = 45.0f; //limite de rotacion vertical
    [SerializeField] private Vector3[] posicionesCamara;
    private int posicionActual = 0;

    void Start()
    {
        Cursor.visible = false; //ocultamos el cursor
        Cursor.lockState = CursorLockMode.Locked; //bloqueamos el cursor en el centro de la pantalla
    }


    // Update is called once per frame
    void Update()
    {
        //movimiento adelante-atras
        float movimientoAdelanteAtras = Input.GetAxis("Vertical") * velocidadMovimiento * Time.deltaTime;

        //movimiento izquierda-derecha
        float movimientoIzquierdaDerecha = Input.GetAxis("Horizontal") * velocidadMovimiento * Time.deltaTime;

        //mover personaje
        transform.Translate(movimientoIzquierdaDerecha, 0, movimientoAdelanteAtras);

        //rotacion horizontal
        float rotacionRatonHorizontal = Input.GetAxis("Mouse X") * sensibilidadRaton;
        transform.Rotate(0, rotacionRatonHorizontal, 0);

        //rotacion vertical
        rotacionVertical -= Input.GetAxis("Mouse Y") * sensibilidadRaton;
        rotacionVertical = Mathf.Clamp(rotacionVertical, -limiteRotacionVertical, limiteRotacionVertical);
        Camera.main.transform.localRotation = Quaternion.Euler(rotacionVertical, 0, 0);

        //disparo
        if (Input.GetMouseButtonDown(0))
        {
            Ray rayo = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(rayo, out hit)) //si hay algun impacto
            {
                //establecemos el impacto
                hit.collider.gameObject.GetComponent<EnemigoShooter>()?.DestruirObjetivo();
            }
        }

        //cambio de camara
        if (posicionesCamara.Length >0 && Input.GetKeyDown(KeyCode.C))
        {
            posicionActual++;
            Camera.main.transform.localPosition = posicionesCamara[posicionActual % posicionesCamara.Length];
        }




    }
}
