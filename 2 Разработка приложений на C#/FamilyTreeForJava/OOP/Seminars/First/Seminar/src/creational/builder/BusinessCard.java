package creational.builder;

import java.util.Arrays;

public class BusinessCard {
    private String name;
    private double price;
    private int[] size;
    private String color;

    public void setColor(String color) {
        this.color = color;
    }

    public void setName(String name) {
        this.name = name;
    }

    public void setPrice(double price) {
        this.price = price;
    }

    public void setSize(int[] size) {
        this.size = size;
    }

    @Override
    public String toString() {
        return "BusinessCard{" +
                "name='" + name + '\'' +
                ", price=" + price +
                ", size=" + Arrays.toString(size) +
                ", color='" + color + '\'' +
                '}';
    }
}
