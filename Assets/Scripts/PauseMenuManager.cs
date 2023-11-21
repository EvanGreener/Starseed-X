using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuManager : MonoBehaviour
{
    public Canvas canvas;
    bool paused = false;

    bool wantsToResume = false;

    float resumeElapsed = 0.25f;
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            canvas.gameObject.SetActive(!paused);
            Time.timeScale = !paused ? 0 : 1;
            paused = !paused;
        }

        if (resumeElapsed < 0.25f && wantsToResume)
        {
            resumeElapsed += Time.unscaledDeltaTime;
        }
        else if (resumeElapsed >= 0.25f && wantsToResume)
        {
            paused = false;
            Time.timeScale = 1;
            wantsToResume = false;
        }

    }
    public void ResumeGame()
    {
        canvas.gameObject.SetActive(!paused);
        resumeElapsed = 0;
        wantsToResume = true;

    }
}
