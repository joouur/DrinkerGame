using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoScrollRect : ScrollRect
{

    private UserContentFitter contentFitter;

    private VerticalLayoutGroup verticalLayoutGroup;

    private float disableMarginY = 0;

    private bool hasDisabledGridComponents = false;

    private Vector2 newAnchoredPosition = Vector2.zero;

    private float treshold = 100f;
    private int itemCount = 0;
    private float recordOffsetY = 0;

    public Vector2 currentUserPosition;

    public float moveDuration = 1.25f;

    protected override void Start()
    {
        base.Start();
        Init();
    }

    protected virtual void Init()
    {
        this.movementType = ScrollRect.MovementType.Unrestricted;

        contentFitter = content.GetComponent<UserContentFitter>();
        this.onValueChanged.AddListener(OnScroll);
        verticalLayoutGroup = content.GetComponent<VerticalLayoutGroup>();

        itemCount = this.content.childCount;
    }

    private void DisableGridComponents()
    {

        recordOffsetY = contentFitter.Users[0].GetComponent<RectTransform>().anchoredPosition.y - contentFitter.Users[1].GetComponent<RectTransform>().anchoredPosition.y;
        disableMarginY = recordOffsetY * itemCount / 2;

        if (verticalLayoutGroup)
        {
            verticalLayoutGroup.enabled = false;
        }
        hasDisabledGridComponents = true;
    }

    public void OnScroll(Vector2 pos)
    {
        if (!hasDisabledGridComponents)
            DisableGridComponents();

        for (int i = 0; i < contentFitter.Users.Count; i++)
        {

            if (this.transform.InverseTransformPoint(contentFitter.Users[i].gameObject.transform.position).y > disableMarginY + treshold)
            {
                newAnchoredPosition = contentFitter.Users[i].anchoredPosition;
                newAnchoredPosition.y -= itemCount * recordOffsetY;
                contentFitter.Users[i].anchoredPosition = newAnchoredPosition;
                this.content.GetChild(itemCount - 1).transform.SetAsFirstSibling();
            }
            else if (this.transform.InverseTransformPoint(contentFitter.Users[i].gameObject.transform.position).y < -disableMarginY)
            {
                newAnchoredPosition = contentFitter.Users[i].anchoredPosition;
                newAnchoredPosition.y += itemCount * recordOffsetY;
                contentFitter.Users[i].anchoredPosition = newAnchoredPosition;
                this.content.GetChild(0).transform.SetAsLastSibling();
            }
        }
    }

    public IEnumerator MoveToNextUser()
    {
        float elapsedTime = 0.0f;
        Vector3 initPos = content.localPosition;

        Vector3 newPos = currentUserPosition;
        newPos.y += 875;

        float SqrRemDistanceMag = (content.localPosition - newPos).sqrMagnitude;

        while (SqrRemDistanceMag > float.Epsilon)
        {
            elapsedTime += Time.deltaTime;

            content.localPosition = Vector2.Lerp(initPos, newPos, elapsedTime / moveDuration);
            SqrRemDistanceMag = (content.localPosition - newPos).sqrMagnitude;
            yield return null;
        }
        currentUserPosition = content.localPosition;
    }
}