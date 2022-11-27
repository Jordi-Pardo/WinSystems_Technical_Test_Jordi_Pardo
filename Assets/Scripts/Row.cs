using UnityEngine;
public class Row : MonoBehaviour
{
    private SlotMachine _slotMachine;
    [SerializeField] Sprite[] figures;
    private int[] figuresIndexes = new int[] {5,1,2,7,4,6,3,4,1,1,5,3,6,6 };

    Vector3 initPosition = Vector3.zero;
    private Slot[] slots;
    private void Awake()
    {
        _slotMachine = FindObjectOfType<SlotMachine>();
        slots = new Slot[figuresIndexes.Length];
    }

    private void Start()
    {
        for (int i = 0; i < figuresIndexes.Length; i++)
        {
            Slot slot = Instantiate(_slotMachine.slot,initPosition,Quaternion.identity,transform);
            //slot.gameObject.transform.localPosition = Vector3.zero;
            slot.GetComponent<RectTransform>().anchoredPosition = initPosition;
            initPosition.y -= 280;
            slot.Setup(_slotMachine.GetSprite(figuresIndexes[i]));
            slots[i] = slot;
        }
    }

    private void Update()
    {
        foreach (var slot in slots)
        {
            slot.UpdateMe();
        }
    }
}
