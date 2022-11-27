using System.Linq;
using UnityEngine;
public class Row : MonoBehaviour
{
    private SlotMachine _slotMachine;
    [SerializeField] Sprite[] figures;
    private int[] figuresIndexes = new int[] {5,1,2,7,4,6,3,4,1,1,5,3,6,6 };
    Vector3 initPosition = Vector3.zero;
    private Slot[] slots;
    [SerializeField] private float speed = 10f;
    private bool wantsToStop = false;
    bool scroll = false;
    float scrollDuration = 2f;
    float scrollTime = 0f;

    private void Awake()
    {
        _slotMachine = FindObjectOfType<SlotMachine>();
        slots = new Slot[figuresIndexes.Length];
    }

    private void Start()
    {
        for (int i = figuresIndexes.Length - 1; i >= 0; i--)
        {
            Slot slot = Instantiate(_slotMachine.slot,initPosition,Quaternion.identity,transform);
            slot.gameObject.transform.localPosition = initPosition;
            initPosition.y += 2.2f;
            //slot.GetComponent<RectTransform>().anchoredPosition = initPosition;
            //initPosition.y -= 280;
            slot.Setup(_slotMachine.GetSprite(figuresIndexes[i]));
            slots[i] = slot;
        }
        wantsToStop = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //scroll = !scroll;
            //scrollTime = 0f;
            foreach (var item in slots)
            {
                item.StartScroll();
            }
        }

        if (!scroll)
            return;

        if (scrollTime < scrollDuration)
        {
            scrollTime += Time.deltaTime;
        }
        else
        {

            Debug.Log("Stoppping");
            if (speed > 0)
            {
                if (speed <= 5)
                {
                    //orderedList = slots.OrderBy((slot) => slot.transform.localPosition.y).ToArray();
                    //shortestSlot = orderedList[0];
                    //getlastSlot = false;
                    speed = -1f;
                    wantsToStop = true;

                }
                else
                {
                    speed -= 20 * Time.deltaTime;
                }
            }

        }

        if(speed <= 0)
        {
            speed = 0;
        }
        //foreach (var slot in slots)
        //{
        //    slot.UpdateMe(speed,wantsToStop);
        //}


    }

    public void Scroll()
    {
        speed = Random.Range(2f, 4f);
        scroll = true;
    }
}
