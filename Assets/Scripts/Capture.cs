using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Capture : MonoBehaviour
{
    public Camera cam;
    private string imagePath;
    void Start()
    {
        
    }


    public void CapturarImagen()
    {


        StartCoroutine(TakeScreenshotAndSave());

    }


    private IEnumerator TakeScreenshotAndSave()
    {
        yield return new WaitForEndOfFrame();

        RenderTexture rt = new RenderTexture(Screen.width, Screen.height, 24);
        Texture2D photo = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);

        Camera.main.targetTexture = rt;
        cam.targetTexture = rt;

        Camera.main.Render();

        cam.Render();

        RenderTexture.active = rt;

        photo.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);

        RenderTexture.active = null;
        Camera.main.targetTexture = null;
        cam.targetTexture = null;

        Destroy(rt);
        photo.Apply();

        var bytes = photo.EncodeToPNG();
        Destroy(photo);





        imagePath = System.IO.Path.Combine(Application.persistentDataPath, "Ar Exposicion" + DateTime.Now.ToString("MMddyyyyHHmmss") + ".png");



        Debug.Log("Foto Android dcim Guardada en: " + imagePath);



        Debug.LogWarning("Photo in " + imagePath);

        // DirectorioImagenAlojada.text = "Photo in " + imagePath;////////

        System.IO.File.WriteAllBytes(imagePath, bytes);


        yield return new WaitForEndOfFrame();

        NativeGallery.SaveImageToGallery(imagePath, "AR EXPOSICION", DateTime.Now.ToString("MMddyyyyHHmmss") + ".png");



    }
}
