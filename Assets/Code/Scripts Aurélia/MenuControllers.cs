using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        Debug.Log("Changement de scène vers : " + sceneName); // Affiche le nom de la scène à charger dans la console
        SceneManager.LoadScene(sceneName); 
    }

    public void Quit()
    {
        Debug.Log("Quitter l'application"); // Affiche un message lors de la tentative de quitter
        Application.Quit();
    }
}
