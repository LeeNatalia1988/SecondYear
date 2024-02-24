import java.util.Objects;
import java.util.TreeMap;

public class Main {
    String code;
    public boolean equals(Main m){
        return Objects.equals(this.code, m.code);
    }

    public static void main(String[] args) {

        TreeMap<Object, Object> tm = new TreeMap<>();
        tm.put("Студия", 15);
        tm.put("Однушка", 25);
        tm.put("Двушка", 35);
        Integer x = (Integer) tm.get("Студия");
        System.out.println(x);
//        String n = "I I VI X";
//        String[] mass = n.split(" ");
//
//        Map<String, Integer> states = new HashMap<>();
//        states.put("I", 1);
//        states.put("V", 5);
//        states.put("X", 10);
//        for (String m: mass){
//            if(states.get(m) == null){
//                String[] n2 = m.split("");
//                for (String m2: n2) {
//                    System.out.println(states.get(m2));
//                }
//            } else {
//                System.out.println(states.get(m));
//            }
//        }
//        states.put(213454, "Semi V. L.");
//        states.put(213455, "Kolya V. L.");
//        states.put(213456, "Sergey V. L.");
//        states.put(213456, "Sergey V. S.");
//        System.out.println(states.keySet());
//        System.out.println(states.values());
//        states.replace(213455, "Oleg I. B.");
//        System.out.println(states.values());
//        states.remove(213453);
//        System.out.println(states.values());
//        for (Map.Entry<Integer, String> item: states.entrySet()){
//            System.out.println(item.getKey() + " " + item.getValue());
//        }
//        Main m1 = new Main();
//        m1.code = "123";
//        Main m2 = new Main();
//        m2.code = "123";
//        System.out.println(m1.equals(m2));
    }
}