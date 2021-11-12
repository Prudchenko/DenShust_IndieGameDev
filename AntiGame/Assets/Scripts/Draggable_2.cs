using UnityEngine;

public class Draggable_2 : MonoBehaviour
{

    private Vector3 _dragOffset;
    private Camera _cam;
    bool isOnSlot = false;
    private GameObject slot;
    bool canDrag = true;
    GameObject parent;
    public int[] partID = new int[2];
    public int first, second;

    [SerializeField] private float _speed;

    void Awake()
    {
        _cam = Camera.main;
       
    }
    private void Start()
    {
        parent = transform.parent.gameObject;
    }

    public void Update()
    {
      
    }
    void OnMouseDown()
    {
        if(canDrag)
        _dragOffset = transform.position - GetMousePos();
    }
    void OnMouseUp()
    {
        //if (isOnSlot)
        //{
        //    Debug.Log("Yes");
        //    transform.position = slot.transform.position;
        //    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 3f);
        //    canDrag = false;
        //}
        //else
        //{
        //    transform.localPosition = Vector3.zero;
        //    transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z - 3f);
        //    canDrag = true;
        //}
        if (isOnSlot)
        {
            if ( slot.transform.childCount > 0)
            {
              
                GameObject child = slot.transform.GetChild(0).gameObject;
                child.transform.parent = child.GetComponent<Draggable_2>().parent.transform;
                child.GetComponent<SpriteRenderer>().color = new Color(1, 1f, 1f);
                child.transform.localPosition = Vector3.zero;
            }
            transform.parent = slot.transform;
            slot = null;
            isOnSlot = false;
        }
        transform.localPosition = Vector3.zero;
        GetComponent<SpriteRenderer>().color = new Color(1, 0.8f, 0.8f);
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1f);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Slot")) 
        {
            if (collision.GetComponent<Slot>().id == partID[0])
            {
                slot = collision.gameObject;
                isOnSlot = true;
            }
           // collision.tag = "SlotFull";
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("SlotFull")&&collision.gameObject == slot)
        {
            isOnSlot = false;
            collision.tag = "Slot";
        }
    }

    void OnMouseDrag()
    {
        if(canDrag)
        transform.position = Vector3.MoveTowards(transform.position, GetMousePos()+new Vector3(0,0,-3), _speed * Time.deltaTime);
    }

    Vector3 GetMousePos()
    {
        var mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }
}