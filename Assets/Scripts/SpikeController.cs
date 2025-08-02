using UnityEngine;

public class SpikeController : MonoBehaviour
{
    [SerializeField] GameObject spikeObject;
    BoxCollider spikeCollider;

    [SerializeField] Vector3 spikeOutPosition;
    [SerializeField] Vector3 spikeInPosition;
    bool isOut;


    [SerializeField] float spikeOutTime;
    [SerializeField] float spikeInTime;
    [SerializeField] float delayTime = 0.5f;
    float timer;

    private void Start()
    {
        spikeCollider = spikeObject.GetComponent<BoxCollider>();

        isOut = false;
        SetTimer();
        timer += delayTime;
        SetPosition();
        UpdateCollider();
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            isOut = !isOut;
            SetTimer();
            SetPosition();
            UpdateCollider();
        }
    }
    private void SetTimer()
    {
        if (isOut)
        {
            timer = spikeOutTime;
        }
        else
        {
            timer = spikeInTime;
        }
    }
    private void SetPosition()
    {
        if (isOut)
        {
            spikeObject.transform.localPosition = spikeOutPosition;
        }
        else
        {
            spikeObject.transform.localPosition = spikeInPosition;
        }
    }

    private void UpdateCollider()
    {
        if (isOut)
        {
            spikeCollider.enabled = true;
        }
        else
        {
            spikeCollider.enabled = false;
        }
    }

}
