using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SceneData : ScriptableObject
{
    public float startTime;
    public bool isWinTimer;
    [Header("cursor modes are: cursor, crosshair, off")]
    [Tooltip("Cursor modes are: cursor, crosshair, off")]
    public string cursorMode;
    public string microGameName;
    [TextArea]
    public string microGameInstruction;
}
