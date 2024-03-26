import java.util.ArrayList;

public class Robot3 {
    enum State {
        On, Off
    }
    private static int defaultIndex;
    private static ArrayList<String> names;

    static {
        defaultIndex = 1;
        names = new ArrayList<String>();
    }
    private int level;
    private String name;
    private State state;
    public Robot3(String name, int level){
        if ((name.isEmpty()
            || Character.isDigit(name.charAt(0)))
            || Robot3.names.contains(name))
        {
            this.name = String.format("DefaultName_%d", defaultIndex++);
        } else {
            this.name = name;
        }
        Robot3.names.add(this.name);
        this.level = level;
        this.state = State.Off;
    }

    public int getLevel(){
        return this.level;
    }
    public String getName(){
        return this.name;
    }
    public void powerOn(){
        this.startBIOS();
        this.startOS();
        this.sayHi();
    }
    public void powerOff(){
        this.sayBye();
        this.stopOS();
        this.stopBIOS();
    }
    private void startBIOS(){
        System.out.println("Start BIOS...");
    }
    private void startOS() {
        System.out.println("Start OS...");
    }
    private void sayHi(){
        System.out.println("Hello world...");
    }
    private void stopBIOS() {
        System.out.println("Stop BIOS...");
    }
    private void stopOS() {
        System.out.println("Stop OS...");
    }
    private void sayBye() {
        System.out.println("Bye...");
    }
    public void work() {
        System.out.println("Working...");
    }
}
