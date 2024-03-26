package Lesson_2.taxi;

import java.io.Serializable;

public class Person implements Serializable {
    public void callTaxi(Driveable driveable){
        driveable.drive("Ленина 55");
    }
}
