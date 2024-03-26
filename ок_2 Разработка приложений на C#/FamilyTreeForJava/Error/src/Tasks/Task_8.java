package Tasks;

public class Task_8 {
    public Task_8() {
    }

    public static void main(String[] args) {
        try {
            int d = 0;
            int catchedRes1 = 8 / d;
            System.out.println("catchedRes1 = " + catchedRes1);
        } catch (ArithmeticException var3) {
            System.out.println("Catching exception: " + String.valueOf(var3));
        }

    }
}
