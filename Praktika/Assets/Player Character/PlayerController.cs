using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // Скорость движения персонажа
    public Animator player; // Ссылка на компонент Animator для управления анимациями
    public DoorMechanic doorMechanic; // Ссылка на скрипт DoorMechanic для управления дверьми

    private CharacterController controller;

    void Start()
    {
        player = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        doorMechanic = GetComponent<DoorMechanic>(); // Находим и назначаем DoorMechanic автоматически
    }

    void Update()
    {
        // Получаем ввод с клавиатуры
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.right * horizontal + transform.forward * vertical;

        // Применяем движение к персонажу с учетом скорости
        controller.Move(moveDirection * speed * Time.deltaTime);

        // Устанавливаем параметры аниматора в зависимости от состояния движения
        bool isMoving = Mathf.Abs(horizontal) > 0.1f || Mathf.Abs(vertical) > 0.1f;
        player.SetBool("IsMoving", isMoving);

        // Проверяем, находится ли игрок рядом с дверью и открываем ее
        if (Input.GetKeyDown(KeyCode.E)) // Пример: используем клавишу "E" для взаимодействия с дверью
        {
            OpenDoorIfNearby();
        }
    }

    void OpenDoorIfNearby()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 2f)) // Проверяем, есть ли объект перед игроком в радиусе 2 метров
        {
            DoorMechanic door = hit.collider.GetComponentInParent<DoorMechanic>(); // Получаем компонент DoorMechanic с объекта двери
            if (door != null)
            {
                door.OpenDoor(); // Вызываем метод открытия двери
            }
        }
    }
}
