using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Advertisements;

public class Ads_banner : MonoBehaviour
{

    public string gameId = "4099371";
    public string surfacingId = "Ads_Banner";
    public bool testMode = true;

    void Start()
    {
        Advertisement.Initialize(gameId, testMode);
        Advertisement.Banner.SetPosition(BannerPosition.TOP_RIGHT);
        StartCoroutine(ShowBannerWhenInitialized());
    }

    IEnumerator ShowBannerWhenInitialized()
    {
        while (!Advertisement.isInitialized)
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.Show(surfacingId);
    }
}