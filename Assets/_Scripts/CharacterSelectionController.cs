using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectionController : MonoBehaviour
{
    public static event Action<PlayerIndex, int> OnUpdatePlayerIndex;
    
    private int _playerOneIndex = 0;
    private int _playerTwoIndex = 2;

    private void Update()
    {
        PlayerOneControls();
        PlayerTwoControls();
    }

    private void PlayerOneControls()
    {
        //player 1
        if (Input.GetKeyDown(KeyCode.W))
        {
            UpdatePlayerIndex(PlayerIndex.PlayerOne, Direction.Up);
        }
        
        if (Input.GetKeyDown(KeyCode.S))
        {
            UpdatePlayerIndex(PlayerIndex.PlayerOne, Direction.Down);
        }
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            UpdatePlayerIndex(PlayerIndex.PlayerOne, Direction.Left);
        }
        
        if (Input.GetKeyDown(KeyCode.D))
        {
            UpdatePlayerIndex(PlayerIndex.PlayerOne, Direction.Right);
        }
    }

    private void PlayerTwoControls()
    {
        //player 2
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            UpdatePlayerIndex(PlayerIndex.PlayerTwo, Direction.Up);
        }
        
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            UpdatePlayerIndex(PlayerIndex.PlayerTwo, Direction.Down);
        }
        
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            UpdatePlayerIndex(PlayerIndex.PlayerTwo, Direction.Left);
        }
        
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            UpdatePlayerIndex(PlayerIndex.PlayerTwo, Direction.Right);
        }
    }

    private void UpdatePlayerIndex(PlayerIndex playerIndex, Direction direction)
    {
        var characterIndex = playerIndex switch
        {
            PlayerIndex.PlayerOne => _playerOneIndex,
            PlayerIndex.PlayerTwo => _playerTwoIndex,
            _ => 0
        };

        switch (direction)
        {
            case Direction.Up:
                characterIndex += 3;
                characterIndex = MathScenario(characterIndex);
                break;
            case Direction.Down:
                characterIndex -= 3;
                characterIndex = MathScenario(characterIndex);
                break;
            case Direction.Left:
                characterIndex--;
                if (characterIndex < 0)
                    characterIndex = 5;
                break;
            case Direction.Right:
                characterIndex++;
                if (characterIndex > 5)
                    characterIndex = 0;
                break;
        }

        switch (playerIndex)
        {
            case PlayerIndex.PlayerOne:
                _playerOneIndex = characterIndex;
                break;
            case PlayerIndex.PlayerTwo:
                _playerTwoIndex = characterIndex;
                break;
        }

        OnUpdatePlayerIndex?.Invoke(playerIndex, characterIndex);
    }

    //Hardcoded. can optimize later for formulas
    private int MathScenario(int indexValue)
    {
        var currentIndex = indexValue;
        if (currentIndex == 6)
            currentIndex = 0;
        if (currentIndex == 7)
            currentIndex = 1;
        if (currentIndex == 8)
            currentIndex = 2;
        if (currentIndex == -3)
            currentIndex = 3;
        if (currentIndex == -2)
            currentIndex = 4;
        if (currentIndex == -1)
            currentIndex = 5;
        return currentIndex;
    }
}

public enum Direction
{
    Unassigned,
    Up,
    Down,
    Left,
    Right
}

public enum PlayerIndex
{
    PlayerOne = 1,
    PlayerTwo = 2,
}