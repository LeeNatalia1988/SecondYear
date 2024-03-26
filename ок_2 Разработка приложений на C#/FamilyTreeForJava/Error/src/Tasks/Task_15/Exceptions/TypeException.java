package Tasks.Task_15.Exceptions;

public class TypeException extends RuntimeException {
    public TypeException(String data){
        super("Неверный тип данных в ФИО: " + data);
    }
}