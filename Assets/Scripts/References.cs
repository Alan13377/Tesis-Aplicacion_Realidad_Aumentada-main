using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class References : MonoBehaviour
{
    public void LinkVanGogh()
    {
        Application.OpenURL("https://www.vangoghgallery.com/es/pinturas/autorretratos.html");
    }
    public void LinkHijo_Hombre()
    {
        Application.OpenURL("https://historia-arte.com/obras/el-hijo-del-hombre");
    }
}
