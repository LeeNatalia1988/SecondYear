package creational.builder.builder;

import creational.builder.BusinessCard;

public abstract class BusinessCardBuilder {
    private BusinessCard card;
    abstract void createName();
    abstract void createPrice();
    abstract void createSize();

    public BusinessCardBuilder() {
        createCard();
    }

    public BusinessCardBuilder setColor(String color){
        card.setColor(color);
        return this;
    }
    public BusinessCardBuilder setColor2(String color){
        card.setColor(color);
        return this;
    }

    private void createCard() {
        card = new BusinessCard();
    }

    BusinessCard getCard() {
        return card;
    }

    public BusinessCard build(){
        createName();
        createSize();
        createPrice();

        return card;
    }
}
