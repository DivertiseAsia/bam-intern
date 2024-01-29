using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    [SerializeField] int sceneIndex;
    [SerializeField] GameObject target;
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

    public void DestroyWishandTransverseScene()
    {
        FindObjectOfType<WishReport>().DestroyWishReport();
        SceneManager.LoadScene(sceneIndex);
    }

    public void ToggleTarget()
    {
        if (target == null) return;

        if (target.activeSelf) target.SetActive(false);
        else target.SetActive(true);
    }
}
