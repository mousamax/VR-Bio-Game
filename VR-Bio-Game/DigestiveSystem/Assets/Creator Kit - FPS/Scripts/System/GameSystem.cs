using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor.SceneManagement;
#endif


public class GameSystem : MonoBehaviour
{
    public static GameSystem Instance { get; private set; }

    static int s_CurrentEpisode = -1;
    static int s_CurrentLevel = -1;


    public float RunTime => m_Timer;
    public int TargetCount => m_TargetCount;
    public int DestroyedTarget => m_TargetDestroyed;
    public int Score => m_Score;

    float m_Timer;
    bool m_TimerRunning = false;

    int m_TargetCount;
    int m_TargetDestroyed;

    int m_Score = 0;

    void Awake()
    {
        Instance = this;


        PoolSystem.Create();
    }


    public void ResetTimer()
    {
        m_Timer = 0.0f;
    }

    public void StartTimer()
    {
        m_TimerRunning = true;
    }

    public void StopTimer()
    {
        m_TimerRunning = false;
    }







}