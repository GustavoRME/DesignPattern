using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlyweightPattern
{
    public class Object3D : MonoBehaviour
    {
        [SerializeField] private MeshRenderer _meshRenderer = default;
        [SerializeField] private MeshFilter _meshFilter = default;

        private Model _model;
        private Vector3 _startPostion;
        private float _timeToMove = 5f;
        private float _rotationSpeed = 5f;
        private float _time;
        private bool _isMoveUp = true;
        
        public Vector3 Position { get => transform.position; set => transform.position = value; }
        public Vector3 EulerAngles { get => transform.eulerAngles; set => transform.eulerAngles = value; }

        public void Create(Model model, Vector3 position, Vector3 euler)
        {
            _model = model;
            Position = position;
            EulerAngles = euler;

            _startPostion = Position;
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
            float t = (Time.time - _time / _timeToMove);
            
            if(_isMoveUp)
            {
                Position = new Vector3(Position.x, Mathf.Lerp(_startPostion.y, 5, t));
            }
            else
            {
                Position = new Vector3(Position.x, Mathf.Lerp(Position.y, _startPostion.y, t));
            }
            
            //Only reset the values when reach the bounds 0 and 1
            if(t > 1.0f)
            {
                _time = Time.time;
                _isMoveUp = false;
            }
            else if(t <= 0.0f)
            {
                _time = Time.time;
                _isMoveUp = true;
            }

            Debug.Log($"t => {t} / time => {_time}");
        }

        private void Rotate()
        {
            EulerAngles = new Vector3(EulerAngles.x, EulerAngles.y, EulerAngles.z + _rotationSpeed);
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
