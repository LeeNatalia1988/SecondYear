package Tasks;

class Task_6 {
    Task_6() {
    }

    public int[] divArrays(int[] a, int[] b) {
        int[] c = new int[a.length];
        if (a.length != b.length) {
            return new int[]{0};
        } else {
            for(int i = 0; i < a.length; ++i) {
                for(int j = 0; j < b.length; ++j) {
                    c[i] = a[i] / b[i];
                }
            }

            return c;
        }
    }
}
