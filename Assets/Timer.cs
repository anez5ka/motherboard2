using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] Sprite zero;
    [SerializeField] Sprite one;
    [SerializeField] Sprite two;
    [SerializeField] Sprite three;
    [SerializeField] Sprite four;
    [SerializeField] Sprite five;
    [SerializeField] Sprite six;
    [SerializeField] Sprite seven;
    [SerializeField] Sprite eight;
    [SerializeField] Sprite nine;
    [SerializeField] GameObject MMinute;
    [SerializeField] GameObject mminute;
    [SerializeField] GameObject SSecond;
    [SerializeField] GameObject ssecond;
    private float elapsedTime;
    int minutes;
    int seconds;
    public bool run;

    private void Awake()
    {
        run = true;
    }
    void Update()
    {
        if (run)
        {
            elapsedTime += Time.deltaTime;
            UpdateClock();
        }
    }

    private Sprite ChangeNumber(int number)
    {
        switch (number)
        {
            case 0: return zero;
            case 1: return one;
            case 2: return two;
            case 3: return three;
            case 4: return four;
            case 5: return five;
            case 6: return six;
            case 7: return seven;
            case 8: return eight;
            default: return nine;
        }
    }
    public void Restart()
    {
        elapsedTime = 0;
        UpdateClock();
    }
    private void UpdateClock()
    {
        minutes = Mathf.FloorToInt(elapsedTime / 60);
        seconds = Mathf.FloorToInt(elapsedTime % 60);
        // Debug.Log(minutes + " : " + seconds);
        MMinute.GetComponent<Image>().sprite = ChangeNumber(minutes / 10);
        mminute.GetComponent<Image>().sprite = ChangeNumber(minutes % 10);
        SSecond.GetComponent<Image>().sprite = ChangeNumber(seconds / 10);
        ssecond.GetComponent<Image>().sprite = ChangeNumber(seconds % 10);
    }
}
