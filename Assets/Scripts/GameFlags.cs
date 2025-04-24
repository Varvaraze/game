using UnityEngine;
public static class GameFlags
{
    public static bool taskGiven = false; // Флаг задания
    public static bool taskCompleted = false; // Флаг выполнения задания

    // Флаг для проверки, в зоне ли игрок
    public static bool isPlayerInTrigger = false; // Игрок в зоне триггера (по умолчанию false)
}
