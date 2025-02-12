
using UnityEngine;
using UnityEngine.SceneManagement;
public class ReiniciarEscena : MonoBehaviour
{

    public void Recargar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
