using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    

    private readonly int HitName = Animator.StringToHash("isHit");
    private readonly int DeadName = Animator.StringToHash("isDead");

    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] public int _health;
    [SerializeField] private float _thrust;
    private LifeBar _lifeBar;

    public bool IsDead => _health <= 0;

    private void Awake()
    {
        _lifeBar = FindObjectOfType<LifeBar>();
    }


    public void PlayerDamage(Transform attacker)
    {
        _health -= 1;
        _lifeBar.Damage();
        AddThrust(attacker);
        if (IsDead)
        {
            _animator.SetTrigger(DeadName);
        } else
        {
            _animator.SetTrigger(HitName);
        }
    }


    private void AddThrust(Transform attacker)
    {
            float sign = Mathf.Sign(transform.position.x - attacker.position.x);
            Vector2 direction = new Vector2(sign, 1f);
            _rb.velocity = Vector2.zero;
            _rb.AddForce(direction * _thrust, ForceMode2D.Impulse);
            
            Debug.Log("� ������� ���������");
    }


}