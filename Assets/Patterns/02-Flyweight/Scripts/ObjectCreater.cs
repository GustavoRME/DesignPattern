using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlyweightPattern
{
    public class ObjectCreater : MonoBehaviour
    {
        [SerializeField] private Object3D _prefab = default;
        [SerializeField] private int _amount = 1000;
        [SerializeField] private int _objectsPerLine = 5;

        [Space]
        [SerializeField] private Vector3 _startPostion = Vector3.zero;
        [SerializeField] private Vector3 _padding = Vector3.zero;

        [Header("Models")]
        [SerializeField] private Model _capsuleMove = default;
        [SerializeField] private Model _cube = default;
        [SerializeField] private Model _cubeRotate = default;
        [SerializeField] private Model _cylinder = default;

        private Object3D[] _objects;

        private void Awake()
        {
            _objects = new Object3D[_amount];

            int line = 1;
            
            Vector3 curPosition = _startPostion;
            for (int i = 0; i < _amount; i++)
            {
                Object3D obj3D = Instantiate(_prefab);
                obj3D.Create(GetModel(), curPosition, Vector3.zero);
                _objects[i] = obj3D;

                Vector3 offset = new Vector3(_padding.x, _padding.y, 0);
                if (line % _objectsPerLine == 0)
                {
                    curPosition = new Vector3(_startPostion.x, _startPostion.y, curPosition.z + _padding.z);   
                }
                else
                {
                    curPosition += offset;
                }
                
                line++;
            }
        }

        private void Update()
        {
            for (int i = 0; i < _objects.Length; i++)
            {
                _objects[i].UpdateMe();
            }
        }

        private Model GetModel()
        {
            //range 0-3
            int r = Random.Range(0, 4);

            if (r == 0) return _capsuleMove;
            else if (r == 1) return _cube;
            else if (r == 2) return _cubeRotate;
            return _cylinder;
        }
    }

}
