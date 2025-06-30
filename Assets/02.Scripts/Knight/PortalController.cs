using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PortalController : MonoBehaviour
{
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

        //씬 변경
        SceneManager.LoadScene(1);

    }
}
