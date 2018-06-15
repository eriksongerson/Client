namespace Client.Models{
    // Перечисление типа вопроса
    public enum Type : int {
        single = 1, // тип одиночного ответа
        multiple = 2, // тип множественного ответа
        filling = 3, // тип заполнения
    }
}
