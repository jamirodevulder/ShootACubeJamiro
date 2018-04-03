using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LifeCounter : MonoBehaviour
{
    public Text score;
    int scor;
    public Text LevensText;
    public int levens = 3;
  
    public Transform camTransform;

    private float shakeDuration = 0f;

    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;

    Vector3 originalPos;
    private void Start()
    {
        InvokeRepeating("scored", 2.0f, 1.0f);
        UpdateUI();
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Cube(Clone)")
        {
            TakeDamage();
            shakeDuration = 3f;
        }
    }
    private void Update()
    {
        if (shakeDuration > 0)
        {
            camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shakeDuration = 0f;
            camTransform.localPosition = originalPos;
        }
    }

    private void TakeDamage()
    {
        if (levens == 1)
        {
            SceneManager.LoadScene("Dood");
        }
        else
        {
            levens = levens - 1;

            UpdateUI();
        }

    }

    private void UpdateUI()
    {
        LevensText.text = "Levens: " + levens;
    }
    void scored()
    {
        scor = scor + 1;
        score.text = "score: " + scor;
    }
    void Awake()
    {
        if (camTransform == null)
        {
            camTransform = GetComponent(typeof(Transform)) as Transform;
        }
    }

    void OnEnable()
    {
        originalPos = camTransform.localPosition;
    }

}

