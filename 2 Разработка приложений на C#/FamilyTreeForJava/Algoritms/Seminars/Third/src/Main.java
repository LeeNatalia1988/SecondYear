public class Main {
    public static void main(String[] args) {
        LinkedList<String> list = new LinkedList();

        list.add("5");
        list.add("2");
        list.add("9");
        list.add("0");
        list.add("Hello");

        list.addAt("-1", 3);
        list.print();
        list.quickSort();
        list.print();
        list.remove("Hello");

        list.print();
    }
}