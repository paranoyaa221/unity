using UnityEngine;

public class DoorMechanic : MonoBehaviour
{
    public Animator doorAnimator; // Аниматор двери
    public string openTriggerName = "Open"; // Название триггера для открытия
    public string closeTriggerName = "Close"; // Название триггера для закрытия

    // Метод для открытия двери
    public void OpenDoor()
    {
        doorAnimator.SetTrigger(openTriggerName);
    }

    // Метод для закрытия двери
    public void CloseDoor()
    {
        doorAnimator.SetTrigger(closeTriggerName);
    }

    void Start()
    {
        doorAnimator = GetComponent<Animator>(); // Получаем компонент аниматора из объекта
    }

    // Не забудьте удалить метод Update(), так как мы больше не используем его
}
