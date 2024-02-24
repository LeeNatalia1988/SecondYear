import java.util.HashSet;

class Person{
    private String name;
    private Integer age;
    private String city;
    private Person children;
    public Person(String Name, Integer Age, String City){
        name = Name;
        age = Age;
        city = City;
    }

    public Person(String Name, Integer Age, String City, Person Children){
        name = Name;
        age = Age;
        city = City;
        children = Children;
    }

    public Integer getAge() {
        return age;
    }

    public String getCity() {
        return city;
    }

    public String getName() {
        return name;
    }

    public Person getChildren() {
        return children;
    }
}

public class Main {
    public static void main(String[] args) {
        HashSet<Person> states = new HashSet<>();
        states.add(new Person("Ivan", 15, "Moscow"));
        states.add(new Person("Vlad", 16, "Rostov"));
        states.add(new Person("Egor", 30, "Moscow", new Person("Max", 10, "Moscow")));
        for (Person p: states){
            System.out.println(p.getName());
            System.out.println(p.getAge());
            System.out.println(p.getCity());
            if (p.getChildren() != null){
                System.out.println(p.getChildren().getName());
            }
            System.out.println();
        }

//        states.add("Germany");
//        states.add("France");
//        states.add("Russia");
//        boolean flag = states.add("France");
//        System.out.println(states.size());
//        for (String state: states){
//            System.out.println(state);
//        }
    }
}