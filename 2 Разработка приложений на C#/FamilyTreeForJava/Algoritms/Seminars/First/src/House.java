public class House {
    public int floorCount;
    public Color color;
    public int height;
    public String street;
    Apart[] apartaments;

    public void burn() {
        floorCount = 1;
        color = Color.Black;
        height = 3;
    }

    public void print(){
        System.out.println("Street" + this.street);
    }

    public void setColor(Color _color) {
        this.color = _color;
    }
    public House() {
        this(1);

    }
    public House(int _floorCount)
    {
        if (_floorCount < 1)
            floorCount = 1;
        floorCount = _floorCount;
    }

}

enum Color {White, Black, Red, Yellow, Green}
