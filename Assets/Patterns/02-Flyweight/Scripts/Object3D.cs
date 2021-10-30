using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlyweightPattern
{
    public class Object3D : MonoBehaviour
    {
        [SerializeField] private MeshRenderer _meshRenderer = default;
        [SerializeField] private MeshFilter _meshFilter = default;

        [Header("Movement Settings")]
        [SerializeField] private float _rotationSpeed = 5f;
        [SerializeField] private float _heightOffset = 5f;
        [SerializeField] private float _timeToMove = 5f;

        private Model _model;
        private float _time;
        private float _t;
        private bool _isMoveUp = true;

        private Vector3 _startPosition;

        public void Create(Model model, Vector3 position, Vector3 euler)
        {
            _model = model;
            transform.position = position;
            transform.eulerAngles = euler;

            _startPosition = position;
            _time = Time.time;
           
            DrawObject3D();
        }

        public void UpdateMe()
        {
            if (_model == null)
                return;

            if (_model.IsMovable) UpAndDown();
            if (_model.IsRotatable) Rotate();
        }

        private void UpAndDown()
        {
            //_t moving between 0 - 1
            if (_isMoveUp) _t += Time.deltaTime;
            else _t -= Time.deltaTime;
            
            transform.position = new Vector3(
                    _startPosition.x,
                    Mathf.Lerp(_startPosition.y, _heightOffset, _t), 
                    _startPosition.z);

            //Reset direction
            if (_t > 1.0f || _t < 0.0f)
            {
                _time = Time.time;
                _isMoveUp = !_isMoveUp;
            }
        }

        private void Rotate()
        {
            transform.eulerAngles = new Vector3(
                transform.eulerAngles.x, 
                transform.eulerAngles.y, 
                transform.eulerAngles.z + _rotationSpeed);
        }

        private void DrawObject3D()
        {
            if (_model == null)
                return;

            _meshRenderer.material.SetTexture("_MainTex", _model.Texture);
            _meshFilter.mesh = _model.Mesh;

            switch (_model.MeshCollider)
            {
                case Model.ColliderMesh.Box:
                    gameObject.AddComponent(typeof(BoxCollider));
                    break;
                case Model.ColliderMesh.Capsule:
                    gameObject.AddComponent(typeof(CapsuleCollider));
                    break;
            }
        }
    }
}
