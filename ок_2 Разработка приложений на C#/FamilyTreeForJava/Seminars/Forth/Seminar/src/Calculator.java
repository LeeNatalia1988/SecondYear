import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class Calculator {
    private static Node head;
    private static Node tail;
    public static void main(String[] args) throws IOException {
        File file = new File("log.txt");

        try {
            FileWriter fileWriter = new FileWriter(file, true);
            Scanner scanner = new Scanner(System.in);
            System.out.print("Введите 1 число: ");
            int a = Integer.parseInt(scanner.nextLine());
            System.out.print("Введите операцию: ");
            char op = scanner.nextLine().charAt(0);
            System.out.print("Введите 2 число: ");
            int b = Integer.parseInt(scanner.nextLine());


            switch (op) {
                case '+' -> {
                    String resultAdd = a + " + " + b + " = " + add(a, b);
                    System.out.println(resultAdd);
                    fileWriter.write(resultAdd + '\n');
                }
                case '-' -> {
                    String resultMinus = a + " - " + b + " = " + minus(a, b);
                    System.out.println(resultMinus);
                    fileWriter.write(resultMinus + '\n');
                }
                case '*' -> {
                    String resultMulti = a + " * " + b + " = " + multi(a, b);
                    System.out.println(resultMulti);
                    fileWriter.write(resultMulti + '\n');
                }
                case '/' -> {
                    String resultDivide = a + " / " + b + " = " + divide(a, b);
                    System.out.println(resultDivide);
                    fileWriter.write(resultDivide + '\n');
                }
                case 'u' -> undoLastOperation();
                default -> System.out.println("Wrong operation!");
            }
            fileWriter.flush();
            fileWriter.close();
        }
        catch (Exception e){
            System.out.println("Исключение при работе с файлом.");
        }

    }
    private static void undoLastOperation() {
        try {
            File file = new File("log.txt");
            Scanner scanner = new Scanner(file);

            List<String> operations = new ArrayList<>();
            while (scanner.hasNextLine()) {
                String operation = scanner.nextLine();
                operations.add(operation);
            }
            if (!operations.isEmpty()) {
                String lastOperation = operations.get(operations.size() - 1);
                operations.remove(operations.size() - 1);

                FileWriter fileWriter = new FileWriter(file, false);
                for (String operation : operations) {
                    fileWriter.write(operation + "\n");
                }
                fileWriter.flush();
                fileWriter.close();

                System.out.println("Отменена последняя операция: " + lastOperation);
            } else {
                System.out.println("Нет операций для отмены.");
            }
        } catch (IOException e) {
            System.out.println("Ошибка при чтении файла log.txt.");
        }
    }
    private static int divide(int a, int b){
        if (b != 0) return a/b;
        return -1;
    }
    private static int multi(int a, int b){
        return a * b;
    }
    private static int add(int a, int b){
        return a + b;
    }
    private static int minus(int a, int b){
        return a - b;
    }
}