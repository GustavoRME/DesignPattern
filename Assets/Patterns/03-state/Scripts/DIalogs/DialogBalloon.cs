using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class DialogBalloon : ADialogBalloon
{
    [SerializeField] private float _animationTime = 1.0f;

    private float _waitingTime;
    private float _time;

    private Button _button;
    private int _currentChar;
    
    private bool _isAnimStarted;
    private bool _isAnimEnded;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _waitingTime = _animationTime / _dialog.DialogMessage.Length;
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        StarAnimationWrite();
    }

    protected override void StarAnimationWrite()
    {
        if (_isAnimStarted || _isAnimEnded)
            return;

        _time = Time.time;
        _textMesh.text = string.Empty;
        _isAnimStarted = true;
        _isAnimEnded = false;
    }

    public override void EndAnimationWrite()
    {
        if (!_isAnimStarted|| !_isAnimEnded) 
            return;

        _textMesh.text = _dialog.DialogMessage;
        _isAnimEnded = true;
    }

    public override void AnimationWrite()
    {
        if (!_isAnimStarted || _isAnimEnded) 
            return;

        if (Time.time - _time < _waitingTime)
            return;

        if (_currentChar >= _dialog.DialogMessage.Length)
            return;

        _textMesh.text += _dialog.DialogMessage[_currentChar];
        _currentChar++;
        _time = Time.time;
    }
}
