package creational.builder.builder;

import creational.builder.BusinessCard;

public class SmallBusinessCardBuilder extends BusinessCardBuilder{
    public SmallBusinessCardBuilder() {
        super();
    }

    @Override
    void createName() {
        getCard().setName("Маленькая визитка");
    }

    @Override
    void createPrice() {
        getCard().setPrice(100);
    }

    @Override
    void createSize() {
        getCard().setSize(new int[]{16,9});
    }
}
