using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;


public class CambioScenes : MonoBehaviour
{
    private Scene thisScene;
    public void Scene(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
        
    }
  
}
