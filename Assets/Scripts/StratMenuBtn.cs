using UnityEngine;
using UnityEngine.SceneManagement;
public class StratMenuBtn : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MenuButton()
    {

        SceneManager.LoadScene(0);
    }
    public void StartButton() 
    {

        SceneManager.LoadScene(1);
    }
    public void TutorialButton()
    {

        SceneManager.LoadScene(2);
    }
    public void QuitButton()
    {

        Application.Quit();
    }
}
