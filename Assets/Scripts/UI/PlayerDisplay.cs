using UnityEngine;
using UnityEngine.UI;

public class PlayerDisplay : MonoBehaviour
{
    [SerializeField] private Text playerName;
    [SerializeField] private Text playerDescription;
    [SerializeField] private Text playerLevel;
    [SerializeField] private Image playerImage;
    [SerializeField] private Transform playerHolder;
    public void DisplayPlayer(Player _player)
    {
        playerName.text = _player.playerName;
        playerDescription.text = _player.playerDescription;
        playerLevel.text = "Level: " + _player.playerLevel.ToString();
        playerImage.sprite = _player.playerImage;

        PlayerPrefs.SetString("currentPlayer", _player.playerName);

        if (playerHolder.childCount > 0)
            Destroy(playerHolder.GetChild(0).gameObject);

        Instantiate(_player.playerModel, playerHolder.position, playerHolder.rotation, playerHolder);
    }
}
