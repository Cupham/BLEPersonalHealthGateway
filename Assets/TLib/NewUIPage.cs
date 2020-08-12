using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NewUIPage : MonoBehaviour 
{
    public Image IMAGE_SCROLL;
    public Image IMAGE_CONTENT;
    public GridLayoutGroup GRID;
    public RectTransform[] PAGES;
    public float PAGE_WIDTH;
    public int CURRENT_PAGE_INDEX=0;
    public int CURRENT_PAGE_INDEX_TARGET = 0;
    public float CONTENT_WIDTH;
    public Vector3 TARGET_POS;
    public bool need_to_move_to_target=false;

    public Vector3[] CENTER;
    public float SCALE_SPEED = 1.0f;
    void Awake()
    {
        PAGE_WIDTH = GRID.spacing.x + GRID.cellSize.x;
        CONTENT_WIDTH = IMAGE_CONTENT.rectTransform.sizeDelta.x;

        CENTER = new Vector3[PAGES.Length];
        for (int i = 0; i < CENTER.Length; i++)
        {
            CENTER[i] = new Vector3(Getposx(i), 0, 0);
        }
        SetPageForceHard(0);
    }
	void Start () 
    {
       

        //
	}
    public void SetPageForceHard(int page)
    {
        CURRENT_PAGE_INDEX = page;
        IMAGE_CONTENT.rectTransform.localPosition = new Vector3(Getposx(page), 0);
        SendMessage(CURRENT_PAGE_INDEX,0);
    }
    public void SetPage(int page,bool ischange=true)
    {
        CURRENT_PAGE_INDEX_TARGET = page;
        TARGET_POS = new Vector3(Getposx(page), 0);
        need_to_move_to_target = true;
        IMAGE_SCROLL.GetComponent<ScrollRect>().velocity = Vector2.zero;
        SendMessage(CURRENT_PAGE_INDEX_TARGET,0.1f);
    }
    public float Getposx(int index)
    {
        return (PAGES.Length / 2 - index) * PAGE_WIDTH;
    }
	void Update () 
    {
	    if(need_to_move_to_target)
        {
            if (Mathf.Abs(TARGET_POS.x - IMAGE_CONTENT.rectTransform.localPosition.x) > 5 * SCALE_SPEED)
            {
                if(TARGET_POS.x>IMAGE_CONTENT.rectTransform.localPosition.x)
                    IMAGE_CONTENT.rectTransform.Translate(300 * Time.deltaTime * SCALE_SPEED, 0, 0);
                else IMAGE_CONTENT.rectTransform.Translate(-300 * Time.deltaTime * SCALE_SPEED, 0, 0);
            }
            else
            {
                need_to_move_to_target = false;
                IMAGE_CONTENT.rectTransform.localPosition = TARGET_POS;
                CURRENT_PAGE_INDEX = CURRENT_PAGE_INDEX_TARGET;
               
            }
        }

        //if(Input.GetMouseButtonUp(0))
        //{
        //    if (is_mouse_down) OnMoveUp();
        //}
	}
    bool is_mouse_down = false;
    public static Vector3 mouse_old, mouse_new;
    public void OnMoveDown()
    {
        //Debug.Log("on move down");
        is_mouse_down = true;
        mouse_old = Input.mousePosition;
    }
    public void OnMoveUp()
    {
        mouse_new = Input.mousePosition;

        if(Vector3.Distance(mouse_old,mouse_new)<5)
        {
            //Debug.Log(111);
            Receiver.SendMessage(Functionname_Click, SendMessageOptions.DontRequireReceiver);
            return;
        }

        //Debug.Log("on move up");
        //SetPage(0); 
        int index = 0;
        float lenght = 99999999;
        float lenght2_ =  Mathf.Abs(IMAGE_CONTENT.rectTransform.localPosition.x - CENTER[CURRENT_PAGE_INDEX].x);
        for(int i =0;i<PAGES.Length;i++)
        {
            if (i == CURRENT_PAGE_INDEX)
            {
                if (CURRENT_PAGE_INDEX == 0)
                {
                    if (IMAGE_CONTENT.rectTransform.localPosition.x < CENTER[CURRENT_PAGE_INDEX].x) continue;
                }
                else if (CURRENT_PAGE_INDEX == PAGES.Length - 1)
                {
                    if (IMAGE_CONTENT.rectTransform.localPosition.x > CENTER[CURRENT_PAGE_INDEX].x) continue;
                }
                else continue;
            }

            if(lenght > Mathf.Abs(IMAGE_CONTENT.rectTransform.localPosition.x - CENTER[i].x))
            {
                lenght = Mathf.Abs(IMAGE_CONTENT.rectTransform.localPosition.x - CENTER[i].x);
                index = i;
            }
        }

        //Debug.Log(index + " " + CURRENT_PAGE_INDEX);
        if(index==CURRENT_PAGE_INDEX)
        {
            
            SetPage(CURRENT_PAGE_INDEX, false);
        }
        else
        {
            if (lenght < lenght2_ * 2.7f * SCALE_SPEED)
                SetPage(index, true);
            else SetPage(CURRENT_PAGE_INDEX, false);
        }
        is_mouse_down = false;
        //SetPage(Random.Range(0,5), true);
    }
    public GameObject Receiver;
    public string Functionname;
    public string Functionname_Click="OnClickNEWUI";
    public static int STATIC_PAGE;
    public void SendMessage(int page,float time)
    {
        STATIC_PAGE = page;
        StartCoroutine(sendmessagefin(time)); 
    }
    IEnumerator sendmessagefin(float time)
    {
        yield return new WaitForSeconds(time);
        Receiver.SendMessage(Functionname, SendMessageOptions.DontRequireReceiver);
        
    }

}
