using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float sprintSpeed;
    [SerializeField] private float rotateSpeed;

    private bool _onSprint;

    // Ссылки
    private Rigidbody _rb;
    private Vector3 _moveDirection;
    private Animator _animator;
    
    // Анимации
    private static readonly int OnRun = Animator.StringToHash("onRun");
    private static readonly int OnSprint = Animator.StringToHash("onSprint");

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }
    
    private void Update()
    {
        PlayerRotation();
        
        _animator.SetBool(OnSprint, _onSprint);
        _animator.SetFloat(OnRun, _moveDirection.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        _onSprint = Sprint();
        
        if (!_onSprint)
            PlayerMovement(moveSpeed);
    }

    // Движение игрока
    private void PlayerMovement(float speed)
    {
        var horizontalAxis = Input.GetAxisRaw("Horizontal");
        var verticalAxis = Input.GetAxisRaw("Vertical");
        
        _moveDirection = new Vector3(horizontalAxis, 0, verticalAxis).normalized;
        _rb.AddForce(_moveDirection * (speed * Time.deltaTime), ForceMode.Impulse);
    }  
    
    // Поворот в сторону движения
    private void PlayerRotation()
    {
        if (_moveDirection == Vector3.zero) return;
        
        var rotatePoint = Quaternion.LookRotation(_moveDirection);
        var rotationDirection = Quaternion.Lerp(transform.rotation, rotatePoint, rotateSpeed * Time.deltaTime);
        transform.rotation = rotationDirection;
    }
    
    // Спринт
    private bool Sprint()
    {
        if (Input.GetKey(KeyCode.LeftShift) && _moveDirection != Vector3.zero)
        {
            PlayerMovement(sprintSpeed);
            return true;
        }
        
        return false;
    }
}
