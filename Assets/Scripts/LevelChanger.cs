using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    public void FadeToLevel()
    {
        anim.SetTrigger("fade");
    }
    public void OnFadeComplete()
    {
        SceneManager.LoadScene("House1");
    }
}
