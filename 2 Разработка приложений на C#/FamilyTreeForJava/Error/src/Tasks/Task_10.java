package Tasks;

import java.util.Objects;
import java.util.Scanner;

public class Task_10 {
    public Task_10() {
    }

    public static void main(String[] args) {
        scanner();
    }

    public static void scanner() {
        Scanner scanner = new Scanner(System.in);
        System.out.println("Введите вашу будущую зарплату");
        String data = scanner.nextLine();
        if (Objects.equals(data, "")) {
            throw new RuntimeException("Вы не ввели вашу зпшечку");
        } else {
            System.out.println("Думаю все еще впереди");
            scanner.close();
        }
    }
}
