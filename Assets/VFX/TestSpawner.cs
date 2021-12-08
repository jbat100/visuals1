using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

/*
 * https://forum.unity.com/threads/is-it-possible-to-trigger-c-events-from-graph.986634/
 *
 * 
 */

class TestSpawner : VFXSpawnerCallbacks
{
    public class InputProperties
    {
        public float Count = 1.0f;
        public float Delay = 2.0f;
    }

    static private readonly int countID = Shader.PropertyToID("Count");
    static private readonly int delayID = Shader.PropertyToID("Delay");

    public sealed override void OnPlay(VFXSpawnerState state, VFXExpressionValues vfxValues, VisualEffect vfxComponent)
    {
    }

    private float m_NextBurstTime;
    private bool m_Sleeping;

    public sealed override void OnUpdate(VFXSpawnerState state, VFXExpressionValues vfxValues, VisualEffect vfxComponent)
    {
        if (state.newLoop)
        {
            m_NextBurstTime = vfxValues.GetFloat(delayID);
            m_Sleeping = false;
        }

        if (!m_Sleeping && state.playing && state.totalTime >= m_NextBurstTime)
        {
            state.spawnCount += vfxValues.GetFloat(countID);
            m_Sleeping = true;
        }
    }

    public sealed override void OnStop(VFXSpawnerState state, VFXExpressionValues vfxValues, VisualEffect vfxComponent)
    {
    }
}
