using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysX : MonoBehaviour
{
    public float K = 10.0f;
}

public enum Polarity
{
    Negative = -1, Neutral = 0, Positive = 1
}

public interface Magnetic
{
    float mag_k { get; set; }
    Polarity polarity { get; set; }
}