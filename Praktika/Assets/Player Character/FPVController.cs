using UnityEngine;

public class FPVController : MonoBehaviour
{
    public float sensitivity = 100f; // Чувствительность мыши
    public Transform player;
    private float mouseX;
    private float mouseY;
    private float xRotation = 0f;

    void Update()
    {
        // Получаем ввод с мыши для вращения камеры
        mouseX = Input.GetAxis("Mouse X") * sensitivity;
        mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        // Поворачиваем тело персонажа по горизонтали
        player.Rotate(Vector3.up * mouseX);

        // Поворачиваем камеру по вертикали
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -45f, 45f); // Ограничиваем угол обзора
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
