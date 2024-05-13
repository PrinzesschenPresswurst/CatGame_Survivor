using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 50f;
    private float _screenHeight;
    private float _screenWidth;
    
    private Animator _animator;
    private readonly List<string> _animationStates = new List<string>()
    {
        "IsWalkingDown", 
        "IsWalkingUp", 
        "IsWalkingLeft", 
        "IsWalkingRight"
    };

    private void Start()
    {
        _animator = GetComponent<Animator>();
        transform.position = Vector3.zero;
        GetScreenSpace();
    }

    private void GetScreenSpace()
    {
        if (Camera.main == null)
            return;
        
        float cameraSize = Camera.main.orthographicSize; 
        _screenHeight = cameraSize; 
        _screenWidth = cameraSize * Screen.width / Screen.height;
    }
    
    private void Update()
    {
        HandlePlayerInput();
        KeepPlayerInBounds();
    }
    
    private void HandlePlayerInput()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            MovePlayer(Vector3.down);   
            SetAnimationStates("IsWalkingDown");
        }
        else 
            _animator.SetBool("IsWalkingDown", false);
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            MovePlayer(Vector3.up);
            SetAnimationStates("IsWalkingUp");
        }
        else 
            _animator.SetBool("IsWalkingUp", false);
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            MovePlayer(Vector3.left);
            SetAnimationStates("IsWalkingLeft");
        }
        else 
            _animator.SetBool("IsWalkingLeft", false);
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            MovePlayer(Vector3.right);
            SetAnimationStates("IsWalkingRight");
        }
        else 
            _animator.SetBool("IsWalkingRight", false);
    }

    private void MovePlayer(Vector3 direction)
    {
        Vector3 newPos = direction * movementSpeed * Time.deltaTime;
        transform.position += newPos;
    }
    
    private void SetAnimationStates(string animationState)
    {
        foreach (var animName in _animationStates)
        {
            if (animName == animationState)
                _animator.SetBool(animName, true);
            else 
                _animator.SetBool(animName, false);
        }
    }

    private void KeepPlayerInBounds()
    {
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -_screenWidth, _screenWidth);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, -_screenHeight, _screenHeight);
        transform.position = clampedPosition;
    }
}
