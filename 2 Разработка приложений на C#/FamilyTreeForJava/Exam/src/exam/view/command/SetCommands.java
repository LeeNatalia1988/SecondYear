package exam.view.command;

import exam.view.ConsoleUI;

public class SetCommands extends Command{
    public SetCommands(ConsoleUI consoleUI) {
        super("Установить команду животному по Id", consoleUI);
    }

    @Override
    public void execute() {
        super.getConsoleUI().setCommands();
    }
}
