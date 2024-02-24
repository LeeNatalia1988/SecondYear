package Shop.View.Command;

import Shop.View.ConsoleUI;

public class WriteFile extends Command{

    public WriteFile(ConsoleUI consoleUI) {
        super("Забрать игрушки (запись в файл)", consoleUI);
    }

    @Override
    public void execute() {
        super.getConsoleUI().writeFile();
    }
}
