using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AudioData))]
class AudioDatatEditor : Editor
{
    private AudioData audioData;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
        if (GUILayout.Button("Update"))
        {
            audioData = (AudioData)serializedObject.targetObject;
            audioData.ResetAllAudioData();
        }
    }
}