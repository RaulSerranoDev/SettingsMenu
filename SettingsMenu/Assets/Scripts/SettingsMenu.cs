using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class SettingsMenu : MonoBehaviour {

    #region References
    public AudioMixer AudioMixer;
    public Dropdown ResolutionDropdown;
    #endregion

    /// <summary>
    /// Lista de resoluciones de las que dispone el dispositivo
    /// </summary>
    private Resolution[] resolutions;

    /// <summary>
    /// Inicializa ResolutionDropdown con los valores disponible
    /// </summary>
    private void Start()
    {
        //Obtenemos que resoluciones tenemos disponibles en el dispositivo
        resolutions = Screen.resolutions;

        //Queremos establecer las opciones disponibles en el Dropdown
        ResolutionDropdown.ClearOptions();

        //Lista de strings con todas las opciones
        List<string> options = new List<string>();

        //Resolución actual
        int currentResolutionIndex = 0;

        //Guardamos las opciones en la lista
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            //Guardamos la resolución actual
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
                currentResolutionIndex = i;    
        }

        //Añadimos las opciones al dropdown
        ResolutionDropdown.AddOptions(options);

        //Establecemos la resolución actual
        ResolutionDropdown.value = currentResolutionIndex;
        ResolutionDropdown.RefreshShownValue();
    }

    /// <summary>
    /// Es llamado cuando se modifica un valor del resolutionDropdown.
    /// Actualiza la resolución
    /// </summary>
    /// <param name="resolutionIndex"></param>
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    /// <summary>
    /// Recibe el valor del slider y modifica el audio principal al nuevo valor
    /// </summary>
    /// <param name="volume"></param>
    public void SetVolume(float volume)
    {
        AudioMixer.SetFloat("volume", volume);
    }

    /// <summary>
    /// Es llamado cuando se modifica el Dropdown y modifica la calidad gráfica
    /// </summary>
    /// <param name="qualityIndex"></param>
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    /// <summary>
    /// Es llamado cuando se modifica el Tipo de ventana. Modifica la ventana
    /// TODO: No funciona correctamente
    /// </summary>
    /// <param name="isFullscreen"></param>
    public void SetFullscreenMode(int fullScreenIndex)
    {
       Screen.fullScreenMode = (FullScreenMode)fullScreenIndex;
    }
}
