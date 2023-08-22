using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    public Weapon weapon;
    public Camera SceneCamera;
    public float speed;
    public Rigidbody2D rb;
    private Vector2 direction;
    private Transform cam;

    private int Hp = 0;
    private int MaxHp = 100;
    private float Damage = 2f;
    private int PlayerLevel;
    private Vector2 mousePosition;

    private float IframeDuration = 2;
    private int Flashes = 3;
    private SpriteRenderer spriteRend;

    private void Awake()
    {
        spriteRend = GetComponentInChildren<SpriteRenderer>();
    }
    private void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
        Hp = 100;
    }
    void Update()
    {
        processInputs();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void processInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        direction = new Vector2(moveX, moveY).normalized;
        mousePosition = SceneCamera.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0) && Time.timeScale != 0) { weapon.fire(); }

    }

    public int GetPlayerLevel() { return PlayerLevel; }

    public float GetDamage() { return Damage; }

    public void IncreaseLevel() { Damage = Damage + 0.5f; PlayerLevel = PlayerLevel + 1; }

    public int GetHp() { return Hp; }

    public int GetMaxHp() {  return MaxHp; }

    public void increaseMaxHp(int n) { MaxHp = MaxHp + n; }

    public void IncreaseHp(int n) {Hp = Hp + n; if (Hp > MaxHp) { Hp = MaxHp; } }

    public void DecreaseHp(int n) {
        Hp = Hp - n;
        if (Hp < 0) { Hp = 0;}
        StartCoroutine(Invunrability());
    }

    private void Move()
    {
        rb.velocity = new Vector2(direction.x * speed, direction.y * speed);

        Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Camera")
        {
            collision.gameObject.transform.parent.gameObject.layer = 3;
            Transform[] children = collision.gameObject.transform.parent.GetComponentsInChildren<Transform>(includeInactive: true);
            foreach (Transform child in children) 
            { 
               child.gameObject.layer = 3;
            }
            Vector3 pos = collision.transform.position;
            pos.z = -10;
            cam.position = pos;
        }

        if (collision.tag == "Finish")
        {
            UIScript.isFinished = true;
        }
    }

    private IEnumerator Invunrability() {
        Physics2D.IgnoreLayerCollision(6,7,true);
        for (int i = 0; i < Flashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(IframeDuration/(Flashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(IframeDuration/(Flashes * 2));
        }
        Physics2D.IgnoreLayerCollision(6, 7, false);
    }
}
