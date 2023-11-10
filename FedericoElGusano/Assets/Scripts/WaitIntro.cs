using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaitIntro : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitForIntro());
    }
    IEnumerator WaitForIntro()
    {
        yield return new WaitForSeconds(8);
        SceneManager.LoadScene(1);
    }

}
