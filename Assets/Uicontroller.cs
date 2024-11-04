using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Uicontroller : MonoBehaviour
{
    public Button Bt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void click()
    {
        SceneManager.LoadScene("stage1");
    }
}
