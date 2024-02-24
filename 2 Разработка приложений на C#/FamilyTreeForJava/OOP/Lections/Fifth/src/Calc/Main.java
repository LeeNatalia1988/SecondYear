package Calc;

public class Main {
    public static void main(String[] args) {
        var m = new SumModel();
        var v = new View();
        Presenter p = new Presenter(v, m);
        p.buttonClick();
    }
}