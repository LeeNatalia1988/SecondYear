package behavioral.chain;

import behavioral.Unit;

public class Main {
    public static void main(String[] main) {
        Notifier notifier1 = new LoggerNotifier(Priority.ROUTINE);
        Notifier notifier2 = new EmailNotifier(Priority.WARNING);
        Notifier notifier3 = new SMSNotifier(Priority.ASAP);

        notifier1.setNextNotifier(notifier2);
        notifier2.setNextNotifier(notifier3);

//        notifier1.manageMessage(Priority.ASAP, "Все хорошо");
        notifier2.manageMessage(Priority.ASAP, "Что-то пошло не так");
//        notifier3.manageMessage(Priority.ASAP, "Все плохо");

    }
}
