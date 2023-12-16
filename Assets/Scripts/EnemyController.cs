using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Animator animator; // Animator del enemigo

    public float movementSpeed = 6f;
    public float rotationSpeed = 70f;
    public float minDistanceToWall = 3f;
    public float chaseRange = 10f; // Nueva variable para el rango de persecución
    public LayerMask wallLayer;
    public Transform player; // Referencia al objeto del jugador

    private bool rotating = false;
    private float targetRotation = 0f;
    private Vector3 randomPosition;

    public float damage = 10f;
    public float damageSpeed = 1f;
    private bool isNearPlayer = false;
    private bool isRepeating = false;
    private bool isRepeating2 = false;


    void Start(){
        animator = GetComponent<Animator>(); // Obtener el Animator del enemigo
        player = GameObject.FindGameObjectWithTag("Player").transform; // Obtener el objeto del jugador
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);


        if (distanceToPlayer < chaseRange)
        {
            ChasePlayer();
        }
        else
        {
            AudioSource[] audioSources = GetComponentsInChildren<AudioSource>();
            foreach (AudioSource audioSource in audioSources){
                Destroy(audioSource);
            }

            if (!rotating)
            {
                MoveTowardsWall();
            }
            else
            {
                RotateToTarget();
            }
        }
    }

    private void MoveTowardsWall()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, wallLayer))
        {
            Vector3 directionToWall = hit.point - transform.position;

            Quaternion rotationToWall = Quaternion.LookRotation(directionToWall.normalized);

            transform.rotation = Quaternion.Slerp(transform.rotation, rotationToWall, Time.deltaTime * rotationSpeed);

            transform.position += transform.forward * movementSpeed * Time.deltaTime;

            if (!rotating && hit.distance < minDistanceToWall)
            {
                rotating = true;
                SetRandomTargetRotation();
            }
        }
    }

    private void SetRandomTargetRotation()
    {
        randomPosition = new Vector3(Random.Range(-180f, 180f), transform.position.y, Random.Range(-180f, 180f));
        Vector3 directionToRandom = randomPosition - transform.position;
        directionToRandom.y = 0;

        Quaternion rotationToRandom = Quaternion.LookRotation(directionToRandom.normalized);
        targetRotation = rotationToRandom.eulerAngles.y;
    }

    private void RotateToTarget()
    {
        float currentRotation = transform.rotation.eulerAngles.y;
        float newRotation = Mathf.MoveTowardsAngle(currentRotation, targetRotation, rotationSpeed * Time.deltaTime);

        transform.rotation = Quaternion.Euler(0f, newRotation, 0f);

        if (Mathf.Abs(newRotation - targetRotation) < 0.5f)
        {
            rotating = false;
        }
    }

    private void ChasePlayer()
    {
        Vector3 directionToPlayer = player.position - transform.position;
        directionToPlayer.y = 0;

        Quaternion rotationToPlayer = Quaternion.LookRotation(directionToPlayer.normalized);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotationToPlayer, Time.deltaTime * rotationSpeed);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, wallLayer))
        {
            // Si no hay pared, sigue moviéndose hacia el jugador
            transform.position += transform.forward * movementSpeed * Time.deltaTime;

            // Verifica la distancia entre el enemigo y el jugador
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);
            if (distanceToPlayer < 1.5f) // Cambia este valor según la proximidad deseada
            {
                if (!isNearPlayer)
                {
                    isNearPlayer = true;
                    if (!isRepeating)
                    {
                        isRepeating = true;
                        InvokeRepeating("DoSomethingRepeatedly", 0f, damageSpeed); // Llama a la función cada segundo
                    }
                }
            }
            else
            {
                if (isNearPlayer)
                {
                    isNearPlayer = false;
                    animator.SetBool("Attack", false);
                }
            }
        }
        if(!isRepeating2){
            InvokeRepeating("activeFear", 0f, 2f);
            isRepeating2 = true;
        }
    }
    
    void activeFear(){
        AudioSource[] audioSources = GetComponentsInChildren<AudioSource>();
        if(audioSources.Length < 5){
            gameObject.AddComponent<AudioSource>();
            AudioSource audio = gameObject.GetComponent<AudioSource>();
            AudioClip audioClip = Resources.Load<AudioClip>("Music/miedo");
            audio.clip = audioClip;
            audio.loop = true;
            audio.Play();
        }
    }

    void DoSomethingRepeatedly(){
        // Aquí colocas la lógica que quieres ejecutar cada segundo cuando el enemigo esté cerca del jugador
        Debug.Log("Damage player");
        if(isNearPlayer){
            animator.SetBool("Attack", true);
            player.GetComponent<PlayerHealth>().RecibirDaño(damage);

            gameObject.AddComponent<AudioSource>();

            AudioSource audio = gameObject.GetComponent<AudioSource>();
            AudioClip audioClip = Resources.Load<AudioClip>("Music/susto");
            audio.clip = audioClip;
            audio.Play();
        }
    }
    void OnDestroy(){
        if (isRepeating)
        {
            CancelInvoke("DoSomethingRepeatedly");
            animator.SetBool("Attack", false);
        }
        if(isRepeating2){
            CancelInvoke("activeFear");
        }
    }
}
