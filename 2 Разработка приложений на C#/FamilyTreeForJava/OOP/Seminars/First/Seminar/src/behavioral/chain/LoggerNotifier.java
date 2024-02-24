package behavioral.chain;

public class LoggerNotifier extends Notifier{
    public LoggerNotifier(int priority) {
        super(priority);
    }

    @Override
    public void write(String message) {
        System.out.println("Пишу в логи: " + message);
    }
}
