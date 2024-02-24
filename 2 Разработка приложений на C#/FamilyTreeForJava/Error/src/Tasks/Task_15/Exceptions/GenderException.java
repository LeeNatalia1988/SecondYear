package Tasks.Task_15.Exceptions;

public class GenderException extends RuntimeException {
    public GenderException(String data){
        super("Неверный пол, допустимо только 'm' или 'f': " + data);
    }
}