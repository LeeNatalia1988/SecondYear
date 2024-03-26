package behavioral.chain;

public abstract class Notifier {
    private int priority;
    private Notifier nextNotifier;

    public Notifier(int priority) {
        this.priority = priority;
    }

    public void setNextNotifier(Notifier nextNotifier) {
        this.nextNotifier = nextNotifier;
    }

    public abstract void write(String message);

    public void manageMessage(int priority, String message){
        if (this.priority <= priority){
            write(message);
        }
        if (nextNotifier != null){
            nextNotifier.manageMessage(priority, message);
        }
    }
}
