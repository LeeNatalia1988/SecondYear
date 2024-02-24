/**
 * Как запустить с терминала код Java?
 * Есть ли сниппеты для Jet brains?
 */
public class Main {
    public static void main(String[] args) {
        String s = null;
        float f = 123.45f;
        double f1 = 123.45D;
        char ch = 123;
        boolean flag1 = false;
        String msg = "Hello world";
        var test1 = 123;
        int i = 23_322_34;
        System.out.println(Integer.MAX_VALUE);
        System.out.println(test1); // hello
        String sw = "qwer";
        int a = 123;
        System.out.println(++a);
    }

    static String getType(Object o) {
        return o.getClass().getSimpleName();
    }
}
