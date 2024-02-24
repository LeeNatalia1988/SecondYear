package exam.view.command;

import exam.view.ConsoleUI;

public class GetCommands extends Command{
    public GetCommands(ConsoleUI consoleUI) {
        super("Получить команды животного по Id", consoleUI);
    }

    @Override
    public void execute() {
        super.getConsoleUI().getCommands();
    }
}
