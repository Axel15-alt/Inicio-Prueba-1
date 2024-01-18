using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Boton3D : MonoBehaviour
{
    public UnityEvent action;
    public Material normal;
    public Material onHover;
    [SerializeField] 
    MeshRenderer rnd;
    private void OnMouseEnter()
    {
        //Debug.Log("Mouse sobre mi");
        rnd.material = onHover;
    }

    private void OnMouseExit()
    {
        rnd.material = normal;
    }

    private void OnMouseDown()
    {
        action.Invoke();
        //Debug.Log("me picaron!"); 
       // SceneManager.LoadScene(0);
    }

}
