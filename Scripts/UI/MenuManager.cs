using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour {

  
    private Canvas quitMenu;

    public void Start()
    {
        quitMenu = GameObject.FindGameObjectWithTag(Tags.quitMenu).GetComponent<Canvas>();
        if(quitMenu != null)

        quitMenu.enabled = false;

    }

    public void Update()
    {
        if(Input.GetButtonDown(Inputs.escape))
        {
            ExitPress();
        }

    }


    public void StartLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitApplication()
    {
        Application.Quit();
    }

	
    public void ExitPress()
    {
        quitMenu.enabled = true;
    }

     public void NoPress()
        {
            quitMenu.enabled = false;

        }


}
