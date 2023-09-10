using UnityEngine;

[CreateAssetMenu(fileName = "New Player", menuName = "Scriptable Objects/Player")]
public class Player : ScriptableObject
{
    [Header("Description")]
    public string playerName;
    public string playerDescription;

    [Header("Stats")]
    public float playerLevel;

    [Header("Icon")]
    public Sprite playerImage;

    [Header("3D Model")]
    public GameObject playerModel;
}
