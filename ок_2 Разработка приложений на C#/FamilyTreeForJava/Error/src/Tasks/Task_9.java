package Tasks;

public class Task_9 {
    public Task_9() {
    }

    public static void main(String[] args) {
        try {
            int a = 90;
            int b = 3;
            System.out.println(a / b);
            printSum(23, 234);
        } catch (NullPointerException var3) {
            System.out.println("Указатель не может указывать на null!");
        } catch (IndexOutOfBoundsException var4) {
            System.out.println("Массив выходит за пределы своего размера!");
        } catch (Throwable var5) {
            System.out.println("Что-то пошло не так...");
        }

    }

    public static void printSum(int a, int b) {
        System.out.println(a + b);
    }
}
