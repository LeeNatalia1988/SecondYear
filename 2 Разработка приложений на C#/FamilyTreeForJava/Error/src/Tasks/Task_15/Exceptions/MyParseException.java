package Tasks.Task_15.Exceptions;

public class MyParseException extends Exception {
    public MyParseException(String mistake){
        super(mistake);
    }
}