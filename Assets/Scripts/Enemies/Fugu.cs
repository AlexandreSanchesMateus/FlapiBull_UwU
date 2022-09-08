using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fugu : Entity
{
    //[SerializeField] private AnimationCurve animation;

    [SerializeField] private float size;
    [SerializeField] private float timeBig;
    [SerializeField] private float timeLow;

    //[SerializeField] private float speed;

    // private bool isGrowing;
    // private float time;
    private Vector3 defaultSize;
    private bool hasBeenActivate = false;
    private CircleCollider2D circleCollide;
    [SerializeField] private Sprite fuguGros;
    [SerializeField] private Sprite fuguPetit;
    private SpriteRenderer spriteRenderer;

    /*private void Start()
    {
        defaultSize = transform.localScale;
        StartCoroutine(FuguGrowing());
    }*/

    public override void OnActivation()
    {
        circleCollide = GetComponent<CircleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        hasBeenActivate = true;

        defaultSize = transform.localScale;
        StartCoroutine(FuguGrowing());
    }

    private void Update()
    {
        if (!PlayerData.instance.isScoring && hasBeenActivate)
        {
            StopAllCoroutines();
            this.enabled = false;
        }
    }

    private IEnumerator FuguGrowing()
    {
        while (true)
        {
            circleCollide.radius = 0.24f;
            spriteRenderer.sprite = fuguPetit;
            yield return new WaitForSeconds(timeLow);


            circleCollide.radius = 0.63f;
            spriteRenderer.sprite = fuguGros;
            yield return new WaitForSeconds(timeBig);
        }
    }

    // ENCORE CES CONNARDS DE GD
    /*private bool FuguGrowing(bool reverse)
    {
        if (reverse)
        {
            if (time < 0)
                return true;
            time -= Time.deltaTime * speed;
        }
        else
        {
            if (time > 1)
                return true;
            time += Time.deltaTime * speed;
        }

        transform.localScale = new Vector3(animation.Evaluate(time) * size, animation.Evaluate(time) * size, 0);

        return false;
    }*/
}
