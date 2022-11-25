using System;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectionManager : MonoBehaviour
{
    public int CurrentCharactersCount = 6;
    public Character[] Characters;
    public Image[] Images;

    public Image PlayerOneCharacterUI;
    public Image PlayerTwoCharacterUI;
    private int _playerOneIndex;
    private int _playerTwoIndex;

    public RectTransform PlayerOneFrame;
    public RectTransform PlayerTwoFrame;
    

    private void Awake()
    {
        CharacterSelectionController.OnUpdatePlayerIndex += OnUpdatePlayerIndex;
    }

    private void OnDestroy()
    {
        CharacterSelectionController.OnUpdatePlayerIndex -= OnUpdatePlayerIndex;
    }

    private void OnUpdatePlayerIndex(PlayerIndex playerIndex, int index)
    {
        switch (playerIndex)
        {
            case PlayerIndex.PlayerOne:
                _playerOneIndex = index;
                PlayerOneCharacterUI.sprite = Characters[_playerOneIndex].PoseIcon;
                
                PlayerOneFrame.SetParent(Images[_playerOneIndex].transform);
                PlayerOneFrame.localPosition = Vector3.zero;
                break;
            case PlayerIndex.PlayerTwo:
                _playerTwoIndex = index;
                PlayerTwoCharacterUI.sprite = Characters[_playerTwoIndex].PoseIcon;
                
                PlayerTwoFrame.SetParent(Images[_playerTwoIndex].transform);
                PlayerTwoFrame.localPosition = Vector3.zero;
                break;
        }
    }

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        for (int i = 0; i < CurrentCharactersCount; i++)
        {
            Images[i].sprite = Characters[i].SelectIcon;
        }

        //hardcoded for now.
        _playerOneIndex = 0;
        _playerTwoIndex = 2;

        PlayerOneCharacterUI.sprite = Characters[_playerOneIndex].PoseIcon;
        PlayerTwoCharacterUI.sprite = Characters[_playerTwoIndex].PoseIcon;
    }
}

[System.Serializable]
public class Character
{
    public string Name;
    public Sprite SelectIcon;
    public Sprite PoseIcon;
}