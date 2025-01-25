using System;
using System.Collections.Generic;

public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    /// <summary>
    /// Check to see if you can move left. If you can, then move. 
    /// If you can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveLeft()
    {
        // Check if the current position has a valid move to the left
        if (_mazeMap.ContainsKey((_currX, _currY)) && _mazeMap[(_currX, _currY)][0])
        {
            _currX--;  // Move left (decrease x-coordinate)
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");  // Throw exception if move is invalid
        }
    }

    /// <summary>
    /// Check to see if you can move right. If you can, then move. 
    /// If you can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveRight()
    {
        // Check if the current position has a valid move to the right
        if (_mazeMap.ContainsKey((_currX, _currY)) && _mazeMap[(_currX, _currY)][1])
        {
            _currX++;  // Move right (increase x-coordinate)
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");  // Throw exception if move is invalid
        }
    }

    /// <summary>
    /// Check to see if you can move up. If you can, then move. 
    /// If you can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveUp()
    {
        // Check if the current position has a valid move upwards
        if (_mazeMap.ContainsKey((_currX, _currY)) && _mazeMap[(_currX, _currY)][2])
        {
            _currY--;  // Move up (decrease y-coordinate)
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");  // Throw exception if move is invalid
        }
    }

    /// <summary>
    /// Check to see if you can move down. If you can, then move. 
    /// If you can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveDown()
    {
        // Check if the current position has a valid move downwards
        if (_mazeMap.ContainsKey((_currX, _currY)) && _mazeMap[(_currX, _currY)][3])
        {
            _currY++;  // Move down (increase y-coordinate)
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");  // Throw exception if move is invalid
        }
    }

    /// <summary>
    /// Get the current status, i.e., the current position in the maze.
    /// </summary>
    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}
