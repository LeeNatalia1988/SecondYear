//2) Вывести все простые числа от 1 до 1000

public class task2 {
    public static void Printer(int x) {
        for (int i = 1; i <= x; i++) {
            System.out.println(i);
        }
    }

    public static void main(String[] args) {
        Printer(1000);
    }
}
