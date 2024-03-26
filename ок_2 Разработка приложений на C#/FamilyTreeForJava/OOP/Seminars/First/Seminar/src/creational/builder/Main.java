package creational.builder;

import creational.builder.builder.BusinessCardBuilder;
import creational.builder.builder.SmallBusinessCardBuilder;

public class Main {
    public static void main(String[] args) {
        BusinessCardBuilder builder = new SmallBusinessCardBuilder();

        BusinessCard card = builder.setColor("Красная").setColor2("Зеленый").build();
        System.out.println(card);
    }
}
