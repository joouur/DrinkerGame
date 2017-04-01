using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadSceneManager : GenericWindow
{
    [Header("Binding")]
    public static string LoadingScreenSceneName = "LoadingScreen";
    public string SceneThatIsGoindToLoad = "MainScene";

    [Header("GameObjexts")]
    public Text LoadingText;
    public CanvasGroup LoadingProgressBar;
    public CanvasGroup LoadingAnimation;
    public CanvasGroup LoadingCompleteAnimation;

    [Header("Time")]
    public float StartFadeDuration = 0.2f;
    public float ProgressBarSpeed = 2f;
    public float ExitFadeDuration = 0.2f;
    public float LoadCompleteDelay = 0.5f;

    protected AsyncOperation asyncOp;
    protected static string sceneToLoad = "";
    protected float fadeDuration = 0.5f;
    protected float fillTarget = 0f;

    public static void LoadScene(string SceneToLoad)
    {
        sceneToLoad = SceneToLoad;
        Application.backgroundLoadingPriority = ThreadPriority.High;
        if (LoadingScreenSceneName != null)
        {
            SceneManager.LoadScene(LoadingScreenSceneName);
        }
    }

    public override void OnNextWindow()
    {
        LoadScene(SceneThatIsGoindToLoad);
        base.OnNextWindow();
    }

    #region LoadingStuff
    protected virtual void OnLoading()
    {
        LoadingProgressBar.GetComponent<Image>().fillAmount = GDMath.approachValues(LoadingProgressBar.GetComponent<Image>().fillAmount, fillTarget, Time.deltaTime * ProgressBarSpeed);
    }

    protected virtual IEnumerator LoadAsync()
    {
        LoadingSetup();

        asyncOp = SceneManager.LoadSceneAsync(sceneToLoad, LoadSceneMode.Single);
        asyncOp.allowSceneActivation = false;

        while (asyncOp.progress < 0.9f)
        {
            fillTarget = asyncOp.progress;
            yield return null;
        }
        fillTarget = 1f;

        while (LoadingProgressBar.GetComponent<Image>().fillAmount != fillTarget)
        {
            yield return null;
        }

        LoadingComplete();
        yield return new WaitForSeconds(LoadCompleteDelay);

        GUIManager.Instance.FaderOn(true, ExitFadeDuration);
        yield return new WaitForSeconds(ExitFadeDuration);

        asyncOp.allowSceneActivation = true;
    }

    protected virtual void LoadingSetup()
    {
        GUIManager.Instance.Fader.gameObject.SetActive(true);
        GUIManager.Instance.Fader.GetComponent<Image>().color = new Color(0, 0, 0, 1f);
        GUIManager.Instance.FaderOn(false, ExitFadeDuration);

        LoadingCompleteAnimation.alpha = 0;
        LoadingProgressBar.GetComponent<Image>().fillAmount = 0f;
        LoadingText.text = "LOADING";

    }

    protected virtual void LoadingComplete()
    {
        LoadingCompleteAnimation.gameObject.SetActive(true);
        StartCoroutine(GDFade.FadeCanvasGroup(LoadingProgressBar, 0.1f, 0f));
        StartCoroutine(GDFade.FadeCanvasGroup(LoadingAnimation, 0.1f, 0f));
        StartCoroutine(GDFade.FadeCanvasGroup(LoadingCompleteAnimation, 0.1f, 1f));

    }
    #endregion
}
