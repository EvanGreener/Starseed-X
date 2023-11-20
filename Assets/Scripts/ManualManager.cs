using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManualManager : MonoBehaviour
{
    public void Back()
    {
        SceneManager.LoadScene(0);
    }
}
