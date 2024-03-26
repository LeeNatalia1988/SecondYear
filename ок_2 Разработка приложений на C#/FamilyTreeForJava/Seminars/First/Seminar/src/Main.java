import java.nio.charset.StandardCharsets;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        String num = "12323";
        Integer a = Integer.parseInt(num);
        int b = 90;
        System.out.println(true);

        Scanner scanner = new Scanner(System.in, StandardCharsets.UTF_8);

        System.out.print("Введите имя: ");
        String name = scanner.nextLine();

        System.out.print("Введите возраст: ");
        int age = scanner.nextInt();

        System.out.println("Привет, " + name + "! Тебе " + age + " лет.");

        scanner.close();
    }
}


//import java.util.Scanner;
//public class Main
//{
//    public static Integer DO(Integer b){
//        b+=10;
//        return b;
//    }
//    public static void main(String[] args) {
//        Scanner in = new Scanner(System.in);
//        System.out.println("Сколько вам лет ?");
//        int age = in.nextInt();
//        System.out.println("Как вас зовут ?");
//        String name = in.nextLine();
//
//        System.out.println("Hello " + name);
//        int x = 9;
//        String num = "12343567";
//        boolean flag = true;
//        int a = Integer.parseInt(num);
//        //Integer a = Integer.parseInt(num);
//        Integer b = new Integer(num);
//        b = DO(b);
//        System.out.println(b + 10);
//        System.out.println(!((x > 10) && (x < 20)) ^ ( num == "Ivan") || !(x < 20));
//        System.out.println("bghjmhmrewrt4r8wt ehaspfj");
//        System.out.print("vbs");
//        System.out.printf("%n Hello %s!%nЧисло х = %s", "World", b);
//        int[] array = new int[12];
//        for (int i = 0; i < array.length; i++) {
//            array[i] = (int) Math.round((Math.random() * 30) - 1);
//            System.out.println(array[i]);
//        }
//    }
//}