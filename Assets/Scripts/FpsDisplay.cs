using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public sealed class FpsDisplay : MonoBehaviour
{
    public Text label;
    private int[] queue = new int[50];
    private int queueIndex;

    public void Update()
    {
        int currnet = (int)(1f / Time.unscaledDeltaTime);
        queue[queueIndex++] = currnet;
        queueIndex %= queue.Length;
        label.text = $"CUR {currnet}\nAVG {queue.Sum() / queue.Length}";
    }
}