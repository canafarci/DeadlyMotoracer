using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using AINamesGenerator;
using UnityEngine.UI;

public class NameStandingText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _countText, _nameText, _scoreText;
    [SerializeField] Image _flagImage;

    private void Start()
    {
        //standing
        int playerStanding = GameManager.Instance.References.GameConfig.PlayerStanding;
        _nameText.text = Utils.GetRandomName();
        _countText.text = "#" + (playerStanding + transform.GetSiblingIndex() + 1).ToString();

        //flag
        Sprite[] images = GameManager.Instance.References.GameConfig.Flags;
        int randInt = Random.Range(0, images.Length - 1);

        _flagImage.sprite = images[randInt];

        //score -- player is 3524

        int playerScore = 3524;
        _scoreText.text = (playerScore - ((transform.GetSiblingIndex() + 1) * Random.Range(45, 55))).ToString();
    }
}
