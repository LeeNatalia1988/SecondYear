public class Robot1 {
    public int level;
    public String name;
    public Robot1(String name, int level){
        this.name = name;
        this.level = level;
    }
    public void startBIOS(){
        System.out.println("Start BIOS...");
    }
    public void startOS() {
        System.out.println("Start OS...");
    }
    public void sayHi(){
        System.out.println("Hello world...");
    }
    public void stopBIOS() {
        System.out.println("Stop BIOS...");
    }
    public void stopOS() {
        System.out.println("Stop OS...");
    }
    public void sayBye() {
        System.out.println("Bye...");
    }
    public void work() {
        System.out.println("Working...");
    }
}
