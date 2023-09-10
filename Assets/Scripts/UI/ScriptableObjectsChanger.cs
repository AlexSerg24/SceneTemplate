using UnityEngine;

public class ScriptableObjectsChanger : MonoBehaviour
{
    [SerializeField] private ScriptableObject[] scriptableObjects;
    [SerializeField] private MapDisplay mapDisplay;
    [SerializeField] private PlayerDisplay playerDisplay;
    private int currentIndex;
    private bool isChangingDisplay = false;

    private void Awake()
    {
        ChangeScriptableObject(0);
    }
    public void ChangeScriptableObject(int _change)
    {
        currentIndex += _change;
        if (currentIndex < 0) currentIndex = scriptableObjects.Length - 1;
        else if (currentIndex > scriptableObjects.Length - 1) currentIndex = 0;

        if (mapDisplay != null) mapDisplay.DisplayMap((Map)scriptableObjects[currentIndex]);
        if (playerDisplay != null) playerDisplay.DisplayPlayer((Player)scriptableObjects[currentIndex]);
    }
    private void OnGUI()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && !isChangingDisplay)
        {
            ChangeScriptableObject(-1);
            isChangingDisplay = true;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && !isChangingDisplay)
        {
            ChangeScriptableObject(1);
            isChangingDisplay = true;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            isChangingDisplay = false;
        }
    }
}
