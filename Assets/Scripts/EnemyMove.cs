using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private GameObject _player;
    [SerializeField] private float moveSpeed = 50f;
    
    private void Start()
    {
        _player = GameObject.Find("Player");
    }
    
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, moveSpeed * Time.deltaTime);
    }
}
