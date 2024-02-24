import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Main {
    public static void main(String[] args) {
        final RedBlackTree tree = new RedBlackTree();
        try (BufferedReader reader = new BufferedReader(new InputStreamReader(System.in))) {
            while (true) {
                try {
                    int value = Integer.parseInt(reader.readLine().trim());
                    tree.add(value);
                    System.out.println("finish");
                } catch (NumberFormatException e) {
                    System.out.println("Invalid input. Please enter an integer.");
                }
            }
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }
}
//        BinTree tree = new BinTree();
//        tree.add(5);
//        tree.add(1);
//        tree.add(9);
//        tree.add(7);
//        tree.add(6);
//        tree.add(2);
//        tree.add(0);
//
//
//        System.out.println(tree.contain(5));
//        System.out.println(tree.contain(1));
//        System.out.println(tree.contain(9));
//        System.out.println(tree.contain(7));
//        System.out.println(tree.contain(6));
//        System.out.println(tree.contain(2));
//        System.out.println(tree.contain(0));
//        HashTable<String, Integer> table = new HashTable<>();
//        table.add("Hello", 1);
//        table.add("World", 2);
//        table.add("Privet", 7);
//        table.add("Privet1", 7);
//
//        table.print();
//
//
//
//        System.out.println(table.getSize());
//        System.out.println(table.getValue("Hello"));

//        System.out.println(table.getLength());
//        String str = "Hello";
//        System.out.println(str.hashCode() % 4);

//        String a = "5";
//        String b = "3";
//        String c = "11";
//        String d = "7";
//
//        System.out.println(a.hashCode());
//        System.out.println(b.hashCode());
//        System.out.println(c.hashCode());
//        System.out.println(d.hashCode());
