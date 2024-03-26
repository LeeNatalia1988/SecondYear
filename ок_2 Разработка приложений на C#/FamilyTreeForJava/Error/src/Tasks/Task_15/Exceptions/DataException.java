package Tasks.Task_15.Exceptions;

public class DataException extends RuntimeException{
    public DataException(int length){
        super("Количество данных должно равняться 6, но введено " + length);
    }
}