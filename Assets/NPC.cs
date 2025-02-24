using UnityEngine;

namespace Unity.FantasyKingdom
{
    using UnityEngine;
    using TMPro;
    using UnityEngine.UI;

    public class NPCInteraction : MonoBehaviour
    {
        public GameObject panelDialogue;
        public TMP_Text dialogueText;
        public TMP_Text pressFText;
        public Button closeButton;
        public string npcDialogue = "Xin chào, đây là một nhiệm vụ quan trọng dành cho bạn!";

        private bool isPlayerInRange = false;

        void Start()
        {
            panelDialogue.SetActive(false);
            closeButton.onClick.AddListener(CloseDialogue); // Gán sự kiện cho nút Close
        }

        void Update()
        {
            if (isPlayerInRange && Input.GetKeyDown(KeyCode.F))
            {
                ToggleDialogue();
            }
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                isPlayerInRange = true;
                pressFText.gameObject.SetActive(true); // Hiện gợi ý nhấn F
            }
        }

        void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                isPlayerInRange = false;
                panelDialogue.SetActive(false);
                pressFText.gameObject.SetActive(false); // Ẩn gợi ý nhấn F
            }
        }

        void ToggleDialogue()
        {
            bool isActive = !panelDialogue.activeSelf;
            panelDialogue.SetActive(isActive);
            dialogueText.text = isActive ? npcDialogue : "";
            pressFText.gameObject.SetActive(!isActive); // Ẩn gợi ý nhấn F khi mở Panel
        }

        void CloseDialogue()
        {
            panelDialogue.SetActive(false);
            pressFText.gameObject.SetActive(true); // Hiện lại gợi ý nhấn F
        }
    }
}
