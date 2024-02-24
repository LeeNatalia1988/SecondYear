package Lesson_2.taxi;

public class Friend implements Driveable{
    @Override
    public void drive(String address) {
        System.out.println("Садись дружище");
    }
}
