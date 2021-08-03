using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelChanger : MonoBehaviour {

    [SerializeField] private bool startWithWhiteFade;
    [SerializeField] private Image blackFade;
    [SerializeField] private Image whiteFade;

    Animator anim;
    int levelToLoad;

    void Start()
    {
        anim = GetComponent<Animator>();
        if (startWithWhiteFade)
            anim.Play("WhiteFade_in");
    }

    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        anim.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        if (levelToLoad == -1)
            Application.Quit();
        else
            SceneManager.LoadScene(levelToLoad);
    }

    public void FadeToLevel()
    {
        levelToLoad = SceneManager.GetActiveScene().buildIndex;
        anim.SetTrigger("FadeOut");
    }

    public void FadeToNextLevel()
    {
        levelToLoad = SceneManager.GetActiveScene().buildIndex + 1;
        anim.SetTrigger("FadeOut");
    }

    public void FadeToThisLevel()
    {
        levelToLoad = SceneManager.GetActiveScene().buildIndex;
        anim.SetTrigger("FadeOut");
    }

    public void WhiteFadeToThisLevel()
    {
        levelToLoad = SceneManager.GetActiveScene().buildIndex;
        anim.SetTrigger("WhiteFadeOut");
    }

    public void FadeToQuit()
    {
        levelToLoad = -1;
    }

    public void Fade()
    {
        anim.SetTrigger("FadeOut");
    }

    public void FadeToLevelWithDelay(int levelIndex)
    {
        levelToLoad = levelIndex;
        Invoke("Fade", 0.5f);
    }

    public void StopRaycastingUI()
    {
        blackFade.raycastTarget = true;
        whiteFade.raycastTarget = true;
    }

}
