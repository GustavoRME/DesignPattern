using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlyweightPattern
{
    public class ObjectCreater : MonoBehaviour
    {
        [SerializeField] private Object3D _flyweightPrefab = default;
        [SerializeField] private SimpleModel _noPatternPrefab = default;
        [SerializeField] private int _amount = 1000;
        [SerializeField] private int _objectsPerLine = 5;

        [Space]
        [SerializeField] private Vector3 _startPosition = Vector3.zero;
        [SerializeField] private Vector3 _padding = Vector3.zero;

        [Header("Models")]
        [SerializeField] private Model _capsuleMove = default;
        [SerializeField] private Model _cube = default;
        [SerializeField] private Model _cubeRotate = default;
        [SerializeField] private Model _cylinder = default;

        private Object3D[] _objects;
        private SimpleModel[] _simpleModels;

        private bool _isUsingFlyweight;

        private void Awake()
        {
            _objects = new Object3D[_amount];
            _simpleModels = new SimpleModel[_amount];
        }

        private void Update()
        {
            if(_isUsingFlyweight)
            {
                for (int i = 0; i < _objects.Length; i++)
                {
                    if(_objects[i] != null)
                    {
                        _objects[i].UpdateMe();
                    }
                }
            }
            else
            {
                for (int i = 0; i < _simpleModels.Length; i++)
                {
                    if(_simpleModels[i] != null)
                    {
                        _simpleModels[i].UpdateMe();
                    }
                }
            }
        }

        public void FlyWeight()
        {
            int line = 1;

            Vector3 curPosition = _startPosition;
            for (int i = 0; i < _amount; i++)
            {
                Object3D obj3D = Instantiate(_flyweightPrefab);
                obj3D.Create(GetModel(), curPosition, Vector3.zero);
                _objects[i] = obj3D;

                Vector3 offset = new Vector3(_padding.x, _padding.y, 0);
                if (line % _objectsPerLine == 0)
                {
                    curPosition = new Vector3(_startPosition.x, _startPosition.y, curPosition.z + _padding.z);
                }
                else
                {
                    curPosition += offset;
                }

                line++;
            }

            ClearArray(ref _simpleModels);
            _isUsingFlyweight = true;

            Debug.Log("USING FLYWEIGHT PATTERN");
        }

        public void NoPattern()
        {
            int line = 1;

            Vector3 curPosition = _startPosition;
            for (int i = 0; i < _amount; i++)
            {
                SimpleModel simpleModel = Instantiate(_noPatternPrefab);
                simpleModel.Create(GetModel(), curPosition, Vector3.zero, RandomBoolean(), RandomBoolean());
                _simpleModels[i] = simpleModel;

                Vector3 offset = new Vector3(_padding.x, _padding.y, 0);
                if (line % _objectsPerLine == 0)
                {
                    curPosition = new Vector3(_startPosition.x, _startPosition.y, curPosition.z + _padding.z);
                }
                else
                {
                    curPosition += offset;
                }

                line++;
            }

            ClearArray(ref _objects);
            _isUsingFlyweight = false;

            Debug.Log("USING NO PATTERN");
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

        private void ClearArray<T>(ref T[] array) where T : MonoBehaviour 
        {
            if (array == null)
                return;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == null)
                    continue;
                    
                Destroy(array[i].gameObject);
            }

            array = new T[_amount];
        }

        private bool RandomBoolean()
        {
            //0 == true; 1 == false
            return Random.Range(0, 2) == 0;
        }
    }

}
