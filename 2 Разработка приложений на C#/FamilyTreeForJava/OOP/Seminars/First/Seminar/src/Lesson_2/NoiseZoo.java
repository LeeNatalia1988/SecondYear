package Lesson_2;

import java.util.List;

public class NoiseZoo {
    private List<Speakable> speakables;
    public NoiseZoo(List<Speakable> speakables) {
        this.speakables = speakables;
    }
    public void speakAll(){
        for(Speakable speakable: speakables){
            if (speakable instanceof Cat){
                Cat cat = (Cat) speakable;
                System.out.print("кошка говорит: ");
            }
            speakable.speak();
        }
    }
}
