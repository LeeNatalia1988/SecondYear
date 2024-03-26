package Lesson_2;

public class Cat extends Animal{
    @Override
    public void speak(){
        System.out.println("Мяу");
    }
    @Override
    public boolean equals(Object obj) {
        return super.equals(obj);
    }
}
