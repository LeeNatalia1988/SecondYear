package Tasks;


import java.io.FileNotFoundException;

public class Task_13 {
    public static void main(String[] args) {
        try {
            throw new DivideByZeroException("Деление на ноль!");
        } catch (DivideByZeroException ex) {
            System.err.println("Перехвачено собственное исключение DivideByZero: " + ex.getMessage());
        }
        try {
            throw new NotFoundException("Файл не найден!");
        } catch (NotFoundException ex) {
            System.err.println("Перехвачено собственное исключение NotFoundException: " + ex.getMessage());
        }
        try {
            throw new NullException("Пустой элемент массива!");
        } catch (NullException ex) {
            System.err.println("Перехвачено собственное исключение NullException: " + ex.getMessage());
        }
    }

    public static class DivideByZeroException extends ArithmeticException {
        public DivideByZeroException(String message) {
            super(message);
        }
    }

    public static class NullException extends NullPointerException {
        public NullException(String message) {
            super(message);
        }
    }

    public static class NotFoundException extends FileNotFoundException {
        public NotFoundException(String message) {
            super(message);
        }
    }
}