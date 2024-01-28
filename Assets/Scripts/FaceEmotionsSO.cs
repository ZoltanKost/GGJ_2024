using UnityEngine;

[CreateAssetMenu(menuName = "GGJ24/FaceEmotions")]
public class FaceEmotionsSO : ScriptableObject
{
    [SerializeField] Sprite[] emotions;

    public Sprite GetEmotion(float progress)
    {
        return emotions[Mathf.RoundToInt(Mathf.Clamp(progress, 0f, 1f)) * emotions.Length];
    }
}
