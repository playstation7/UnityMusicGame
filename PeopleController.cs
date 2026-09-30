using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PeopleController : MonoBehaviour
{
    public Sprite[] sprites;
    Sequence sequence;
    float timeAlive;
    void Start()
    {
        ConcertManager.people++;
        float x = Random.Range(-4.5f, 4.5f);
        float y = Random.Range(-3.7f, -2.7f);
        float scale = Mathf.Lerp(0.5f, 0.6f, Mathf.Abs(2.7f + y));
        transform.localScale = new Vector3(scale, scale, 1f);
        transform.GetComponent<SpriteRenderer>().sortingOrder = 2 + (int)(y * -10); 
        transform.position = new Vector3(x, y, 0f);
        transform.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
        transform.GetComponent<SpriteRenderer>().DOFade(1f,1f).SetLink(gameObject);

        GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0,sprites.Length)];
        switch (Random.Range(0, 2)) 
        {
            case 0:
                    sequence = DOTween.Sequence()
                .Append(transform.DORotate(new Vector3(0f, 0f, 5f), 0.5f))
                .AppendInterval(1f)
                .AppendCallback(() => transform.GetComponent<SpriteRenderer>().flipX = true)
                .Append(transform.DORotate(new Vector3(0f, 0f, -5f), 0.5f))
                .AppendInterval(1f)
                .AppendCallback(() => transform.GetComponent<SpriteRenderer>().flipX = false)
                .SetLoops(-1)
                .SetLink(gameObject);
                break;
            case 1:
                    sequence = DOTween.Sequence()
                .Append(transform.DOMoveY(transform.position.y + 0.1f, 0.3f))
                .Append(transform.DOMoveY(transform.position.y - 0.1f, 0.3f))
                .AppendCallback(() => transform.GetComponent<SpriteRenderer>().flipX = true)
                .Append(transform.DOMoveY(transform.position.y + 0.1f, 0.3f))
                .Append(transform.DOMoveY(transform.position.y - 0.1f, 0.3f))
                .AppendCallback(() => transform.GetComponent<SpriteRenderer>().flipX = false)
                .SetLoops(-1)
                .SetLink(gameObject);
                break;
        }
        sequence.Play();
        timeAlive = Random.Range(15f, 20f);
    }
    private void Update()
    {
        timeAlive -= Time.deltaTime;
        if (timeAlive < 0f) transform.GetComponent<SpriteRenderer>().DOFade(0f,1f).SetLink(gameObject); 
        if(timeAlive < -1f) Destroy(gameObject);
    }

    private void OnDestroy()
    {
        ConcertManager.people--;
    }
}
