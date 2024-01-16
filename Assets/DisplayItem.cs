using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayItem : MonoBehaviour
{
    [SerializeField] WishReport report;
    ItemTemplateScriptableObject template;
    [SerializeField] Image icon;
    [SerializeField] TMP_Text itemName;
    [SerializeField] TMP_Text itemDescription;
    [SerializeField] Image background;

    [Header("Set Color")]
    [SerializeField] Color common = Color.gray;
    [SerializeField] Color rare = Color.magenta;
    [SerializeField] Color epic = Color.green;
    [SerializeField] Color legendary = Color.yellow;

    SceneManagerScript manager => GetComponent<SceneManagerScript>();
    void Awake()
    {
        report = FindObjectOfType<WishReport>();
        StartCoroutine("ShowItem");
    }

    IEnumerator ShowItem()
    {
        foreach (Item item in report.resultItem)
        {
            template = item.GetTemplate();

            icon.sprite = template.itemIcon;
            icon.SetNativeSize();
            itemName.text = template.name;
            itemDescription.text = template.description;

            switch ((int)template.itemType)
            {
                case (int)Rarity.legendary:
                    background.color = legendary;
                    break;
                case (int)Rarity.epic:
                    background.color = epic;
                    break;
                case (int)Rarity.rare:
                    background.color = rare;
                    break;
                default:
                    background.color = common;
                    break;
            }

            yield return new WaitForSeconds(2);
        }

        yield return new WaitForSeconds(1);
        manager.TransverseScene();
    }
}
