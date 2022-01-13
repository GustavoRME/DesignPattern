using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BytecodePattern
{
    public class VirtualMachine
    {
        private readonly GameController _controller;
        private Stack<int> _parameterStack;
        private int _maxStackSize;

        public VirtualMachine(GameController gameController, int stackSize)
        {
            _controller = gameController;
            _parameterStack = new Stack<int>(stackSize);
            _maxStackSize = stackSize;
        }

        public void Interpret(int[] bytecode)
        {
            int amount = 10;
            int wizard = 0;
            for (int i = 0; i < bytecode.Length; i++)
            {
                Instructions instruction = (Instructions)bytecode[i];
                switch (instruction)
                {
                    case Instructions.SET_HEALTH:
                        amount = Pop();
                        wizard = Pop();

                        _controller.SetHealth(wizard, amount);
                        break;

                    case Instructions.SET_WISDOM:
                        break;

                    case Instructions.SET_AGILITY:
                        break;

                    case Instructions.PLAY_SOUND:
                        _controller.PlaySound(Pop());
                        break;

                    case Instructions.SPAWN_PARTICLES:
                        break;

                    case Instructions.LITERAL:
                        Push(bytecode[++i]);
                        break;

                    case Instructions.GET_HEALTH:
                        wizard = Pop();
                        int health = _controller.GetHealth(wizard);
                        
                        Push(health);
                        break;

                    case Instructions.GET_WISDOM:
                        break;

                    case Instructions.GET_AGILITY:
                        break;

                    case Instructions.ADD:
                        int a = Pop();
                        int b = Pop();

                        Push(a + b);
                        break;

                    default:
                        break;
                }
            }
        }

        private void Push(int param)
        {
            if(_parameterStack.Count == _maxStackSize)
            {
                Debug.Log("Stack is full");
                return;
            }

            _parameterStack.Push(param);
        }

        private int Pop()
        {
            if(_parameterStack.Count == 0)
                Debug.Log("Stack is empty");

            return _parameterStack.Pop();
        }
    }
}
