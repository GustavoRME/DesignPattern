using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BytecodePattern
{
    public class GameController : MonoBehaviour
    {
        private VirtualMachine _virtualMachine;

        private void Start()
        {
            _virtualMachine = new VirtualMachine(this, 128);

            int[] bytecode = new int[]
            {
                (int)Instructions.LITERAL, 0,
                (int)Instructions.LITERAL, 100,
                (int)Instructions.SET_HEALTH
            };

            _virtualMachine.Interpret(bytecode);
        }

        //0 means the player's wizard and 1, 2, ... means the other wizards in the game
        //This way we can heal our own wizard while damage other wizards with the same method
        public void SetHealth(int wizardID, int amount)
        {
            Debug.Log($"Wizard {wizardID} gets health {amount}");
        }

        public void SetWizdom(int wizardID, int amount)
        {
            Debug.Log($"Wizard {wizardID} gets wisdom {amount}");
        }

        public void SetAgility(int wizardID, int amount)
        {
            Debug.Log($"Wizard {wizardID} gets agility {amount}");
        }

        public void PlaySound(int soundID)
        {
            Debug.Log($"Play sound {soundID}");
        }

        public void SpawnParticles(int particleType)
        {
            Debug.Log($"Spawn particle {particleType}");
        }

        public int GetHealth(int wizardID)
        {
            return 50;
        }
    }

}

