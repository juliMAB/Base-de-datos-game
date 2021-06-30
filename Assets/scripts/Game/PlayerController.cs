using System;
using System.Collections;
using System.Collections.Generic;
using Assets.scripts.GameManager;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Action playerChangeAction;
    public Action playerSaveAction;
    [SerializeField] private int vidas;
    [SerializeField] private int score;
    [SerializeField] private bool saltar=false;
    public int vidasGet => vidas;
    public int scoreGet => score;
    public bool saltarGet => saltar;
    
    [SerializeField] private float speed;

    [SerializeField] private GameObject spawn;
    [SerializeField] private Rigidbody rBody;
    [SerializeField] private float saltoF;
    [SerializeField] private float gravedad;
    [SerializeField] private float saltoT;
    [SerializeField] private float saltoColdown;

    Animator animator;

    void Start()
    {
        rBody = GetComponent<Rigidbody>();
        playerChangeAction?.Invoke();
        saltoT = 0;
        if (FindObjectOfType<GameManager>())
        {
            GameManager.Get().GetPlayer();
        }
        animator = GetComponentInChildren<Animator>();
    }
    void Update()
    {

        if (MoveCharacter(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"))))
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
        
        if (EnPiso())
        {
            if (!saltar)
            {
                saltoT -= Time.deltaTime;
                if (saltoT<0)
                {
                    
                    saltar = true;
                    playerChangeAction?.Invoke();
                    animator.SetBool("isFlying", false);
                }
            }
            else
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    saltar = false;
                    Saltar();
                    playerChangeAction?.Invoke();
                    saltoT = saltoColdown;
                    animator.SetBool("isFlying", true);
                }
            }
        }
    }


    bool MoveCharacter(Vector3 dir)
    {
        if (dir!= Vector3.zero)
        {
            transform.Translate(dir * speed * Time.deltaTime);
            return true;
        }
        else
        {
            return false;
        }
        
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Lava"))
        {
            vidas--;
            transform.position = spawn.transform.position+ Vector3.up *gameObject.transform.localScale.y;
            playerChangeAction?.Invoke();
        }
    }

    bool EnPiso()
    {
        Debug.DrawLine(transform.position, transform.position + Vector3.down * gameObject.transform.localScale.y/2 + Vector3.down * 0.001f);
        if (Physics.Raycast(transform.position, Vector3.down, gameObject.transform.localScale.y/2+ 0.001f))
        {
            return true;
        }
        return false;
    }

    void Saltar()
    {
        rBody.AddForce((saltoF * Vector3.up) + rBody.velocity * 10);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Moneda"))
        {
            if (other.GetComponent<moneda>().estado == moneda.color.Amarillo)
            {
                score++;
            }
            else
            {
                vidas--;
            }
            playerChangeAction?.Invoke();
            Destroy(other.gameObject);

        }

        if (other.CompareTag("PuntoGuardado"))
        {
            playerSaveAction?.Invoke();
        }
        if (vidas < 0)
        {
            if (LoaderManager.Get()!=null)
            {
                LoaderManager.Get().LoadScene("End");
            }
            
        }
    }
}
