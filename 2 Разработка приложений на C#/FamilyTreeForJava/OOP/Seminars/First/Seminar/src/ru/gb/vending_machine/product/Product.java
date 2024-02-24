package ru.gb.vending_machine.product;

public class Product {
    private double price;
    private String name;

    public Product(String name, double price) {
        this.price = price;
        this.name = name;
    }

    public String getName() {
        return name;
    }

    @Override
    public String toString() {
        return "name: " + name + ", price: " + price + "p.";
    }
}
