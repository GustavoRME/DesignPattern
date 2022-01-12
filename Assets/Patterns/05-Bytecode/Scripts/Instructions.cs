using UnityEngine;

namespace BytecodePattern
{
    public enum Instructions
    {
        SET_HEALTH,
        SET_WISDOM,
        SET_AGILITY,
        PLAY_SOUND,
        SPAWN_PARTICLES,
        //So we can use parameters
        LITERAL,
        //Read stats
        GET_HEALTH,
        GET_WISDOM,
        GET_AGILITY,
        //Arithmetic
        ADD
    }
}
