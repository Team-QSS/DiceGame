using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class DiceController : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite[] dice = new Sprite[6];
    private ParticleSystem _particle;
    
    private int _number;
    private Vector3 _originPos;
    private bool _isRolling;

    public event Action<int> OnDiceRolled;
    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _originPos = transform.position;
        
        if (_particle == null) 
            _particle = GetComponentInChildren<ParticleSystem>();
    }
    
    void Start()
    {
        OnDiceRolled += num =>
        {
            // PlayerSelect.SelectedPlayer.playerMove(num);
        };
        InitDice();
    }

    public void InitDice()
    {
        StopAllCoroutines();
        if (_spriteRenderer != null)
        {
            _spriteRenderer.sprite = null;
            _spriteRenderer.color = Color.black;
        }
        transform.position = _originPos;
        transform.rotation = Quaternion.identity;
        _isRolling = false;
    }

    public void StartDice()
    {
        if (_isRolling) InitDice();
        
        StartCoroutine(SpinDice());
        
        _number = Random.Range(1, 7);
        _spriteRenderer.sprite = dice[_number - 1];
    }
    
    private IEnumerator SpinDice()
    {
        _isRolling = true;
        float jumpHeight = 2f;
        float duration = 0.8f;
        float elapsed = 0f;
        
        while (elapsed < duration)
        {
            float t = elapsed / duration;
            
            float angle = Mathf.Lerp(0, 720, t);
            transform.rotation = Quaternion.Euler(angle, 0, 0);
            
            float yOffset = Mathf.Sin(t * Mathf.PI) * jumpHeight;
            transform.position = _originPos + Vector3.up * yOffset;

            elapsed += Time.deltaTime;
            yield return null;
        }
        StopSpin();
        _isRolling = false;
    }

    private void StopSpin()
    {
        transform.position = _originPos;
        transform.rotation = Quaternion.identity;
        _spriteRenderer.color = Color.white;
        if (_particle != null) _particle.Play();
        Invoke("SendData",1);
    }

    private void SendData()
    {
        OnDiceRolled?.Invoke(_number);
        InitDice();
    }

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            StartDice();
        }

        if (Keyboard.current.fKey.wasPressedThisFrame)
        {
            InitDice();
        }
    }
}