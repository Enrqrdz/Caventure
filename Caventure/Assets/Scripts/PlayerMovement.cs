using System;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    [Range(0.01f, 2f)] public float MovementSpeed = 0.2f;
    
    private Grid _grid;
    private Grid Grid
    {
        get
        {
            if (_grid == null)
            {
                _grid = GameObject.Find("Grid").GetComponent<Grid>();
            }
            return _grid;
        }
    }
    public Action MovedEvent;
    private float MovementSize => Grid.GetSize();
    private Vector3 Forward => transform.position + MovementSize * Vector3.forward;
    private Vector3 Back => transform.position + MovementSize * Vector3.back;
    private Vector3 Left => transform.position + MovementSize * Vector3.left;
    private Vector3 Right => transform.position + MovementSize * Vector3.right;

    private void Update()
    {
        if (InputManager.Forward)
        {
            Move(Forward);
            MovedEvent?.Invoke();
        }

        if (InputManager.Back)
        {
            Move(Back);
            MovedEvent?.Invoke();
        }

        if (InputManager.Left)
        {
            Move(Left);
            MovedEvent?.Invoke();
        }

        if (InputManager.Right)
        {
            Move(Right);
            MovedEvent?.Invoke();
        }
    }

    private void Move(Vector3 newPosition_)
    {
        if (Grid.WalkableTransforms.TryGetValue(Grid.GetPositionHash(newPosition_), out var walkableFloor))
        {
            transform.DOMove(walkableFloor.position, MovementSpeed);
        }
        else if (Grid.WalkableTransforms.TryGetValue(Grid.GetPositionHash(new Vector3(newPosition_.x, newPosition_.y + Grid.GetHeight(), newPosition_.z)), out walkableFloor))
        {
            transform.DOMove(walkableFloor.position, MovementSpeed);
        }
        else if (Grid.WalkableTransforms.TryGetValue(Grid.GetPositionHash(new Vector3(newPosition_.x, newPosition_.y - Grid.GetHeight(), newPosition_.z)), out walkableFloor))
        {
            transform.DOMove(walkableFloor.position, MovementSpeed);
        }
    }

    private void OnDestroy()
    {
        if (MovedEvent == null) return;
        
        foreach(var action in MovedEvent.GetInvocationList())
        {
            MovedEvent -= (action as Action);
        }
    }
}
