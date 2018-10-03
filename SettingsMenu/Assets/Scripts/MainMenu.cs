using UnityEngine;
using UnityEngine.SceneManagement;  //Maneja la gestión de escenas

/// <summary>
/// Gestiona la escena de menú
/// </summary>
public class MainMenu : MonoBehaviour {

    /// <summary>
    /// Es llamado cuando se pulsa el botón de Play.
    /// Pasa a la siguiente escena
    /// </summary>
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /// <summary>
    /// Es llamado cuando se pulsa el botón de Quit
    /// Cierra el juego
    /// </summary>
    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
