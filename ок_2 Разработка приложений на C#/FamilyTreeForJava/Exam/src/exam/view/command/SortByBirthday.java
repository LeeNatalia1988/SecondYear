package exam.view.command;

import exam.view.ConsoleUI;

public class SortByBirthday extends Command{
    public SortByBirthday(ConsoleUI consoleUI) {
        super("Отсортировать по рождению", consoleUI);
    }

    @Override
    public void execute() {
        super.getConsoleUI().sortByBirthday();
    }
}