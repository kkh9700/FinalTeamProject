using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    public Image icon;
    private GameObject clone;
    private Canvas canvas;
    private RectTransform rect;
    private Skill skill;

    private void Awake()
    {
        canvas = GetComponentInParent<Canvas>();
    }

    public void SetSkill(Skill skill)
    {
        this.skill = skill;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        clone = Instantiate(gameObject, canvas.GetComponent<Transform>());
        rect = clone.GetComponent<RectTransform>();
        SkillDrag sd = clone.GetComponent<SkillDrag>();
        sd.SetSkill(GetComponentInParent<SkillSlot>().GetSkill());

        rect.sizeDelta = new Vector2(100, 100);

        Image image = sd.icon;
        Color color = image.color;
        color.a = .8f;
        image.color = color;
    }

    public void OnDrag(PointerEventData eventData)
    {
        clone.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Destroy(clone);
    }

    public void OnDrop(PointerEventData eventData)
    {
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);

        foreach (RaycastResult result in results)
        {
            if (result.gameObject.TryGetComponent<QuickSlot>(out QuickSlot quickSlot))
            {
                if (skill is IUsable)
                {
                    quickSlot.SetSlot((IUsable)skill);
                }
            }
        }
    }
}
