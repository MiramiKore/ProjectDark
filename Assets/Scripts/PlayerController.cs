using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Attack _attack;
    private Animator _animator;
    
    private static readonly int OnAttack = Animator.StringToHash("onAttack");

    private void Awake()
    {
        _attack = GetComponent<Attack>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _attack.IsAttack();
            _animator.SetTrigger(OnAttack);
        }
    }
}
