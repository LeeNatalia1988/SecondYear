package structural.decorator;

public class SeniorDeveloper extends DeveloperDecorator{
    public SeniorDeveloper(Developer developer) {
        super(developer);
    }

    @Override
    public String makeJob() {
        return super.makeJob() + " " + sendReport();
    }

    private String sendReport(){
        return "Делаю отчет по проекту";
    }
}
