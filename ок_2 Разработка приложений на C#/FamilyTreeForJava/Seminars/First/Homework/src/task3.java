//3) Реализовать простой калькулятор

public class task3 {
    public static int Sum(int x, int y) {
        return x + y;
        }

    public static int Subtraction(int x, int y) {
        return x - y;
    }

    public static int Division(int x, int y) {
        return x/y;
    }

    public static int Multiply(int x, int y) {
        return x*y;
    }

    public static void main(String[] args) {
        System.out.println(Sum(5, 6));
        System.out.println(Subtraction(5, 6));
        System.out.println(Division(5, 6));
        System.out.println(Multiply(5, 6));
    }
}
