using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    public Image loadingImage; // Reference to the UI Image
    public float fillRate = 0.12f; // Fill increment rate (0.12)

    private void Start()
    {
        loadingImage.fillAmount = 0.12f; // Initialize the image fill to 0
        StartCoroutine(FillLoadingBar());
    }

    IEnumerator FillLoadingBar()
    {
        while (loadingImage.fillAmount < 1f)
        {
            // Increment the fill amount
            loadingImage.fillAmount += fillRate * Time.deltaTime;

            // Ensure the fillAmount doesn't go over 1
            loadingImage.fillAmount = Mathf.Clamp(loadingImage.fillAmount, 0f, 1f);

            // Wait for the next frame
            yield return new WaitForSecondsRealtime(0.0000001f);
        }
        SceneManager.LoadScene(1);
        Debug.Log("Loading complete!");
    }
}
