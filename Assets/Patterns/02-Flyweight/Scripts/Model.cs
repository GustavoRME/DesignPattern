using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlyweightPattern
{
    [CreateAssetMenu(fileName = "Model", menuName = "Flyweight/Object3D")]
    public class Model : ScriptableObject
    {
        public enum ColliderMesh
        {
            Box,
            Capsule
        }

        [SerializeField] private Mesh _mesh = default;
        [SerializeField] private Texture _texture = default;
        [SerializeField] private ColliderMesh _meshCollider = default;
        [SerializeField] private bool _isMovable = false;
        [SerializeField] private bool _isRotatable = false;

        public Mesh Mesh => _mesh;
        public Texture Texture => _texture;
        public ColliderMesh MeshCollider => _meshCollider;
        public bool IsMovable => _isMovable;
        public bool IsRotatable => _isRotatable;
    }
}

