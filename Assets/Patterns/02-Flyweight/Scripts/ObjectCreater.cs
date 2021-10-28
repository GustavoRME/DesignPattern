using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlyweightPattern
{
    public class ObjectCreater : MonoBehaviour
    {
        [SerializeField] private Object3D _prefab = default;
        [SerializeField] private int _amount = 1000;

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
            Vector3 curPosition = _startPostion;
            _objects = new Object3D[_amount];
            for (int i = 0; i < _amount; i++)
            {
                int r = Random.Range(0, 5);

                Model model;
                if(r == 0)
                {
                    model = _capsuleMove;
                }
                else if(r == 1)
                {
                    model = _cube;
                }
                else if(r == 2)
                {
                    model = _cubeRotate;
                }
                else
                {
                    model = _cylinder;
                }

                Object3D obj3D = Instantiate(_prefab);
                obj3D.Create(model, curPosition, Vector3.zero);
                _objects[i] = obj3D;

                
            }
        }

        private void Update()
        {
            for (int i = 0; i < _objects.Length; i++)
            {
                _objects[i].UpdateMe();
            }
        }
    }

}
