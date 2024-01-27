using System;
using UnityEngine;

[CreateAssetMenu(menuName = "GGJ24/JokeSetup")]
public class JokeFragment : ScriptableObject
{
    [Serializable]
    class JokeChainScoreEntry
    {
        [SerializeField] JokeFragment followUp;
        [SerializeField] int score;
    }

    [SerializeField] string text;
    [SerializeField] JokeChainScoreEntry[] scoreEntries;
}
