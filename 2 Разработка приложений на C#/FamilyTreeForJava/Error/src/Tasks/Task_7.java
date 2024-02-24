package Tasks;

import java.util.Scanner;

public class Task_7 {
    public Task_7() {
    }

    public static void main(String[] args) {
        scanner();
    }

    public static void scanner() {
        Scanner scanner = new Scanner(System.in);
        System.out.println("Введите дробное число");
        String data = scanner.nextLine();

        try {
            Float number = Float.parseFloat(data);
            System.out.println("Спасибо, вы молодец!");
        } catch (NumberFormatException var3) {
            System.out.println("Ошибка ввода, введите пожалуйста дробное число");
            scanner();
        }

        scanner.close();
    }
}
