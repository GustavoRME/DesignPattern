using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace CommandPattern
{
    public class MessagesUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text = default;

        [Space]
        [SerializeField] private float _timeShown = 1.0f;

        private float _time;
        private Color _normalColor;
        private Coroutine _shownCoroutine;

        private void Awake()
        {
            _normalColor = _text.color;
        }

        public void Write(string message)
        {
            if (_shownCoroutine != null)
                StopCoroutine(_shownCoroutine);

            _text.text = message;
            _shownCoroutine = StartCoroutine(Shown());
        }

        private IEnumerator Shown()
        {
            _text.gameObject.SetActive(true);
            _time = Time.time;
            
            while (Time.time - _time < _timeShown)
            {
                float t = (Time.time - _time) / _timeShown;
                _text.color = new Color(
                    _normalColor.r, 
                    _normalColor.g, 
                    _normalColor.b, 
                    Mathf.Lerp(_normalColor.a, Color.clear.a, t));
                yield return new WaitForEndOfFrame();
            }
            
            _text.gameObject.SetActive(false);
            _text.color = _normalColor;
        }
    }
}
