package Lesson_2.taxi;

public class UberTaxt extends Taxi{
    @Override
    public void drive(String address) {
        System.out.println("Убер уже ждет вас");
    }
}
