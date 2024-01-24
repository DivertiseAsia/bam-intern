using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    [SerializeField] int sceneIndex;
    ManageMoney money => GetComponent<ManageMoney>();
    // Start is called before the first frame update
    public void TransverseScene()
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void CheckMoneyTransverseScene()
    {
        if (money.nextScene)
        {
            money.nextScene = false;
            TransverseScene();
        }
    }
}
