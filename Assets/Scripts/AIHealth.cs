using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.ThirdPerson;
using System.Collections;

[RequireComponent(typeof(ThirdPersonCharacter))]
[RequireComponent(typeof(Rigidbody))]

public class AIHealth : MonoBehaviourPunCallbacks, IPunObservable
{
    public delegate void Respawn(float time);
    public delegate void AddMessage(string Message);
    // public event AddMessage AddMessageEvent;

    [SerializeField]
    private int startingHealth = 100;
    [SerializeField]
    private float sinkSpeed = 0.12f;
    [SerializeField]
    private float sinkTime = 2.5f;
    [SerializeField]
    private float respawnTime = 8.0f;
    [SerializeField]
    private AudioClip deathClip;
    [SerializeField]
    private AudioClip hurtClip;
    [SerializeField]
    private AudioSource playerAudio;
    // [SerializeField]
    // private float flashSpeed = 2f;
    // [SerializeField]
    // private Color flashColour = new Color(1f, 0f, 0f, 0.1f);
    [SerializeField]
    private NameTag nameTag;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private GameObject aiModel;
    [SerializeField]
    private Transform aiTransform;

    private ThirdPersonCharacter tpController;
    private IKControl ikControl;
    // private Slider healthSlider;
    // private Image damageImage;
    private int currentHealth;
    private bool isDead;
    private bool isSinking;
    private bool damaged;

    // Start is called before the first frame update
    void Start()
    {
        tpController = GetComponent<ThirdPersonCharacter>();
        ikControl = GetComponentInChildren<IKControl>();
        // damageImage = GameObject.FindGameObjectWithTag("Screen").transform.Find("DamageImage").GetComponent<Image>();
        // healthSlider = GameObject.FindGameObjectWithTag("Screen").GetComponentInChildren<Slider>();
        currentHealth = startingHealth;
        if (photonView.IsMine) {
            gameObject.layer = LayerMask.NameToLayer("Shootable");
            // healthSlider.value = currentHealth;
        }
        damaged = false;
        isDead = false;
        isSinking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (damaged) {
            damaged = false;
            // damageImage.color = flashColour;
        } else {
            // damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        if (isSinking) {
            transform.Translate(Vector3.down * sinkSpeed * Time.deltaTime);
        }
    }

    [PunRPC]
    public void TakeDamage(int amount) {
        if (isDead) return;
        if (photonView.IsMine) {
            damaged = true;
            currentHealth -= amount;
            if (currentHealth <= 0) {
                photonView.RPC("Death", RpcTarget.All);
            }
            animator.SetTrigger("IsHurt");
        }
        playerAudio.clip = hurtClip;
        playerAudio.Play();
    }

    [PunRPC]
    void Death() {
        isDead = true;
        ikControl.enabled = false;
        nameTag.gameObject.SetActive(false);
        if (photonView.IsMine) {
            animator.SetTrigger("IsDead");
            StartCoroutine(AIRespawnCoroutine(respawnTime));
            StartCoroutine("DestroyPlayer", respawnTime);
        }
        playerAudio.clip = deathClip;
        playerAudio.Play();
        StartCoroutine("StartSinking", sinkTime);
    }

    IEnumerator AIRespawnCoroutine(float spawnTime) {
        yield return new WaitForSeconds(spawnTime);
        // int playerIndex = Random.Range(0, playerModel.Length);
        // int spawnIndex = Random.Range(0, spawnPoints.Length);
        var newBot = PhotonNetwork.Instantiate(this.name, this.transform.position, this.transform.rotation, 0);
        newBot.name = "AIRobotX";
    }

    IEnumerator DestroyPlayer(float delayTime) {
        yield return new WaitForSeconds(delayTime);
        PhotonNetwork.Destroy(gameObject);
    }

    IEnumerator StartSinking(float delayTime) {
        yield return new WaitForSeconds(delayTime);
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.useGravity = false;
        rigidbody.isKinematic = false;
        isSinking = true;
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
        if (stream.IsWriting) {
            stream.SendNext(currentHealth);
        } else {
            currentHealth = (int)stream.ReceiveNext();
        }
    }

}
