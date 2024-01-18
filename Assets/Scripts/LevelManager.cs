using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void ReiniciarJuego() 
    {
        SceneManager.LoadScene(0);
    }

    public void CargarEscena(int indiceEscena) 
    {
        SceneManager.LoadScene(indiceEscena);
    }
 
}
