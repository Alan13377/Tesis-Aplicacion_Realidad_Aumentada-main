using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Events;

public class VirtualCompartir : MonoBehaviour
{
	private string shareMessage;
	public GameObject definedButton;
	public UnityEvent Onclick = new UnityEvent();
	public void ClickShareButton()
	{
		shareMessage = "Gracias por utilizar la aplicacion";
		StartCoroutine(TakeScreenshotAndShare());
	}

	private void Update()
	{
		var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit Hit;
		if (Input.GetMouseButtonDown(0))
		{
			if (Physics.Raycast(ray, out Hit) && Hit.collider.gameObject == gameObject)
			{
				ClickShareButton();
			}

		}
	}

	private IEnumerator TakeScreenshotAndShare()
	{
		yield return new WaitForEndOfFrame();

		Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
		ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
		ss.Apply();

		string filePath = Path.Combine(Application.temporaryCachePath, "shared img.png");
		File.WriteAllBytes(filePath, ss.EncodeToPNG());

		// To avoid memory leaks
		Destroy(ss);

		new NativeShare().AddFile(filePath)
			.SetSubject("Subject goes here").SetText(shareMessage).Share();


	}
}