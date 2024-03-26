package structural.decorator;

public class MiddleDeveloper extends DeveloperDecorator{
    public MiddleDeveloper(Developer developer) {
        super(developer);
    }

    @Override
    public String makeJob() {
        return super.makeJob() + " " + codeReview();
    }
    private String codeReview(){
        return "Делаю код ревью";
    }
}
