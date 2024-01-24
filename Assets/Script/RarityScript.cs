using UnityEngine;
using UnityEditor;
using System;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "RarityScript", menuName = "Project Exclusive/ Rarity")]
public class RarityScript: ScriptableSingleton<RarityScript>
{
    [Header("Star")]
    public Sprite commonStar;
    public Sprite rareStar;
    public Sprite epicStar;
    public Sprite legendaryStar;

    [Header("Color")]
    public Color commonColor = Color.gray;
    public Color rareColor = Color.magenta;
    public Color epicColor = Color.green;
    public Color legendaryColor = Color.yellow;
}

/*
public class RarityEditor: EditorWindow
{
    [MenuItem("Window/RarityScript")]
    private static void OpenEditor()
    {
        
        EditorWindow.GetWindow(typeof(RarityEditor));
    }

    private void OnGUI()
    {
        EditorGUILayout.PrefixLabel("Image");
        ShowStar("Common Star", RarityScript.commonStar);
        ShowStar("Rare Star", RarityScript.rareStar);
        ShowStar("Epic Star", RarityScript.epicStar);
        ShowStar("Legendary Star", RarityScript.legendaryStar);

        EditorGUILayout.Space();
        EditorGUILayout.PrefixLabel("Color");
        ShowColor("Common Color", RarityScript.commonColor);
        ShowColor("Rare Color", RarityScript.rareColor);
        ShowColor("Epic Color", RarityScript.epicColor);
        ShowColor("Legendary Color", RarityScript.legendaryColor);
    }

    private void ShowStar(string label, Sprite sprite)
    {
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.PrefixLabel(label);
        sprite = (Sprite)EditorGUILayout.ObjectField(sprite, typeof(Sprite), false);
        EditorGUILayout.EndHorizontal();
    }
    private void ShowColor(string label, Color color)
    {
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.PrefixLabel(label);
        color = (Color)EditorGUILayout.ColorField(color);
        EditorGUILayout.EndHorizontal();
    }
}
*/