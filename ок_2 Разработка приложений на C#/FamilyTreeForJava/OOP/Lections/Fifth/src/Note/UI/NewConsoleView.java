package Note.UI;

public class NewConsoleView extends ConsoleView {
    
    public NewConsoleView() {
        super();
    }

    @Override
    public void setDescription(String value) {
        super.setDescription(value);
        System.out.println();
    }

}
