using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/*
 O(1) - int[] a = new int[10]; .... a[0] 
 O(N) - foreach(a)
 O(Nˆ2) - for() { for() {} }
 O(Nˆ3) - for() { for() { for() {} } }
 O(lgN) - 
 O(N * LogN)
 */

public class GameFieldCell : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Vector3 _endSize;
    [SerializeField] private float _blendSpeed;
    [SerializeField] private float _colorBlendSpeed = 5f;

    [SerializeField] private Color _spawnColor = Color.yellow;
    [SerializeField] private Color _baseColor = Color.white;
    [SerializeField] private Color _selectedColor = Color.red;
    
    public event Action<int, int> OnPressed;
    private SpriteRenderer _spriteRenderer;
    private Color _targetColor;

    public int X { get; private set; }
    public int Y { get; private set; }
    public char Letter { get; private set; }

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        SetColor(_spawnColor);
    }

    private void OnMouseUpAsButton()
    {
        OnPressed?.Invoke(X, Y);
    }

    public void Select()
    {
        SetColor(_selectedColor);
    }

    public void Deselect()
    {
        SetColor(_baseColor);
    }

    public void SetUp(int x, int y, char letter)
    {
        X = x;
        Y = y;
        Letter = letter;
        _text.text = letter.ToString();
    }

    private void SetColor(Color color)
    {
        _targetColor = color;
    }
    
    private void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, _endSize, _blendSpeed * Time.deltaTime);
        _spriteRenderer.color = Color.Lerp(_spriteRenderer.color, _targetColor, _colorBlendSpeed * Time.deltaTime);
    }
}
