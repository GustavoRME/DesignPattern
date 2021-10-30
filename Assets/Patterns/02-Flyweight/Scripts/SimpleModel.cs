using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlyweightPattern
{
    public class SimpleModel : MonoBehaviour
    {
        [SerializeField] private Mesh _mesh = default;
        [SerializeField] private Texture _texture = default;
        [SerializeField] private bool _isMovable = false;
        [SerializeField] private bool _isRotateble = false;

        [Space]
        [SerializeField] private MeshRenderer _meshRenderer = default;
        [SerializeField] private MeshFilter _meshFilter = default;

        [Header("Movement Settings")]
        [SerializeField] private float _rotationSpeed = 5f;
        [SerializeField] private float _heightOffset = 5f;

        private Vector3 _startPosition;
        private bool _isMoveUp;
        private float _t;

        public void Create(Model model, Vector3 position, Vector3 euler, bool isMovable, bool isRotatable)
        {
            transform.position = position;
            transform.eulerAngles = euler;
            _startPosition = position;

            if(model != null)
            {
                _mesh = model.Mesh;
                _texture = model.Texture;
            }

            _isMovable = isMovable;
            _isRotateble = isRotatable;

            DrawObject3D(model);
        }

        public void UpdateMe()
        {
            if (_isMovable) UpAndDown();
            if (_isRotateble) Rotate();
        }

        private void DrawObject3D(Model model)
        {
            if (model == null)
                return;

            _meshRenderer.material.SetTexture("_MainTex", model.Texture);
            _meshFilter.mesh = model.Mesh;

            switch (model.MeshCollider)
            {
                case Model.ColliderMesh.Box:
                    gameObject.AddComponent(typeof(BoxCollider));
                    break;
                case Model.ColliderMesh.Capsule:
                    gameObject.AddComponent(typeof(CapsuleCollider));
                    break;
            }
        }

        private void Rotate()
        {
            transform.eulerAngles = new Vector3(
                transform.eulerAngles.x,
                transform.eulerAngles.y,
                transform.eulerAngles.z + _rotationSpeed);
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
                _isMoveUp = !_isMoveUp;
            }
        }
    }

}
