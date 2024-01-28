using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private Color[] color;
    [SerializeField] private Color oldColor;
    [SerializeField] private Color lerpColor;
    [SerializeField] private Color currentColor;
    [SerializeField] private TMPro.TextMeshProUGUI m_TextMeshPro;
    [SerializeField] private float timeRunning;
    [SerializeField] private float changeColorTimer;
    [SerializeField] private int indexNumber;
    // Update is called once per frame
    void Update()
    {
        timeRunning += Time.deltaTime;
        
        if (timeRunning >= changeColorTimer)
        {
            timeRunning = 0;
            indexNumber = Random.Range(0, color.Length);
            oldColor = currentColor;
            currentColor = color[indexNumber];
        }
        lerpColor = Color.Lerp(oldColor, color[indexNumber], timeRunning);
        m_TextMeshPro.color = lerpColor;
    }
}
