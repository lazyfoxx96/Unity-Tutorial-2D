using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PortalController : MonoBehaviour
{
    public enum SceneType { TOWN, ADVENTURE }
    public SceneType sceneType = SceneType.TOWN;

    public HouseFadeRoutine fade;

    public GameObject portalEffect;
    public GameObject loadingImage;

    public Image progressBar;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(PortalRoutine());
        }
    }

    IEnumerator PortalRoutine()
    {
        portalEffect.SetActive(true);
        yield return StartCoroutine(fade.Fade(3f, Color.white, true));

        loadingImage.SetActive(true);
        yield return StartCoroutine(fade.Fade(3f, Color.white, false));
        //로딩창

        while(progressBar.fillAmount < 1f)
        {
            progressBar.fillAmount += Time.deltaTime * 0.3f;

            yield return null;
        }

        if(sceneType == SceneType.TOWN)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            SceneManager.LoadScene(0);
        }


    }
}
