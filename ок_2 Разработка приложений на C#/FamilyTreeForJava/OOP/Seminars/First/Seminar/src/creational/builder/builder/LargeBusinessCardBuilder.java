package creational.builder.builder;

import creational.builder.BusinessCard;

public class LargeBusinessCardBuilder extends BusinessCardBuilder{
    public LargeBusinessCardBuilder() {
        super();
    }

    @Override
    void createName() {
        getCard().setName("Большая визитка");
    }

    @Override
    void createPrice() {
        getCard().setPrice(200);
    }

    @Override
    void createSize() {
        getCard().setSize(new int[]{32,18});
    }
}
