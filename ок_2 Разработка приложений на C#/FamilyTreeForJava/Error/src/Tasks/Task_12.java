package Tasks;


import java.io.IOException;

public class Task_12 {
    public static void main(String[] args) {
        try (Counter counter = new Counter()) {
            counter.add();
            System.out.println("Значение счетчика:" + counter.getValue());
        } catch (IOException e) {
            System.out.println("Произошла ошибка:" + e.getMessage());
        }
    }

    public static class Counter implements AutoCloseable{
        private int value;
        private boolean closed;

        public Counter() {
            this.value = 0;
            this.closed = false;
        }

        public void add() throws IOException {
            if (closed) {
                throw new IOException("Ресурс уже закрыт");
            }
            value++;
        }
        public int getValue() {
            return value;
        }

        public boolean isClosed() {
            return closed;
        }
        @Override
        public void close() {
            closed = true;
        }
    }
}


