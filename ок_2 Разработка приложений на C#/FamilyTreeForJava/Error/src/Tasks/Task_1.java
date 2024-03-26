package Tasks;

public class Task_1 {
    public Task_1() {
    }

    public static void main(String[] args) {
        int[] array = new int[]{1, 2, 3, 4};
        int n = 7;
        System.out.println(CheckSize(array, n));
    }

    public static int CheckSize(int[] array, int n) {
        return array.length < n ? -1 : array.length;
    }
}
