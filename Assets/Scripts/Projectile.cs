using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    private bool hit;
    private BoxCollider2D box;
    private Animator anim;
    private float direction;
    private float lifetime;

    private void Awake()
    {
        box = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        speed = 15f;
    }

    private void Update()
    {
        if (hit) return;
        float movementSpeed = speed * Time.deltaTime;
        transform.Translate(movementSpeed * direction, 0, 0);
        lifetime += Time.deltaTime;
        if (lifetime > 10) gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        box.enabled = false;
        anim.SetTrigger("explode");
    }
    public void SetDirection(float direction)
    {
        lifetime = 0;
        this.direction = direction;
        gameObject.SetActive(true);
        hit = false;
        box.enabled = true;

        float localScalex = -direction;

        transform.localScale = new Vector3(localScalex, transform.localScale.y, transform.localScale.z);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
