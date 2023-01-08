using UnityEngine;

public abstract class Card : MonoBehaviour
{
    public Material redMaterial;
    public Material greenMaterial;
    public float width = 0.25f;

    public int cost;
    public Vector2 scaleChange; // creates scale change variable (values assigned in unity)
    public bool mouseOver;
    public Vector3 originalPOS; //original card position
    public int originalSort; //original card sorting order
    public Vector3 hoverMovement; // how much card moves when card hovered over
    public int actionPoints;
    protected Vector2 endPosition;
    protected LineRenderer lr;
    protected Player player;
    protected Vector2 startPosition;


    protected void Start()
    {
        lr = gameObject.AddComponent(typeof(LineRenderer)) as LineRenderer;
        lr.widthMultiplier = width;
        lr.enabled = false;
        lr.numCapVertices = 20;
        lr.sortingOrder = 10;
    }

    private void Update()
    {
        if (lr.enabled)
        {
            HighlightEffect hf = GameObject.FindGameObjectWithTag("CropManager").GetComponent<HighlightEffect>();
            CropManager cm = GameObject.FindGameObjectWithTag("CropManager").GetComponent<CropManager>();
            Vector3Int position = hf.GetHighlightPosition();
            
            hf.isValidTile = IsValid(cm, position);
            hf.hovering = true;
            if (IsValid(cm, position)) {
                lr.material = greenMaterial;
            } else { 
                lr.material = redMaterial;
            }
            
            startPosition = gameObject.transform.position;
            lr.SetPosition(0, startPosition);
            endPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            lr.SetPosition(1, endPosition);
        } else {
            HighlightEffect hf = GameObject.FindGameObjectWithTag("CropManager").GetComponent<HighlightEffect>();
            hf.hovering = false;
        }
    }
    
    public abstract bool IsValid(CropManager cm, Vector3Int position);
    // {
    //     if (cm.IsValidTile(position))
    //         return true;
    //     return false;
    // }

    private void OnMouseDown()
    {
        lr.enabled = true;
    }


    public void OnMouseEnter()
    {
        //getting original position and sorting order of card
        originalPOS = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        originalSort = GetComponent<SpriteRenderer>().sortingOrder;

        // makes card bigger when mouse first passes over it
        transform.localScale =
            new Vector2(transform.localScale.x + scaleChange.x, transform.localScale.y + scaleChange.y);

        // moves card to be fully on screen
        transform.position = new Vector3(originalPOS.x + hoverMovement.x, originalPOS.y + hoverMovement.y,
            originalPOS.z + hoverMovement.z);

        GetComponent<SpriteRenderer>().sortingOrder = 100;
    }

    public void OnMouseExit()
    {
        // makes card smaller when mouse leaves it
        transform.localScale =
            new Vector2(transform.localScale.x - scaleChange.x, transform.localScale.y - scaleChange.y);

        // moves card to original postion
        transform.position = originalPOS;
        GetComponent<SpriteRenderer>().sortingOrder = originalSort;
    }

    private void OnMouseUp()
    {
        lr.enabled = false;
        var hf = GameObject.FindGameObjectWithTag("CropManager").GetComponent<HighlightEffect>();
        var cm = GameObject.FindGameObjectWithTag("CropManager").GetComponent<CropManager>();
        var position = hf.GetHighlightPosition();

        if (!IsValid(cm, position))
            return;
        // Only play the card if the player is able to
        if (player.PlayCard(this))
        {
            ActionPerformed(position);
            Instantiate(Resources.Load("RipCard"), transform.position, transform.rotation);

            var gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
            gm.players[gm.currentPlayerIndex].hand.RemoveCard(this);
        }
    }

    //performs card action
    public abstract void ActionPerformed(Vector3Int position);


    public void RegisterPlayer(Player player_)
    {
        player = player_;
    }
}